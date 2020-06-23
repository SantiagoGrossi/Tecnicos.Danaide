using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.PdfReport;
using System.Data.Entity;
using Inspinia_MVC5_SeedProject.CustomObjects;
using System.Globalization;
namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class ReportesController : Controller
    {

        #region context
        private ApplicationDbContext _context;
        public ReportesController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }
        #region diaactual
        public ActionResult ReportHoy(DesdeHasta desdehasta)
        {
            #region null?
            if (desdehasta.Hasta == null)
            {
                desdehasta.Hasta = DateTime.Now.ToString("MM/dd/yyyy");
            }
            if (desdehasta.Desde == null)
            {
                desdehasta.Desde = DateTime.Now.ToString("MM/dd/yyyy");
            }
            #endregion
            #region normalizar
            string resultadoDesde = desdehasta.Desde.Substring(0, 10);
            resultadoDesde = resultadoDesde + " 00:01:00";

            string resultadoHasta = desdehasta.Hasta.Substring(0, 10);
            resultadoHasta = resultadoHasta + " 23:59:59";
            #endregion


            IssuesReport issueReport = new IssuesReport();
            byte[] abytes = issueReport.PrepareReport(resultadoDesde, resultadoHasta, GetIssuesHoy(resultadoDesde, resultadoHasta));

            return File(abytes, "application/pdf");
        }
        
        public List<Issue> GetIssuesSemana()
        {
            var issues = _context.Issue
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.CerradaPor)
                .Include(m => m.TecnicoAsignado)
                 //.Where(m => m.FechaCreada.Value.Day == DateTime.Now.Day && m.FechaCreada.Value.Month == DateTime.Now.Month)
                 .Where(m => m.FechaCreada.Value.Month == DateTime.Now.Month)
                .OrderBy(m => m.CreadaPor.Nombre)
                .ToList();

            List<Issue> lista = new List<Issue>();
            Issue Tarea = new Issue();
            foreach (var issue in issues)
            {
                Tarea = new Issue();
                Tarea.CreadaPorId = "Creada por " + issue.CreadaPor.Nombre;
                //if(issue.CerradaPor !=null)
                //    Tarea.CerradaPorId = "Cerrada por " + issue.CreadaPor.Nombre;
                //Tarea.CerradaPorId = "Abierto";
                if (issue.CerradaPorId == null)
                    issue.CerradaPorId = "Abierto";
                else
                {
                    issue.CerradaPorId = issue.CreadaPor.Nombre;
                }
                if (issue.TecnicoAsignadoId == null)
                    issue.TecnicoAsignadoId = "Sin asignar";
                else
                {
                    issue.TecnicoAsignadoId = issue.TecnicoAsignado.Nombre;
                }

                Tarea.Titulo = issue.Titulo;
                issue.FechaCerradaString = "http://tecnicos.danaide.com.ar/issues/historialissue/" + issue.Id;
                Tarea.Titulo = "Titulo " + issue.Clientes.Nombre;
                lista.Add(issue);
            }
            return issues;
        }
        #endregion
        #region semana

        public List<Issue> GetIssuesHoy(string desde, string hasta)

        {
            DateTime DateDesde = DateTime.ParseExact(desde,
                       "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime DateHasta = DateTime.ParseExact(hasta,
                        "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            var issues = _context.Issue
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.CerradaPor)
                .Include(m => m.TecnicoAsignado)

                .Where(m => m.FechaCreada > DateDesde && m.FechaCreada < DateHasta)
                .OrderBy(m => m.CreadaPor.Nombre)
                .ToList();

            List<Issue> lista = new List<Issue>();
            Issue Tarea = new Issue();
            foreach (var issue in issues)
            {
                //var mensaje = _context.MensajesIssue.Single(m => m.IssueId == issue.Id);
                Tarea = new Issue();
                issue.CreadaPorId = issue.CreadaPor.Nombre + " el " + issue.FechaCreada;

                



                Tarea.CreadaPorId = "Creada por " + issue.CreadaPor.Nombre + " el " + issue.FechaCreada;
                
                if (issue.CerradaPorId != null)
                {

                    issue.FechaCerradaString = "Cerrada por " + issue.CerradaPor.Nombre + " el " + issue.FechaCerrada;
                }
                else
                {
                    if (issue.CerradaPorId == null)
                    {
                        if (issue.TecnicoAsignadoId != null)
                        {
                            issue.FechaCerradaString = "En curso por: " + issue.TecnicoAsignado.Nombre;
                        }
                        if (issue.TecnicoAsignadoId == null)
                        {
                            issue.FechaCerradaString = "En curso por mesa";
                        }
                    }
                }
                


                if (issue.TecnicoAsignadoId == null)
                    issue.TecnicoAsignadoId = "Sin asignar";
                else
                {
                    issue.TecnicoAsignadoId = issue.TecnicoAsignado.Nombre;
                }

                //issue.FechaCerradaString = @"< a href = ""http://tecnicos.danaide.com.ar/issues/historialissue/" + issue.Id + @" > "+issue.Titulo+"</ a >";
                //uso fechacerradastring para pasar el link porque no tenia otro campo libre
                issue.FechaCreadaString = "http://tecnicos.danaide.com.ar/issues/historialissue/" + issue.Id;
                Tarea.Titulo = "Titulo " + issue.Clientes.Nombre;
                if (issue.TiempoDedicado == null)
                    issue.TiempoDedicado = 0.ToString();
                else
                    issue.TiempoDedicado = issue.TiempoDedicado + " min";

                lista.Add(issue);
            }
            return issues;
        }
        
        #endregion

        public ActionResult EstadisticasHoy()
        {
            return View();
        }

        #region estadisdicas
        public ActionResult EstadisticasHoyPorCliente()
        {
            var objetoFinal = new ListIntListString();
            var arrayLabels = new List<String>();
            var arrayValues = new List<int>();
            var todosLosClientes = _context.Clientes.ToList();
            var objeto = _context.Issue.GroupBy(u => u.Clientes.Nombre)
                                      .Select(grp => new { nombreCliente = grp.Key, cantTareasHoy = grp.Where(m => m.FechaCreada.Value.Day == DateTime.Now.Day && m.FechaCreada.Value.Month == DateTime.Now.Month).Count() })
                                      .ToList();

            foreach (var clienteGroupedByName in objeto)
            {
                if (clienteGroupedByName.cantTareasHoy > 0)
                {
                    arrayLabels.Add(clienteGroupedByName.nombreCliente);
                    arrayValues.Add(clienteGroupedByName.cantTareasHoy);
                }
            }

            var total = _context.Issue.Where(m => m.FechaCreada.Value.Day == DateTime.Now.Day && m.FechaCreada.Value.Month == DateTime.Now.Month).Count();
            objetoFinal.Strings = arrayLabels;
            objetoFinal.Ints = arrayValues;
            objetoFinal.Total = total.ToString();
            objetoFinal.Total.ToString();


            return Json(new { objetoFinal }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EstadisticasPorClienteTotal(string Desde, string Hasta)
        {
            var objetoFinal = new ListIntListString();
            var arrayLabels = new List<String>();
            var arrayValues = new List<int>();
            var todosLosClientes = _context.Clientes.ToList();
           
            //if(Desde != null & Hasta != null)
                if ((Desde != null && Desde!="") & (Hasta != null && Hasta!= ""))
                {

                #region normalizar
                string resultadoDesde = Desde.Substring(0, 10);
                resultadoDesde = resultadoDesde + " 00:01:00";

                string resultadoHasta = Hasta.Substring(0, 10);
                resultadoHasta = resultadoHasta + " 23:59:59";
                #endregion
                //conversión
                Desde = DateTime.Now.ToString("MM/dd/yyyy");
                Hasta = DateTime.Now.ToString("MM/dd/yyyy");

                DateTime DateDesde = DateTime.ParseExact(resultadoDesde,
                       "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime DateHasta = DateTime.ParseExact(resultadoHasta,
                       "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


                

                var objeto = _context.Issue
                    .Where(m => m.FechaCreada > DateDesde && m.FechaCreada < DateHasta)
                    .GroupBy(u => u.Clientes.Nombre)
                                      .Select(grp => new { nombreCliente = grp.Key, cantTareasHoy = grp.Count() })
                                      .ToList();
                foreach (var clienteGroupedByName in objeto)
                {
                    if (clienteGroupedByName.cantTareasHoy > 0)
                    {
                        arrayLabels.Add(clienteGroupedByName.nombreCliente);
                        arrayValues.Add(clienteGroupedByName.cantTareasHoy);
                    }
                }

            }
            else
            {
                var objeto = _context.Issue.GroupBy(u => u.Clientes.Nombre)
                                                      .Select(grp => new { nombreCliente = grp.Key, cantTareasHoy = grp.Count() })
                                                      .ToList();
                foreach (var clienteGroupedByName in objeto)
                {
                    if (clienteGroupedByName.cantTareasHoy > 0)
                    {
                        arrayLabels.Add(clienteGroupedByName.nombreCliente);
                        arrayValues.Add(clienteGroupedByName.cantTareasHoy);
                    }
                }

            }


            var total = _context.Issue.Count();

            objetoFinal.Total = total.ToString();
            objetoFinal.Strings = arrayLabels;
            objetoFinal.Ints = arrayValues;
            return Json(new { objetoFinal }, JsonRequestBehavior.AllowGet);

        }
        #endregion

    }
}