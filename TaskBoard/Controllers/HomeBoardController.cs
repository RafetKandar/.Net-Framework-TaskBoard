using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskBoard.Models.Classes;

namespace TaskBoard.Controllers
{
    public class HomeBoardController : Controller
    {
        Context context = new Context();

        // GET: HomeBoard
        public ActionResult TaskBoard()
        {
            return View();
        }
        public PartialViewResult CustomerCard()
        {
            var customeCard = context.müsteriKarts.ToList();
            return PartialView(customeCard);
        }

        public PartialViewResult ToDoCard()
        {
            var toDo = context.teknikKarts.ToList();
            return PartialView(toDo);
        }
    }
}