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
        //public ActionResult ReportSemana()
        //{
        //    IssuesReport issueReport = new IssuesReport();
        //    byte[] abytes = issueReport.PrepareReport(GetIssuesSemana());
        //    return File(abytes, "application/pdf");
        //}
        //public List<Issue> GetIssues()
        //{
        //    List<Issue> issues = new List<Issue>();
        //    Issue issue = new Issue();
        //    for (int i = 1; i <= 6; i++)
        //    {
        //        issue = new Issue();
        //        issue.Id = i;
        //        issue.CreadaPorId = "Creada Por " + i;
        //        issue.Titulo = "Titulo " + i;
        //        issues.Add(issue);
        //    }
        //    return issues;
        //}
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

                //fecha creada string lo uso para pasar desde hasta en string
                //if (issue.FechaCerrada != null)
                //{
                //    issue.FechaCreadaString = "De " + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month + " a " + issue.FechaCerrada.Value.Day + "/" + issue.FechaCerrada.Value.Month;
                //}
                //else
                //{
                //    issue.FechaCreadaString = "De " + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month + " a ";
                //}



                Tarea.CreadaPorId = "Creada por " + issue.CreadaPor.Nombre + " el " + issue.FechaCreada;
                //if(issue.CerradaPor !=null)
                //    Tarea.CerradaPorId = "Cerrada por " + issue.CreadaPor.Nombre;
                //Tarea.CerradaPorId = "Abierto";
                //estado
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
                //cuando esté abierta

                //fin cuando esté abierta
                //    if (issue.TecnicoAsignadoId != null && issue.CerradaPorId != null)
                //    {
                //        issue.CerradaPorId = "Cerró: " + issue.CerradaPor.Nombre + " el "+issue.FechaCerrada;

                //    }


                //}else
                //{
                //    if(issue.TecnicoAsignadoId != null)
                //        issue.CerradaPorId = "En curso por: " + issue.TecnicoAsignado.Nombre;

                //    issue.CerradaPorId = "Seguido por: " + issue.CreadaPor.Nombre;

                //}

                //estadofin


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
        //public List<Issue> GetIssuesHoy(string desde, string hasta)

        //{
        //    DateTime DateDesde = DateTime.ParseExact(desde,
        //               "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        //    DateTime DateHasta = DateTime.ParseExact(hasta,
        //                "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        //    var issues = _context.Issue
        //        .Include(m => m.Clientes)
        //        .Include(m => m.CreadaPor)
        //        .Include(m => m.CerradaPor)
        //        .Include(m => m.TecnicoAsignado)

        //        .Where(m => m.FechaCreada > DateDesde && m.FechaCreada < DateHasta)
        //        .OrderBy(m => m.CreadaPor.Nombre)
        //        .ToList();

        //    List<Issue> lista = new List<Issue>();
        //    Issue Tarea = new Issue();
        //    foreach (var issue in issues)
        //    {
        //        Tarea = new Issue();
        //        //fecha creada string lo uso para pasar desde hasta en string
        //        if (issue.FechaCerrada != null)
        //        {
        //            issue.FechaCreadaString = "De " + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month + " a " + issue.FechaCerrada.Value.Day + "/" + issue.FechaCerrada.Value.Month;
        //        }
        //        else
        //        {
        //            issue.FechaCreadaString = "De " + issue.FechaCreada.Value.Day + "/" + issue.FechaCreada.Value.Month + " a ";
        //        }



        //        Tarea.CreadaPorId = "Creada por " + issue.CreadaPor.Nombre;
        //        //if(issue.CerradaPor !=null)
        //        //    Tarea.CerradaPorId = "Cerrada por " + issue.CreadaPor.Nombre;
        //        //Tarea.CerradaPorId = "Abierto";
        //        if (issue.CerradaPorId == null)
        //            issue.CerradaPorId = "Abierto";
        //        else
        //        {
        //            issue.CerradaPorId = issue.CreadaPor.Nombre;
        //        }
        //        if (issue.TecnicoAsignadoId == null)
        //            issue.TecnicoAsignadoId = "Sin asignar";
        //        else
        //        {
        //            issue.TecnicoAsignadoId = issue.TecnicoAsignado.Nombre;
        //        }

        //        Tarea.Titulo = issue.Titulo;
        //        //uso fechacerradastring para pasar el link porque no tenia otro campo libre
        //        issue.FechaCerradaString = "http://tecnicos.danaide.com.ar/issues/historialissue/" + issue.Id;
        //        Tarea.Titulo = "Titulo " + issue.Clientes.Nombre;
        //        if (issue.TiempoDedicado == null)
        //            issue.TiempoDedicado = 0.ToString();

        //        lista.Add(issue);
        //    }
        //    return issues;
        //}
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


            //return Json(new { data = objetoFinal }, JsonRequestBehavior.AllowGet);
            return Json(new { objetoFinal }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EstadisticasPorClienteTotal()
        {
            var objetoFinal = new ListIntListString();
            var arrayLabels = new List<String>();
            var arrayValues = new List<int>();
            var todosLosClientes = _context.Clientes.ToList();

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

            var total = _context.Issue.Count();

            objetoFinal.Total = total.ToString();
            objetoFinal.Strings = arrayLabels;
            objetoFinal.Ints = arrayValues;
            return Json(new { objetoFinal }, JsonRequestBehavior.AllowGet);

        }
        #endregion

    }
}