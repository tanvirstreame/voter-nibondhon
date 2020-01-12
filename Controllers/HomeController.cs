using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projectile.Models;
using Projectile.Contex;

namespace Projectile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContex _db = new DBContex();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int nid)
        {
            if(nid > 0) {
                var data = _db.Person.Where(x => x.Id == nid).FirstOrDefault();
                ViewData["SearchedData"] = data;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Person person)
        {
            _db.Person.Add(person);
            int flag = _db.SaveChanges();
            ViewData["nid"] = person.Id.ToString().PadLeft(8, '0');;
            ViewData["Message"] = flag == 1 ? "Data inserted successfully" : "Failed";

            return View();
        }

        public IActionResult Information()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
