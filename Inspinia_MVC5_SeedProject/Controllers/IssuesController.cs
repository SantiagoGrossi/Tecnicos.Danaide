using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.ViewModels;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Script.Serialization;
namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class IssuesController : Controller
    {

        #region context
        private ApplicationDbContext _context;
        public IssuesController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        // GET: Issues
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Todas()
        {
            return View();
        }

        public ActionResult MesaSinAsignar()
        {
            return View();
        }

        public ActionResult MesaSinAsignarTabla()
        {
            var lista = new List<Issue>();
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.CerradaPor)
                .Include(m => m.TecnicoAsignado)
            .Where(m => m.EstadoIssue.Nombre == "Abierto"
            && m.TecnicoAsignado == null
            );


            foreach (var issue in issues)
            {
                issue.FechaCreadaString = "" + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month;
                lista.Add(issue);
            }
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TodasCerradas()
        {
            var lista = new List<Issue>();
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.CerradaPor)
                .Include(m => m.TecnicoAsignado);
                
            foreach (var issue in issues)
            {
                issue.FechaCreadaString = "" + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month;
                lista.Add(issue);
            }
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cerradas()
        {
            return View();
        }
        public ActionResult TareasCerradas()
        {
            var lista = new List<Issue>();
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.CerradaPor)
                .Include(m => m.TecnicoAsignado)
                .Where(m => m.EstadoIssue.Nombre == "Finalizado").ToList();
            foreach (var issue in issues)
            {
                issue.FechaCreadaString = "" + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month;
                lista.Add(issue);
            }
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //var serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = 500000000;
            //return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResumenDeHoy(string id)
        {
            var viewmodel = new CustomObjects.GenericoUnString
            {
                stringGenerico = id
            };
            return View(viewmodel);
        }
        public ActionResult ResumenDeHoyTabla (string id)
        {
            var lista = new List<Issue>();
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)

                .Include(m => m.TecnicoAsignado)
                .Where(m => m.FechaCreada.Value.Day == DateTime.Now.Day 
                && m.FechaCreada.Value.Month == DateTime.Now.Month).ToList();
            foreach (var issue in issues)
            {
                issue.FechaCreadaString="" + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month;
                lista.Add(issue);
            }
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult tareasPorUsuario(string id)
        {
            var viewmodel = new CustomObjects.GenericoUnString
            {
                stringGenerico = id
            };
            return View(viewmodel);
        }
        public ActionResult tareasPorUsuarioTabla(string id)
        {
            var lista = new List<Issue>();
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)

                .Include(m => m.TecnicoAsignado)
                .Where(m => m.CreadaPorId == id || m.TecnicoAsignadoId == id)
                .ToList();
            foreach(var issue in issues)
            {
                issue.FechaCreadaString = "" + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month +"/" + issue.FechaCreada.Value.Year;
                lista.Add(issue);
            }
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IndexIssuesAdmin()
        {
            var currentUserId = User.Identity.GetUserId();
            var todaslasIssues = _context.Issue.Where(m => m.EstadoIssue.Nombre != "Finalizado");
            var users = _context.Users.ToList();
            var sinasignar = todaslasIssues.Where(m => m.TecnicoAsignadoId == null && m.EstadoIssue.Nombre != "Finalizado").Count();
            //var cantEnProceso = todaslasIssues.Where(m => m.EstadoIssue.Nombre == "En proceso").Count();
            var cantEnProceso = todaslasIssues.Where(m => m.EstadoIssue.Nombre != "Finalizado" && m.TecnicoAsignadoId != null).Count();

            var mias = todaslasIssues.Where(m => m.TecnicoAsignadoId == currentUserId).Count();
            var viewmodel = new IndexIssuesTecnicosViewModel
            {
                Usuarios = users,
                CantDisponibles = sinasignar,
                CantPendientes = cantEnProceso,
                Mias = mias
            };
            return View(viewmodel);
        }
        public ActionResult IndexIssuesPm()
        {
            var todaslasIssues = _context.Issue.Where(m => m.EstadoIssue.Nombre != "Finalizado");

            var userId = User.Identity.GetUserId();
            var Usuario = _context.Users.Single(m => m.Id == userId);
            var clientesDePm = _context.RelacionesClientes.Where(m => m.TecnicoId == userId).ToList();
            var ListIdClientes = new List<int>();
            var mias = todaslasIssues.Where(m => m.TecnicoAsignadoId == userId).Count();

            foreach (var cliente in clientesDePm)
            {
                ListIdClientes.Add(cliente.ClientesId);
            }
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.TecnicoAsignado)
                .ToList();
            var filtro1 = issues.Where(t => ListIdClientes.Contains(t.ClientesId));


            var sinasignar = filtro1.Where(m => m.TecnicoAsignadoId == null && m.EstadoIssue.Nombre != "Finalizado");
            var cantEnProceso = filtro1.Where(m => m.EstadoIssue.Nombre != "Finalizado" && m.TecnicoAsignadoId != null).Count();

            var users = _context.Users.ToList();
            var viewmodel = new IndexIssuesTecnicosViewModel
            {
                Usuarios = users,
                CantDisponibles = sinasignar.Count(),
                CantPendientes = cantEnProceso,
                Mias = mias
            };
            return View(viewmodel);
        }
        public ActionResult historialissuebyNumber(int id)
        {
            var issue = _context.Issue
                .Include(m => m.Clientes)
                .Include(m => m.AreaTecnicos)
                .Include(m => m.CreadaPor)

                .Include(m => m.AreaTecnicos)
                .Single(m => m.NumeroIssue == id)
                ;
            var mensajesIssue = _context.MensajesIssue
                .Include(m => m.Usuario)
                .Where(m => m.IssueId == issue.Id)
                .OrderBy(m => m.FechaCreado)
                .ToList();

            var viewmodel = new MensajesViewModel
            {
                ListaMensajes = mensajesIssue,
                TituloIssue = issue.Titulo,
                Idissue = issue.Id,
                Issue = issue
            };
            return View(viewmodel);
        }
        public ActionResult historialissue(int id)
        {
            var issue = _context.Issue
                .Include(m=> m.Clientes)
                .Include(m => m.AreaTecnicos)
                .Include(m => m.CreadaPor)
                
                .Include(m => m.AreaTecnicos)
                .Single(m => m.Id == id)
                ;
            var mensajesIssue = _context.MensajesIssue
                .Include(m => m.Usuario)
                .Where(m=>m.IssueId ==id)
                .OrderBy(m => m.FechaCreado)
                .ToList();
           
            var viewmodel = new MensajesViewModel
            {
                ListaMensajes = mensajesIssue,
                TituloIssue = issue.Titulo,
                Idissue = id,
                Issue = issue
            };
            return View(viewmodel);
        }
        public ActionResult IndexIssuesTecnicos()
        {
            var userId = User.Identity.GetUserId();
            var Usuario = _context.Users.Single(m => m.Id == userId);
            var misAreas = _context.RelacionesAreas.Where(m => m.TecnicoId == userId).ToList();
            var clientesDeTecnico = _context.RelacionesClientes.Where(m => m.TecnicoId == userId).ToList();
            var ListIDareas = new List<int>();
            var ListIdClientes = new List<int>();
            foreach (var area in misAreas)
            {
                ListIDareas.Add(area.AreasTecnicosId);
            }
            foreach (var cliente in clientesDeTecnico)
            {
                ListIdClientes.Add(cliente.ClientesId);
            }
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.TecnicoAsignado)
                .ToList();
            var filtro1 = issues.Where(t => ListIdClientes.Contains(t.ClientesId));
            var filtro2 = filtro1.Where(t => ListIDareas.Contains(t.AreaTecnicosId));


            var disponibles = filtro2.Where(m => m.TecnicoAsignadoId == null && m.EstadoIssue.Nombre !="Finalizado");
            var pendientes = filtro2.Where(m => m.TecnicoAsignadoId == userId && m.EstadoIssue.Nombre != "Finalizado");


            var viewmodel = new IndexIssuesTecnicosViewModel
            {
                CantDisponibles = disponibles.Count(),
                CantPendientes = pendientes.Count()
            };
            return View(viewmodel);
        }
        public ActionResult IndexIssues()
        {
            if (User.IsInRole("Tecnico"))
                return RedirectToAction("IndexIssuesTecnicos", "Issues");
            if (User.IsInRole("Pm"))
                return RedirectToAction("IndexIssuesPm", "Issues");
            return RedirectToAction("IndexIssuesAdmin", "Issues");
        }


        public ActionResult CrearIssue()
        {
            var viewmodel = new IssueViewmodel
            {
                CriticidadIssue = _context.CriticidadIssue.ToList(),
                AreaTecnicos = _context.AreaTecnicos.ToList(),
                EstadoIssue = _context.EstadoIssue.ToList(),
                Clientes = _context.Clientes.ToList(),
                Usuario = _context.Users.ToList()
               
            };
            return View(viewmodel);
        }

        public ActionResult GuardarIssue(Issue issue)
        {

            string currentUserId = User.Identity.GetUserId();
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new CustomerFormViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = _context.MembershipTypes.ToList()
            //    };

            //    return View("CustomerForm", viewModel);
            //}
            
            
         



            if (issue.Id == 0)
            {
                issue.CreadaPorId = currentUserId;
                issue.VecesReclamado = 1;
                issue.FechaCreada = DateTime.Now;
                issue.FechaCreadaString = DateTime.Now.ToString();
                issue.EstadoIssueId = _context.EstadoIssue.Single(m => m.Nombre == "Abierto").Id;
                
                _context.Issue.Add(issue);
            }
                
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            //    customerInDb.Name = customer.Name;
            //    customerInDb.Birthdate = customer.Birthdate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //}

            _context.SaveChanges();

            return RedirectToAction("IndexIssues", "Issues");
        }

        public ActionResult PendienteComunitaria(int id)
        {
            var pendiente = _context.PendientesMesa
                .Include(m => m.CreadaPor)
                .Include(m => m.CerradaPor)
                .Include(m => m.Clientes)
                .Include(m => m.EstadoIssue)
                .SingleOrDefault(m => m.Id == id);
            var listaMensajes = _context.MensajesPendientes
                .Include(m => m.Usuario)
                .Where(m => m.PendientesMesaId == id);
            var viewmodel = new PendienteComunitaria
            {
                PendientesMesa = pendiente,
                ListaMensajes = listaMensajes.ToList()
            };
            return View(viewmodel);
        }

    }
}