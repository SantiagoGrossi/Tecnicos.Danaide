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
    public class IssuesTecnicosApiController : ApiController
    {

        #region context
        private ApplicationDbContext _context;
        public IssuesTecnicosApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        [HttpGet]
        [Authorize]
        //[Route("Api/ClientesApi/todasLasCamarasMalvinas")]
        public IHttpActionResult todosLosIssues()
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
            var filtro2 = filtro1.Where(t => ListIDareas.Contains(t.AreaTecnicosId));


            var filtro3 = filtro2.Where(m => m.TecnicoAsignadoId == userId || m.TecnicoAsignadoId == null);
            var filtro4 = filtro3.Where(m => m.EstadoIssue.Nombre != "Finalizado").ToList();
            foreach (var issue in filtro4)
            {
                if (issue.Titulo.Length>21)
                    issue.Titulo = issue.Titulo.Substring(0, 20) + "...";


                issue.FechaCreadaString = String.Format("{0:d/M/yyyy}", issue.FechaCreada);
                //issue.FechaCreada = issue.FechaCreada.Value.Date;
                issue.VecesReclamado = _context.MensajesIssue.Where(m => m.IssueId == issue.Id).Count();
            }
            return Ok(filtro4);
        }
        [HttpPatch]

        public IHttpActionResult tomarIssue(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(m => m.Id == userId);
            //mensaje
            var mensaje = new MensajesIssue
            {
                FechaCreado = DateTime.Now,
                IssueId = id,
                UsuarioId = userId,
                Mensaje = "El usuario " + user.Nombre + " ha tomado la tarea"
            };
            //issue
            _context.Configuration.ValidateOnSaveEnabled = false;
            
            
            
            
            var issue = _context.Issue.SingleOrDefault(m => m.Id == id);
            if (issue.TecnicoAsignadoId != null)
            {
                return BadRequest("La tarea ya está tomada!");
            }
            issue.TecnicoAsignadoId = userId;
            issue.EstadoIssueId = _context.EstadoIssue.SingleOrDefault(m => m.Nombre == "En proceso").Id;
            _context.MensajesIssue.Add(mensaje);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IHttpActionResult desligarse(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(m => m.Id == userId);
            var mensaje = new MensajesIssue
            {
                FechaCreado = DateTime.Now,
                IssueId = id,
                UsuarioId = userId,
                Mensaje = "El usuario " + user.Nombre + " ha dejado la tarea"
            };
            _context.Configuration.ValidateOnSaveEnabled = false;
            //var userId = User.Identity.GetUserId();

            var issue = _context.Issue.SingleOrDefault(m => m.Id == id);
            //if (issue.TecnicoAsignadoId == null)
            //{
            //    return BadRequest("La tarea ya está tomada!");
            //}
            issue.TecnicoAsignadoId = null;
            issue.EstadoIssueId = _context.EstadoIssue.SingleOrDefault(m => m.Nombre == "Abierto").Id;
            _context.MensajesIssue.Add(mensaje);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult asignarTecnico(AreaTecnicoDto dto)
        {
            var MailControler = new MailController();
            //currentuser
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(m => m.Id == userId);


            if (dto.Nombre == null)
            {
                var issue = _context.Issue.Single(m => m.Id == dto.Id);
                issue.TecnicoAsignado = null;
                issue.TecnicoAsignadoId = null;
                var mensaje = new MensajesIssue
                {
                    FechaCreado = DateTime.Now,
                    IssueId = dto.Id,
                    UsuarioId = userId,
                    Mensaje = "El usuario " + dto.Nombre + " ha dejado la tarea libre"
                };
                _context.MensajesIssue.Add(mensaje);

            }
            else
            {
                var userTecnico = _context.Users.Single(m => m.Id == dto.Nombre);
                var issue = _context.Issue.Single(m => m.Id == dto.Id);
                issue.TecnicoAsignadoId = dto.Nombre;
                var mensaje = new MensajesIssue
                {
                    FechaCreado = DateTime.Now,
                    IssueId = dto.Id,
                    UsuarioId = dto.Nombre,
                    Mensaje = "El usuario " + user.Nombre + " ha asignado la tarea a " + userTecnico.Nombre

                };
                MailControler.enviarEmail(dto);
                _context.MensajesIssue.Add(mensaje);
            }

            _context.Configuration.ValidateOnSaveEnabled = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}
