using Microsoft.AspNetCore.Mvc;

namespace TayoWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
