using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using TaskBoard.Models.Classes;
using TaskBoardML.Model;

namespace TaskBoard.Controllers
{
    public class TechnicalCardController : Controller
    {
        Context context = new Context();

        [HttpGet]
        // GET: TechnicalCard
        public ActionResult AddTechnicalCard(int id)
        {
            var ürün = context.müsteriKarts.Find(id);
            ViewBag.ProjeNo = ürün.ProjeNo;
            ViewBag.KartNo = ürün.KartNo;
            ViewBag.Risk = ürün.Risk;
            ViewBag.IslemTipi = ürün.IslemTipi;
            ViewBag.Oncelik = ürün.Oncelik;
            ViewBag.deger = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddTechnicalCard(TeknikKart teknikKart, ModelInput input)
        {
            ViewBag.Result = "";

            switch (input.Risk.ToLower())
            {

                case "düşük":
                    input.Risk = "dusuk";
                    break;
                case "orta":
                    input.Risk = "orta";
                    break;
                case "yüksek":
                    input.Risk = "yuksek";
                    break;
                case "çok yüksek":
                    input.Risk = "cokyuksek";
                    break;

                default:
                    break;
            }

            switch (input.TeknikUzman.ToLower())
            {
                case "rafet":
                    input.TeknikUzman = "rafet";
                    break;
                case "ilayda":
                    input.TeknikUzman = "ilayda";
                    break;
                case "ali":
                    input.TeknikUzman = "ali";
                    break;
                case "mucize":
                    input.TeknikUzman = "mucize";
                    break;

                default:
                    break;
            }

            var timePrediction = ConsumeModel.Predict(input);
            ViewBag.Result = timePrediction;
            teknikKart.TahminSüresi = ViewBag.Result.Score;

            context.teknikKarts.Add(teknikKart);
            context.SaveChanges();

            int ID = Convert.ToInt32(teknikKart.MüsteriKartId);
            MüsteriKart müsteriKart = new MüsteriKart();
            müsteriKart.TeknikST = context.teknikKarts.Where(x => x.MüsteriKartId == ID).Sum(x => x.TahminSüresi);

            var updateTotal = context.müsteriKarts.Find(ID);
            updateTotal.TeknikST = müsteriKart.TeknikST;
            context.SaveChanges();

            return RedirectToAction("TaskBoard", "HomeBoard");

        }

        public ActionResult DeleteTechnicalCard(int id)
        {
            var cardId = context.teknikKarts.Find(id);

            var customerCard = context.müsteriKarts.Find(cardId.MüsteriKartId);
            customerCard.TeknikST = customerCard.TeknikST - cardId.TahminSüresi;
            
            context.teknikKarts.Remove(cardId);
            context.SaveChanges();
            return RedirectToAction("TaskBoard", "HomeBoard");
        }

        [HttpGet]
        public ActionResult AddTechnicalCardWork(int id)
        {
            var technicalCard = context.teknikKarts.Find(id);
            ViewBag.Name = technicalCard.ProjeNo;
            ViewBag.Time = technicalCard.TahminSüresi;
            ViewBag.Prof = technicalCard.TeknikUzman;
            ViewBag.deger3 = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddTechnicalCardWork(TeknikKartIsTakibi teknikKartIsTakibi)
        {
            context.teknikKartIsTakibis.Add(teknikKartIsTakibi);
            int id = teknikKartIsTakibi.TeknikKartId;
            context.SaveChanges();
            return RedirectToAction("AddTechnicalCardWork", "TechnicalCard", new { id });
        }

        public PartialViewResult WorkTable(int id)
        {

            var tableWork = context.teknikKartIsTakibis.Where(x => x.TeknikKartId == id).ToList();
            return PartialView(tableWork);
        }

        public ActionResult GetTechnicalCard(int id)
        {
            var getCard = context.teknikKarts.Find(id);
            return View("GetTechnicalCard", getCard);
        }

        public ActionResult UpdateTechnicalCard(TeknikKart teknikKart)
        {
            var updateCard = context.teknikKarts.Find(teknikKart.ID);
            updateCard.KartNo = teknikKart.KartNo;
            updateCard.ProjeNo = teknikKart.ProjeNo;
            updateCard.TahminSüresi = teknikKart.TahminSüresi;
            updateCard.Tarih = teknikKart.Tarih;
            updateCard.IsinAciklamasi = teknikKart.IsinAciklamasi;
            updateCard.Notlar = teknikKart.Notlar;
            updateCard.TeknikUzman = teknikKart.TeknikUzman;
            context.SaveChanges();
            return RedirectToAction("TaskBoard", "HomeBoard");
        }

        public ActionResult CardDetail(int id)
        {
            var getCard = context.teknikKarts.Find(id);
            return View("CardDetail", getCard);
        }

        public ActionResult DeleteWorkFollow(int id)
        {
            var cardId = context.teknikKartIsTakibis.Find(id);
            context.teknikKartIsTakibis.Remove(cardId);
            context.SaveChanges();
            return RedirectToAction("AddTechnicalCardWork", "TechnicalCard", new { id = cardId.TeknikKartId });
        }
    }
}