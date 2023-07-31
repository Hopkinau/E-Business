using Microsoft.AspNetCore.Mvc;

namespace E_Business.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
