using CRM_Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Demo.Controllers
{
    public class AsiakastapahtumaController : Controller
    {
        // GET: Asiakastapahtuma
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetList()
        {
            ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

            //Haetaan kaikki tiedot Tapahtumat-taulusta listalle

            //List<Tapahtumat> tapahtumat = entities.Tapahtumat.ToList();  //tulee undefined rivejä

            //var tapahtumat = (from t in entities.Tapahtumat
            //                  select t).ToList();    // tästäkin tulee undefined rivejä

            var tapahtumat = (from t in entities.Tapahtumat
                              select new
                              {
                                  t.TapahtumaId,
                                  t.AsiakasId,
                                  t.TapahtumalajiId,
                                  t.TapahtumaPvm,
                                  t.TapahtumaKlo,
                                  t.TapahtumaKuvaus
                              }).ToList();




            //Muutetaan data json -muotoon toimitettavaksi selaimelle. Suljetaan tietokantayhteys.
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

            string json = JsonConvert.SerializeObject(tapahtumat, serializerSettings);
            entities.Dispose();

            //ohitetaan välimuisti, jotta näyttö päivittyy (IE-selainta varten) 
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            //Lähetetään data selaimelle
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Update(Tapahtumat tapahtumat)
        {
            //TIETOJEN LISÄYS JA PÄIVITYS

            bool OK = false;   //tallennuksen onnistuminen

            //UUSIEN TIETOJEN LISÄYS
            //Uusia tietoja lisätään vain mikäli asiakasId ja TapahtumalajiId eivät ole tyhjiä
            if ((tapahtumat.AsiakasId != null) &&
                (tapahtumat.TapahtumalajiId != null))
            {
                //avataan tietokantayhteys = uusi entiteettiolio
                ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

                //luodaan uusi muuttuja johon asetetaan selaimesta tullut tieto TapahtumaId:stä
                int tapahtumaId = tapahtumat.TapahtumaId;

                if (tapahtumaId == 0)
                {
                    //tallennetaan uuden tapahtuman tiedot

                    //luodaan uusi Tapahtumat-tyyppinen olio dbItem, jonka avulla tiedot tallennetaan kantaan
                    Tapahtumat dbItem = new Tapahtumat()
                    {
                        //dbItemin arvot/tiedot, ei TapahtumaId:tä
                        AsiakasId = tapahtumat.AsiakasId,
                        TapahtumalajiId = tapahtumat.TapahtumalajiId,
                        TapahtumaPvm = tapahtumat.TapahtumaPvm,
                        TapahtumaKlo = tapahtumat.TapahtumaKlo,
                        TapahtumaKuvaus = tapahtumat.TapahtumaKuvaus
                    };

                    //Lisätään dbItem kantaan ja tallennetaan muutokset
                    entities.Tapahtumat.Add(dbItem);
                    entities.SaveChanges();

                    //tallennus on onnistunut
                    OK = true;
                }
                else
                {
                    //päivitetään valitun tapahtuman tietoja
                }

                //suljetaan tietokantayhteys
                entities.Dispose();
            }

            //palautetaan tulostumisen onnistuminen selaimelle
            return Json(OK, JsonRequestBehavior.AllowGet);
        }







        // GET: Asiakastapahtuma/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asiakastapahtuma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asiakastapahtuma/Create
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

        // GET: Asiakastapahtuma/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asiakastapahtuma/Edit/5
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

        // GET: Asiakastapahtuma/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asiakastapahtuma/Delete/5
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
