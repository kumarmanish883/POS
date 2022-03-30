using AjaxMVCCoreCRUD.Data;
using AjaxMVCCoreCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly AjaxDbContext _context;
        public ProductController(AjaxDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string SearchText="")
        {
            List<Product> products;
            if (SearchText != "" && SearchText != null)
            {
                products = _context.Products.Where(p => p.Name.Contains(SearchText)).ToList();

                   
            }
            else
            
                products = _context.Products.ToList();
            
            return View(products);
        }

        //Ajxa index action method
        public IActionResult IndexAjax()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult Details(string id)
        {
            Product pro = _context.Products.Where(p => p.Code == id).FirstOrDefault();
            return View(pro);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            Product pro = _context.Products.Where(p => p.Code == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            Product pro = _context.Products.Where(p => p.Code == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        

        #region "ajax Function"
        [HttpPost]
        public IActionResult DeleteProduct(string id)
        {
            Product pro = _context.Products.Where(p => p.Code == id).FirstOrDefault();
            _context.Entry(pro).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok();

        }
        public IActionResult ViewProduct(string id)
        {
            Product pro = _context.Products.Where(p => p.Code == id).FirstOrDefault();
            
            return PartialView("_detail",pro);

        }
        public IActionResult EditProduct(string id)

        {
            Product pro = _context.Products.Where(p => p.Code == id).FirstOrDefault();

            return PartialView("_Edit", pro);

        }
        public IActionResult UpdateProduct(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return PartialView("_product", product);

        }


        #endregion
    }
}

