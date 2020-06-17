using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.SqlClient;
using Inspinia_MVC5_SeedProject.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Inspinia_MVC5_SeedProject.Dtos;


namespace Inspinia_MVC5_SeedProject.Controllers.Api
{
    public class IssuesPmApiController : ApiController
    {

        #region context
        private ApplicationDbContext _context;
        public IssuesPmApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        [HttpGet]
        //[Route("Api/ClientesApi/todasLasCamarasMalvinas")]
        public IHttpActionResult todosLosIssues()
        {
            var userId = User.Identity.GetUserId();
            var Usuario = _context.Users.Single(m => m.Id == userId);
            var clientesDePm = _context.RelacionesClientes.Where(m => m.TecnicoId == userId).ToList();

            var ListIdClientes = new List<int>();

            foreach (var cliente in clientesDePm)
            {
                ListIdClientes.Add(cliente.ClientesId);
            }

            var misClientes = _context.RelacionesClientes.Where(m => m.TecnicoId == userId).ToList();
            //.Any(m=> m.AreaTecnicos.Id == ListIDareas.Any)
            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                .Include(m => m.TecnicoAsignado)
                .ToList();
            var filtro1 = issues.Where(t => ListIdClientes.Contains(t.ClientesId));

            var filtro4 = filtro1.Where(m => m.EstadoIssue.Nombre != "Finalizado").ToList();

            foreach (var issue in filtro4)
            {
                if (issue.Titulo.Length > 21)
                    issue.Titulo = issue.Titulo.Substring(0, 20) + "...";

                issue.FechaCreadaString = String.Format("{0:d/M/yyyy}", issue.FechaCreada);
                //issue.FechaCreada = issue.FechaCreada.Value.Date;
                issue.VecesReclamado = _context.MensajesIssue.Where(m => m.IssueId == issue.Id).Count();
            }

            return Ok(filtro4);
        }

    }
}
