using Microsoft.AspNetCore.Mvc;
using Tayo.DataAccess.Data;
using Tayo.Models;
using Tayo.DataAccess.Repository.IRepository;
using TayoBook.DataAccess.Repository.IRepository;

namespace TayoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductSizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductSizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ProductSize> productSizeList = _unitOfWork.ProductSize.GetAll().ToList();
            return View(productSizeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductSize obj)
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
                _unitOfWork.ProductSize.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Size created successfully.";
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
            ProductSize? productSizeFromDb = _unitOfWork.ProductSize.Get(u => u.Id == id); ;
            if (productSizeFromDb == null)
            {
                return NotFound();
            }

            return View(productSizeFromDb);
        }

        [HttpPost]
        public IActionResult Edit(ProductSize obj)
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
                _unitOfWork.ProductSize.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Size updated successfully.";
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
            ProductSize? productSizeFromDb = _unitOfWork.ProductSize.Get(u => u.Id == id);
            if (productSizeFromDb == null)
            {
                return NotFound();
            }

            return View(productSizeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            ProductSize? obj = _unitOfWork.ProductSize.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductSize.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Size deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
