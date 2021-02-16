using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskBoard.Models.Classes;

namespace TaskBoard.Controllers
{
    public class CustomerCardController : Controller
    {
        Context context = new Context();
        // GET: CustomerCard
        [HttpGet]
        public ActionResult AddCustomerCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomerCard(MüsteriKart müsteriKart)
        {
            context.müsteriKarts.Add(müsteriKart);
            context.SaveChanges();
            return RedirectToAction("TaskBoard", "HomeBoard");
        }

        public ActionResult DeleteCustomerCard(int id)
        {
            var cardId = context.müsteriKarts.Find(id);
            context.müsteriKarts.Remove(cardId);
            context.SaveChanges();
            return RedirectToAction("TaskBoard", "HomeBoard");
        }

        [HttpGet]
        public ActionResult AddCustomerCardWork(int id)
        {
            var customerCard = context.müsteriKarts.Find(id);
            ViewBag.Name = customerCard.ProjeNo;
            ViewBag.Time = customerCard.TeknikST;
            ViewBag.Risk = customerCard.Risk;
            ViewBag.deger4 = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomerCardWork(MüsteriKartIsTakibi müsteriKartIsTakibi)
        {
            context.müsteriKartIsTakibis.Add(müsteriKartIsTakibi);
            int id = müsteriKartIsTakibi.MüsteriKartId;
            context.SaveChanges();
            return RedirectToAction("AddCustomerCardWork", "CustomerCard", new { id });
        }

        public PartialViewResult WorkTable(int id)
        {
            var tableWork = context.müsteriKartIsTakibis.Where(x => x.MüsteriKartId == id).ToList();
            return PartialView(tableWork);
        }

        public PartialViewResult TechnicalCard(int id)
        {
            var card = context.teknikKarts.Where(x => x.MüsteriKartId == id).ToList();
            return PartialView(card);
        }

        public ActionResult GetCard(int id)
        {
            var getCard = context.müsteriKarts.Find(id);

            var type = getCard.IslemTipi;
            var priority = getCard.Oncelik;

            ViewBag.check = "";
            ViewBag.check1 = "";
            ViewBag.check2 = "";
            ViewBag.check3 = "";

            switch (type)
            {
                case "yeni":
                    ViewBag.check = "checked";
                    break;
                case "duzeltme":
                    ViewBag.check1 = "checked";
                    break;
                case "gelistirme":
                    ViewBag.check2 = "checked";
                    break;
                case "testsenaryosu":
                    ViewBag.check3 = "checked";
                    break;
            }

            ViewBag.priorityTechnical = "";
            ViewBag.priorityCustomer = "";

            switch (priority)
            {
                case "teknik":
                    ViewBag.priorityTechnical = "checked";
                    break;
                case "musteri":
                    ViewBag.priorityCustomer = "checked";
                    break;
            }


            return View("GetCard", getCard);
        }

        public ActionResult UpdateCard(MüsteriKart müsteriKart)
        {
            var updateCard = context.müsteriKarts.Find(müsteriKart.ID);
            updateCard.Oncelik = müsteriKart.Oncelik;
            updateCard.IslemTipi = müsteriKart.IslemTipi;
            updateCard.KartNo = müsteriKart.KartNo;
            updateCard.ProjeNo = müsteriKart.ProjeNo;
            updateCard.ReferansNo = müsteriKart.ReferansNo;
            updateCard.Risk = müsteriKart.Risk;
            updateCard.Tarih = müsteriKart.Tarih;
            updateCard.TeknikST = müsteriKart.TeknikST;
            updateCard.DolduranMusteri = müsteriKart.DolduranMusteri;
            updateCard.DolduranBimar = müsteriKart.DolduranBimar;
            updateCard.EkDokuman = müsteriKart.EkDokuman;
            updateCard.IsinAciklamasi = müsteriKart.IsinAciklamasi;
            updateCard.Notlar = müsteriKart.Notlar;
            context.SaveChanges();
            return RedirectToAction("TaskBoard", "HomeBoard");
        }

        public ActionResult CardDetail(int id)
        {
            var getCard = context.müsteriKarts.Find(id);

            ViewBag.type = getCard.IslemTipi;
            ViewBag.first = getCard.Oncelik;

            return View("CardDetail", getCard);
        }

        public ActionResult DeleteWorkFollow(int id)
        {
            var cardId = context.müsteriKartIsTakibis.Find(id);
            context.müsteriKartIsTakibis.Remove(cardId);
            context.SaveChanges();
            return RedirectToAction("AddCustomerCardWork", "CustomerCard", new { id = cardId.MüsteriKartId });
        }

    }
}