using DemoCrud3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DemoCrud3.Controllers
{
    public class CustomerController : Controller
    {
        readonly DemoCrudEntities1 db = new DemoCrudEntities1();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Customers.Where(x=>x.Id==id).FirstOrDefault());
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Customers.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Customers.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                { 
                    customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var lstcitys = (from c in db.Cities
                             where c.Cityname.StartsWith(prefix)
                             select new
                             {
                                 label = c.Cityname,
                                 val = c.Cityid
                             }).ToList();

            return Json(lstcitys);
        }

    }
}
