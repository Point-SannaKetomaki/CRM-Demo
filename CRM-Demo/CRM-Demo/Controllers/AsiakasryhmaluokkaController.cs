﻿using CRM_Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Demo.Controllers
{
    public class AsiakasryhmaluokkaController : Controller
    {
        // GET: Asiakasryhmaluokka
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList()
        {
            //Luodaan uusi entiteettiolio 
            ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

            //Haetaan Asiakasryhmäluokat -taulusta kaikki data
            var asiakasryhmat = (from ar in entities.Asiakasryhmäluokat
                                 select ar).ToList();

            //Muutetaan data json -muotoon toimitettavaksi selaimelle. Suljetaan tietokantayhteys.
            string json = JsonConvert.SerializeObject(asiakasryhmat);
            entities.Dispose();

            //ohitetaan välimuisti, jotta näyttö päivittyy (IE-selainta varten) 
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            //Lähetetään data selaimelle
            return Json(json, JsonRequestBehavior.AllowGet);
        }
       
        
        public JsonResult GetSingleGroup(string id)
        {
            //Haetaan tietokannasta "klikatun" ryhmän tiedot

            //Luodaan uusi entiteettiolio 
            ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

            //Muutetaan modaali-ikkunasta tullut string-tyyppinen ryhmäId int-tyyppiseksi
            int ID = int.Parse(id);

            //Haetaan Asiakasryhmäluokat -taulusta kaikki data
            var asiakasryhma = (from ar in entities.Asiakasryhmäluokat
                                where ar.RyhmäId == ID
                                select ar).FirstOrDefault();

            //Muutetaan olio json -muotoon toimitettavaksi selaimelle. Suljetaan tietokantayhteys.
            string json = JsonConvert.SerializeObject(asiakasryhma);
            entities.Dispose();

            //ohitetaan välimuisti, jotta näyttö päivittyy (IE-selainta varten) 
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            //Lähetetään data selaimelle
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Asiakasryhmäluokat asiakasryhmäluokka)
        {
            // TIETOJEN PÄIVITYS JA UUDEN ASIAKASRYHMÄN LISÄYS

            bool OK = false;    //tallennuksen onnistuminen

            //tietokantaan tallennetaan uusia tietoja vain, mikäli ryhmän  nimi
            //ja ryhmän kuvaus -kentät eivät ole tyhjiä
            if (!string.IsNullOrWhiteSpace(asiakasryhmäluokka.RyhmäNimi) &&
                !string.IsNullOrWhiteSpace(asiakasryhmäluokka.RyhmäKuvaus))
            {
                //luodaan uusi entiteettiolio
                ProjektitDBCareEntities entities = new ProjektitDBCareEntities();

                int ryhmäid = asiakasryhmäluokka.RyhmäId;

                if (ryhmäid == 0)
                {
                    //Uuden ryhmän lisääminen tietokantaan dbItem-nimisen olion avulla
                    Asiakasryhmäluokat dbItem = new Asiakasryhmäluokat()
                    {
                        //dbItemin arvot/tiedot
                        RyhmäNimi = asiakasryhmäluokka.RyhmäNimi,
                        RyhmäKuvaus = asiakasryhmäluokka.RyhmäKuvaus
                    };

                    //lisätään tietokantaan dbItemin tiedot ja tallennetaan muutokset
                    entities.Asiakasryhmäluokat.Add(dbItem);
                    entities.SaveChanges();
                    OK = true;
                }
                else
                {
                    //muokataan olemassa olevia tietoja
                    //haetaan tiedot tietokannasta

                    Asiakasryhmäluokat dbItem = (from ar in entities.Asiakasryhmäluokat
                                                 where ar.RyhmäId == ryhmäid
                                                 select ar).FirstOrDefault();

                    //tallennetaan modaali-ikkunasta tulevat tiedot dbItem-olioon
                    if (dbItem != null)
                    {
                        dbItem.RyhmäNimi = asiakasryhmäluokka.RyhmäNimi;
                        dbItem.RyhmäKuvaus = asiakasryhmäluokka.RyhmäKuvaus;

                        // tallennetaan uudet tiedot tietokantaan
                        entities.SaveChanges();
                        OK = true;
                    }
                }

                //suljetaan tietokantayhteys
                entities.Dispose();
            }

            //palautetaan tallennuskuittaus selaimelle (muuttuja OK)
            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}


