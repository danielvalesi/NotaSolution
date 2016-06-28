using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotaWeb.Filtros;
using NotaWeb.Models;

namespace NotaWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Autorizacao]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio(int id)
        {
            using (DashboardModel model = new DashboardModel())
            {
                return View(model.Relatorio(id));
            }

        }


    }
}