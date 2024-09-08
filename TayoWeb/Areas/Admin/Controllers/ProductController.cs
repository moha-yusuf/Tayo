﻿using Microsoft.AspNetCore.Mvc;
using Tayo.DataAccess.Data;
using Tayo.Models;
using Tayo.DataAccess.Repository.IRepository;
using TayoBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TayoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll().ToList();
            return View(productList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> CollectionList = _unitOfWork.Collection.GetAll()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            IEnumerable<SelectListItem> SizeList = _unitOfWork.ProductSize.GetAll()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            IEnumerable<SelectListItem> ColorList = _unitOfWork.ProductColor.GetAll()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;
            ViewBag.CollectionList = CollectionList;
            ViewBag.SizeList = SizeList;
            ViewBag.ColorList = ColorList;
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            // add custom validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order can not exactly match");
            }

            // add custom validation for validation summary only
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Name can not be \"test\"");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id); ;
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            // add custom validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order can not exactly match");
            }

            // add custom validation for validation summary only
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Name can not be \"test\"");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View();

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

    }
}
