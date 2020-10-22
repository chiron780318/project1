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
            List<Customers> list = db.Customers.Select(c => c).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string CustomerID,string CompanyName, string ContactName)
        {
            Customers customers = new Customers();
            customers.CustomerID = CustomerID;
            customers.CompanyName = CompanyName;
            customers.ContactName = ContactName;
            db.Customers.Add(customers);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(string CustomerID)
        {
            Customers customers = db.Customers.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
            ViewBag.CustomerID = CustomerID;
            return View(customers);
        }
        [HttpPost]
        public ActionResult Edit(string CustomerID, string CompanyName, string ContactName)
        {

            Customers customers = db.Customers.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
            customers.CustomerID = CustomerID;
            customers.CompanyName = CompanyName;
            customers.ContactName = ContactName;
            db.Customers.Add(customers);

            return RedirectToAction("Index");
        }

    }
}