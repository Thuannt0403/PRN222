using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Services;

namespace ProductManagementMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _contextProduct;
        private readonly ICategoryService _contextCategory;
       

        public ProductsController(IProductService contextProduct, ICategoryService contextCategory)
        {
            _contextProduct = contextProduct;
            _contextCategory = contextCategory;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                // Redirect to the login page or display an error message
                return RedirectToAction("Login", "Account");
            }

            var myStoreDbContext = _contextProduct.GetProducts();
            return View(myStoreDbContext.ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _contextProduct.GetProductById((int)id);
                
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
        {
            try
        {
                Console.WriteLine($"ProductId trước khi save: {product.ProductId}");
                Console.WriteLine($"CategoryId: {product.CategoryId}");
                _contextProduct.SaveProduct(product);
            return RedirectToAction(nameof(Index));
        }
            catch (Exception ex)
            {
                Exception inner = ex;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                ModelState.AddModelError("", "Lỗi khi lưu sản phẩm: " + inner.Message);
            }
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _contextProduct.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }


        // POST: Products/Edit/5    
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"ModelState Error - {entry.Key}: {error.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _contextProduct.UpdateProduct(product);
                }
                catch (Exception)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _contextProduct.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _contextProduct.GetProductById(id);
            {
                _contextProduct.DeleteProduct(product);
            }

            
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            var tmp = _contextProduct.GetProductById(id);
            return (tmp != null)? true : false;
        }
        

    }
}
