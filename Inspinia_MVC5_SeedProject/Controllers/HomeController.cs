using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.Models;
using System.Data.Entity;
using Inspinia_MVC5_SeedProject.ViewModels;
using Microsoft.AspNet.Identity;
using Inspinia_MVC5_SeedProject.CustomObjects;
using Inspinia_MVC5_SeedProject.Const;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class HomeController : Controller
    {

        #region context
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        //public ActionResult Index()
        //{
        //    if (User.IsInRole("Tecnico"))
        //        return RedirectToAction("IndexIssuesTecnicos", "Issues");
        //    return RedirectToAction("IndexSoporte", "Home");
        //}
        public ActionResult Index()
        {
            if (User.IsInRole(Const.RoleName.Tecnico))
                return RedirectToAction("IndexIssuesTecnicos", "Issues");
            if (User.IsInRole(Const.RoleName.Admin))
                return RedirectToAction("IndexIssuesAdmin", "Issues");
            if (User.IsInRole(Const.RoleName.Pm))
                return RedirectToAction("IndexIssuesPm", "Issues");

            return RedirectToAction("IndexIssuesTecnicos", "Issues");

            //return RedirectToAction("IndexSoporte", "Home");
        }
        public ActionResult transporteUsuario(string idUsuario)
        {
            return View();
        }
        public ActionResult tareasPorUsuario(string idUsuario)
        {
            return View();
        }
        public ActionResult Guardias()
        {
            return View();
        }
        public ActionResult IndexSoporte()
        {
            var todaslasTareas = _context.Issue.ToList();
            var userId = User.Identity.GetUserId();
            var PendientesMesa = _context.PendientesMesa
                .Include(m => m.CreadaPor)
                .Include(m => m.Clientes)
                .Include(m => m.EstadoIssue)
                .Where(m => m.EstadoIssue.Nombre != "Finalizado")
                .ToList();
            //extras
            var lista = new List<HorasExtras>();
            var horas = _context.HorasExtras.Include(m => m.TipoHoraExtra)
                .Where(m => m.Fecha.Value.Month == DateTime.Now.Month && m.UsuarioId == userId)
                .ToList();
            foreach (var hora in horas)
            {
                lista.Add(hora);
            }
            //resumen
            List<ApplicationUser> listaDeUsuarios = new List<ApplicationUser>();
            List<ResumenTareasPorUsuario> Resumen = new List<ResumenTareasPorUsuario>();
            listaDeUsuarios = _context.Users.Where(m => m.EsSoporte == true && m.CantTareasTotal > 0).ToList();

            
                foreach (var usuario in listaDeUsuarios)
                {
                usuario.CantTareasPendientes = _context.Issue.Where(m => m.CreadaPorId == usuario.Id && m.EstadoIssue.Nombre != "Finalizado").Count();
                var TareasDeHoy = todaslasTareas.Where(m => m.FechaCreada.Value.Day == DateTime.Now.Day && m.FechaCreada.Value.Month == DateTime.Now.Month).ToList();
                usuario.CantTareasHoy = TareasDeHoy.Where(m => m.TecnicoAsignadoId == usuario.Id || m.CerradaPorId == usuario.Id).Count();

            }
            
            var misPendientes = _context.Issue.Where(m => m.CreadaPorId == userId && m.EstadoIssue.Nombre != "Finalizado").Count();
            //var misAsignadas = _context.TareasDiarias.Where(m => m.Finalizada == false && m.UsuarioId == userId && m.FueAsignada == true).ToList();
            //
            var viewmodel = new ViewModels.HomeViewModel
            {
                HorasExtras = lista,
                Resumen = listaDeUsuarios,
                PendientesMesa = PendientesMesa,
                intGenerico = PendientesMesa.Count()


            };
            return View(viewmodel);
        }
        public ActionResult cambiarGuardias (string userid, string nuevaFecha)
        {
            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
    }
}