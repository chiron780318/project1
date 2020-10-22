using prjProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjProject1.Controllers
{
    public class CustomersController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();
        // GET: Customers
        public ActionResult Index()
        {
            List<Customers> result = db.Customers.Select(c => c).ToList();
            return View(result);
        }
    }
}