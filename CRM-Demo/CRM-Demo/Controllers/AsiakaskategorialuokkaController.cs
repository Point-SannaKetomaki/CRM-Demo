using CRM_Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Demo.Controllers
{
    public class AsiakaskategorialuokkaController : Controller
    {
        // GET: Asiakaskategorialuokka
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList()
        {
            //Luodaan uusi entiteettiolio 
            ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

            //Haetaan Asiakaskategorialuokat -taulusta kaikki data
            var asiakaskategoriat = (from ak in entities.Asiakaskategorialuokat
                                 select ak).ToList();

            //Muutetaan data json -muotoon toimitettavaksi selaimelle. Suljetaan tietokantayhteys.
            string json = JsonConvert.SerializeObject(asiakaskategoriat);
            entities.Dispose();

            //ohitetaan välimuisti, jotta näyttö päivittyy (IE-selainta varten) 
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            //Lähetetään data selaimelle
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        // GET: Asiakaskategorialuokka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asiakaskategorialuokka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakaskategorialuokka/Create
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

        // GET: Asiakaskategorialuokka/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asiakaskategorialuokka/Edit/5
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

        // GET: Asiakaskategorialuokka/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asiakaskategorialuokka/Delete/5
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
