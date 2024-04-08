using Microsoft.AspNetCore.Mvc;

namespace myShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
