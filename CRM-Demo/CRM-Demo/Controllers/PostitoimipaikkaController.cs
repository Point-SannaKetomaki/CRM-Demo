using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Demo.Controllers
{
    public class PostitoimipaikkaController : Controller
    {
        // GET: Postitoimipaikka
        public ActionResult Index()
        {
            return View();
        }

        // GET: Postitoimipaikka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Postitoimipaikka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postitoimipaikka/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Postitoimipaikka/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Postitoimipaikka/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Postitoimipaikka/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Postitoimipaikka/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
