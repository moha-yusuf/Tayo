using Microsoft.AspNetCore.Mvc;
using Tayo.DataAccess.Data;
using Tayo.Models;
using Tayo.DataAccess.Repository.IRepository;
using TayoBook.DataAccess.Repository.IRepository;

namespace TayoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductColorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductColorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ProductColor> productColorList = _unitOfWork.ProductColor.GetAll().ToList();
            return View(productColorList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductColor obj)
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
                _unitOfWork.ProductColor.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Color created successfully.";
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
            ProductColor? productColorList = _unitOfWork.ProductColor.Get(u => u.Id == id); ;
            if (productColorList == null)
            {
                return NotFound();
            }

            return View(productColorList);
        }

        [HttpPost]
        public IActionResult Edit(ProductColor obj)
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
                _unitOfWork.ProductColor.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Color updated successfully.";
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
            ProductColor? productColorList = _unitOfWork.ProductColor.Get(u => u.Id == id);
            if (productColorList == null)
            {
                return NotFound();
            }

            return View(productColorList);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            ProductColor? obj = _unitOfWork.ProductColor.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductColor.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Color deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
