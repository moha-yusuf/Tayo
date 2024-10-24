﻿using Microsoft.AspNetCore.Mvc;
using Tayo.DataAccess.Data;
using Tayo.Models;
using Tayo.DataAccess.Repository.IRepository;
using TayoBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tayo.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace TayoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,Collection,ProductSize").ToList();
            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CollectionList = _unitOfWork.Collection.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                ProductSizeList = _unitOfWork.ProductSize.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                ProductColorList = _unitOfWork.ProductColor.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            
            if (id == null || id == 0)
            {   
                // Create
                return View(productVM);
            } 

            // Update
            productVM.Product = _unitOfWork.Product.Get(u=>u.Id==id);
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? ImageFile)
        {
            // add custom validation for validation summary only
            if (productVM.Product.Name != null && productVM.Product.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Name can not be \"test\"");
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (ImageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        /*delete the old image*/
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        ImageFile.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }

                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                // Repopulate select items
                productVM.CategoryList = _unitOfWork.Category.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                productVM.CollectionList = _unitOfWork.Collection.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                productVM.ProductSizeList = _unitOfWork.ProductSize.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                productVM.ProductColorList = _unitOfWork.ProductColor.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(productVM);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,Collection,ProductSize").ToList();
            return Json(new {data = productList});
        }

        #endregion

    }
}
