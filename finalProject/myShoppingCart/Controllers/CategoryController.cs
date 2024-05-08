using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myShoppingCart.DataAccess;
using myShoppingCart.DataAccess.Repository.IRepository;
using myShoppingCart.Models;
using myShoppingCart.ViewModels;

namespace myShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
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
            HashSet<Category> objCategoryHashset = _categoryRepo.GetAll().ToHashSet();
            if (objCategoryHashset.Any(old => old.categoryName == obj.categoryName))
            {
                ModelState.AddModelError("categoryName", "The category name is already existed!");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                //ViewBag.success = "訂單創建成功!!";
                TempData["success"] = "Category Created!!";

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

            Category? categoryObj=_categoryRepo.Get(obj=>obj.categoryId==id);
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
            Category? categoryObj =_categoryRepo.Get(obj => obj.categoryId == id);
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
            //check if the edited name is in the category names already
            //HashSet<Category> categoryHashSet = _db.categories.ToHashSet();
            //if (categoryHashSet.Any(obj => obj.categoryName == categoryObj.categoryName))
            //{
            //    ModelState.AddModelError("categoryName", "The category name is already existed!");
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    categoryObj.modifiedAt = DateTime.UtcNow;
                    _categoryRepo.Update(categoryObj);
                    _categoryRepo.Save();

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
                //ViewBag.success = "訂單更新成功!!";
                TempData["success"] = "Category Updated!!";

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
            Category categoryObj = _categoryRepo.Get(obj => obj.categoryId == id);
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
                _categoryRepo.Remove(categoryObj);
                _categoryRepo.Save();
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
            //ViewBag.success = "訂單刪除成功!!";
            TempData["success"] = "Category Deleted!!";
            return RedirectToAction("Index", "Category");
        }
        private bool CategoryExists(int id)
        {
            Category categoryObj = _categoryRepo.Get(c => c.categoryId == id);

            return categoryObj!=null ? true:false ;
        }
    }
}
