using CRM_Demo.Models;
using Newtonsoft.Json;
using System;
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

        public JsonResult GetList()
        {
            //avataan tietokantayhteys
            ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

            //haetaan kaikki data Asiakasryhmät-taulusta
            var asiakasryhmät = (from asir in entities.Asiakasryhmät
                                 join ar in entities.Asiakasryhmäluokat
                                 on asir.RyhmäId equals ar.RyhmäId
                                 join asi in entities.Asiakkaat
                                 on asir.AsiakasId equals asi.AsiakasId
                                 orderby ar.RyhmäNimi
                                 select new
                                 {
                                     asir.AsiakasryhmäId,
                                     ar.RyhmäNimi,
                                     asi.Etunimi,
                                     asi.Sukunimi
                                 }).ToList();

            //muutetaan data json muotoon toimitettavaksi selaimelle
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string json = JsonConvert.SerializeObject(asiakasryhmät, serializerSettings);

            //suljetaan tietokantayhteys
            entities.Dispose();

            //ohitetaan välimuisti, jotta näyttö päivittyy (IE-selainta varten) 
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            //lähetetään data selaimelle
            return Json(json, JsonRequestBehavior.AllowGet);

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
