using AjaxMVCCoreCRUD.Data;
using AjaxMVCCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly AjaxDbContext _context;
        public PurchaseController(AjaxDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DisplayPurchase()
        {

            List<Purchase> list = _context.Purchases.OrderByDescending(x => x.Purchase_Id).ToList();
            return View(list);
        }
        
}
}
