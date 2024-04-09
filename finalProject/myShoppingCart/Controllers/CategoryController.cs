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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            HashSet<Category> objCategoryHashset = _db.categories.ToHashSet();
            if (objCategoryHashset.Any(old => old.categoryName == obj.categoryName))
            {
                ModelState.AddModelError("categoryName", "The category name is already existed!");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
