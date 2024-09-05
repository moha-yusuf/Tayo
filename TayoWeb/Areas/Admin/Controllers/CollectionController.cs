using Microsoft.AspNetCore.Mvc;
using Tayo.DataAccess.Data;
using Tayo.Models;
using Tayo.DataAccess.Repository.IRepository;
using TayoBook.DataAccess.Repository.IRepository;

namespace TayoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CollectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Collection> collectionList = _unitOfWork.Collection.GetAll().ToList();
            return View(collectionList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Collection obj)
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
                _unitOfWork.Collection.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Collection created successfully.";
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
            Collection? collectionFromDb = _unitOfWork.Collection.Get(u => u.Id == id); ;
            if (collectionFromDb == null)
            {
                return NotFound();
            }

            return View(collectionFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Collection obj)
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
                _unitOfWork.Collection.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Collection updated successfully.";
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
            Collection? collectionFromDb = _unitOfWork.Collection.Get(u => u.Id == id);
            if (collectionFromDb == null)
            {
                return NotFound();
            }

            return View(collectionFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Collection? obj = _unitOfWork.Collection.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Collection.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Collection deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
