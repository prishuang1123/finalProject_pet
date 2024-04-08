using Microsoft.AspNetCore.Mvc;
using myShoppingCart.Models;

namespace myShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CartContext _db;
        public CategoryController(CartContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.categories.ToList();
            return View(objCategoryList);
        }
    }
}
