using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.ViewModels;
using Inspinia_MVC5_SeedProject.Dtos;
using Inspinia_MVC5_SeedProject.CustomObjects;
using System.Globalization;
namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class AdminController : Controller
    {
        #region context
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminEstadosTickets()
        {
            return View();
        }

        public ActionResult HorasExtras()
        {
            List<HsExtrasIndex> objetoFinal = new List<HsExtrasIndex>();
            var HorasExtrasGroupedByUser = _context.HorasExtras.GroupBy(u => u.UsuarioId)
                                      .Select(grp => new { GroupID = grp.Key, ListaHoras = grp.Where(m => m.Fecha.Value.Month == DateTime.Now.Month).ToList() })
                                      .ToList();
            foreach (var grupo in HorasExtrasGroupedByUser)
            {
                int cantNormales = 0;
                int cantFinDeSemana = 0;
                var UsuarioySusHoras = new HsExtrasIndex();
                UsuarioySusHoras.Horas = new List<HorasExtras>();
                UsuarioySusHoras.Usuario = _context.Users.Single(m => m.Id == grupo.GroupID);
                foreach (var hora in grupo.ListaHoras)
                {

                    if (hora.UsuarioId == grupo.GroupID)
                        UsuarioySusHoras.Horas.Add(hora);
                    if (hora.TipoHoraExtraNombre == "Fin de semana")
                        cantFinDeSemana = cantFinDeSemana + hora.Cantidad;
                    //cantFinDeSemana++;
                    else
                        cantNormales = cantNormales + hora.Cantidad;
                    //cantNormales++;
                }
                UsuarioySusHoras.CantHorasFinDeSemana = cantFinDeSemana;
                UsuarioySusHoras.CantHorasNormales = cantNormales;
                objetoFinal.Add(UsuarioySusHoras);
            }
            var viewmodel = new HorasExtrasViewModel
            {
                VistaHsExtrasModel = objetoFinal,
                NombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month)

            };

            return View(viewmodel);
        }


    }
}