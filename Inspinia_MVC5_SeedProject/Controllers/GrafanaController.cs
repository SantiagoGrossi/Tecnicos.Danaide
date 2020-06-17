using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.CustomObjects;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class GrafanaController : Controller
    {
        // GET: Grafana
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGrafana(string NombreCliente)
        {
            var viewmodel = new CustomObjects.GenericoUnString
            {
                stringGenerico = NombreCliente
            };

            return View(viewmodel);
        }
    }
}