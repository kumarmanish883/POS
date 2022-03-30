using AjaxMVCCoreCRUD.Data;
using AjaxMVCCoreCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly AjaxDbContext _context;
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AjaxDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(u);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = u.FirstName + " " + u.LastName + " Is sucessfully registered";
            }
            return View();

        }
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            var account = _context.Users.Where(us => us.UserName == u.UserName && us.Password == u.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserId", account.UserId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "UserName or Password is Incorrect");
            }
            return View();

        }
        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
            }
            else
            {
                return Redirect("Login");
            }
            return View();

        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
