using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myShoppingCart.DataAccess.Repository;
using myShoppingCart.DataAccess.Repository.IRepository;
using myShoppingCart.Models;
using myShoppingCart.Models.ViewModels;
using System.Collections.Generic;


namespace myShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> ViewDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productObj = _unitOfWork.Product.Get(obj=>obj.Id==id);
            if (productObj == null)
            {
                return NotFound();
            }
            return View(productObj);
        }

        // GET: ProductController/Create
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                //create
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.categoryName,
                    Value = u.categoryId.ToString()
                }),
                Product = new Product()
            };
            //ViewBag.CategroyList = CategoryList;
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(obj => obj.Id == id);
                return View(productVM);
            }
           
            
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            HashSet<Product> productHashset = _unitOfWork.Product.GetAll().ToHashSet();
            if (productHashset.Any(productObj => productObj.Title == productVM.Product.Title))
            {
                ModelState.AddModelError("Title", "The title has already existed!");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Product.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Created!!";
                    return RedirectToAction("Index", "Product");
                }
                catch (Exception ex)
                {
                   
                }
                
            }
            else
            {
                try
                {
                    productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.categoryName,
                        Value = u.categoryId.ToString()
                    });
                    return View(productVM);
                }
                catch (Exception ex)
                {
                    
                }
            }
            return View();
        }

        
        //// GET: ProductController/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product? productObj = _unitOfWork.Product.Get(obj => obj.Id == id);
        //    if (productObj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productObj);
        //}

        //// POST: ProductController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(Product obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _unitOfWork.Product.Update(obj);
        //            _unitOfWork.Save();
                    
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(obj.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }

        //        }
        //        TempData["success"] = "Product Updated!!";
        //        return RedirectToAction("Index", "Product");
        //    }
        //    return View();
        //}

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productObj = _unitOfWork.Product.Get(obj => obj.Id == id);
            if (productObj == null)
            {
                return NotFound();
            }
            return View(productObj);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product obj)
        {
            
            try
            {
                _unitOfWork.Product.Remove(obj);
                _unitOfWork.Save();

            }
            catch (Exception ex)
            {
                if (!ProductExists(obj.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            TempData["success"] = "Product Updated!!";
            return RedirectToAction("Index", "Product");
        }
        private bool ProductExists(int id)
        {
            Product productObj = _unitOfWork.Product.Get(c => c.Id == id);

            return productObj != null ? true : false;
        }
    }
}
