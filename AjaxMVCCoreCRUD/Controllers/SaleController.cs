using AjaxMVCCoreCRUD.Data;
using AjaxMVCCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Controllers
{
    public class SaleController : Controller
    {
        private readonly AjaxDbContext _context;
        public SaleController(AjaxDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DisplaySale()
        {
            List<Sale> list = _context.Sales.OrderByDescending(x => x.SaleId).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult SaleProduct()
        {
            List<string> list = _context.Products.Select(x => x.Name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(list);
        }
        [HttpPost]
        public IActionResult SaleProduct(Sale s)
        {
            _context.Sales.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Displaysale");
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            Sale pro = _context.Sales.Where(p => p.SaleId == id).FirstOrDefault();
            return View(pro);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {

            Sale pro = _context.Sales.Where(p => p.SaleId == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public IActionResult Delete(string id,Sale s)
        {

            Sale pro = _context.Sales.Where(p => p.SaleId == id).SingleOrDefault();
            _context.Sales.Remove(pro);
            _context.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}
