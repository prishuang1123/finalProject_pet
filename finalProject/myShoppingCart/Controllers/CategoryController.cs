using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myShoppingCart.Data.Migrations;
using myShoppingCart.Models;
using myShoppingCart.ViewModels;

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
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> ViewDetails(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }

            Category? categoryObj=await _db.categories.FirstOrDefaultAsync(obj=>obj.categoryId==id);
            if (categoryObj==null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null || id == 0) {
                return NotFound(); 
            }
            Category? categoryObj = await _db.categories.FirstOrDefaultAsync(obj => obj.categoryId == id);
            if (categoryObj==null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryObj.modifiedAt = DateTime.UtcNow;
                    _db.categories.Update(categoryObj);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(categoryObj.categoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    
                }
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            Category categoryObj = await _db.categories.FirstOrDefaultAsync(obj=>obj.categoryId == id);
            if (categoryObj == null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category categoryObj)
        {
            try
            {
                _db.categories.Remove(categoryObj);
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                if (!CategoryExists(categoryObj.categoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Category");
        }
        private bool CategoryExists(int id)
        {
            return _db.categories.Any(c => c.categoryId == id);
        }
    }
}
