﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Demo.Controllers
{
    public class AsiakasryhmaController : Controller
    {
        // GET: Asiakasryhma
        public ActionResult Index()
        {
            return View();
        }

        // GET: Asiakasryhma/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asiakasryhma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakasryhma/Create
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

        // GET: Asiakasryhma/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asiakasryhma/Edit/5
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

        // GET: Asiakasryhma/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asiakasryhma/Delete/5
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