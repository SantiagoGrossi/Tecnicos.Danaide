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
    public class IssuesApiController : ApiController
    {
        #region context
        private ApplicationDbContext _context;
        public IssuesApiController()
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
            

            var issues = _context.Issue
                .Include(m => m.AreaTecnicos)
                .Include(m => m.EstadoIssue)
                .Include(m => m.CriticidadIssue)
                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                //.Include(m => m.CerradaPor)
                .Include(m => m.TecnicoAsignado)

                .Where(m => m.EstadoIssue.Nombre != "Finalizado")

                .ToList();
            foreach (var issue in issues)
            {
                if (issue.Titulo.Length > 21)
                    issue.Titulo = issue.Titulo.Substring(0, 20) + "...";

                issue.FechaCreadaString = String.Format("{0:d/M/yyyy}", issue.FechaCreada);
                //issue.FechaCreada = issue.FechaCreada.Value.Date;
                issue.VecesReclamado = _context.MensajesIssue.Where(m => m.IssueId == issue.Id).Count();
            }
            return Ok(issues);
        }

     

        [HttpPatch]
        public IHttpActionResult cambiarEstadoIssue(AreaTecnicoDto dto)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(m => m.Id == userId);
            var mensaje = new MensajesIssue
            {
                FechaCreado = DateTime.Now,
                IssueId = dto.IssueId,
                UsuarioId = userId,
                Mensaje = "El usuario " + user.Nombre + " ha dado la tarea por finalizada"
            };

            var issue = _context.Issue.SingleOrDefault(m => m.Id == dto.IssueId);
            var falso = _context.EstadoIssue.SingleOrDefault(m => m.Nombre == "Finalizado");
            issue.FechaCerrada = DateTime.Now;
            issue.EstadoIssueId = falso.Id;
            issue.CerradaPorId = userId;
            issue.TiempoDedicado = dto.Tiempo.ToString();

            //resultante
            //TimeSpan result = (DateTime.Now - issue.FechaCreada).GetValueOrDefault();

            _context.MensajesIssue.Add(mensaje);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult crearIssue(Dtos.nuevaIssueDto issuedto)
        {
            var dto = new AreaTecnicoDto();
            var MailControler = new MailController();
            int? ultimonumero = _context.Issue.ToList().Last().NumeroIssue.Value;
            ultimonumero++;

            var issue = new Issue();
            if (issuedto.NombreArea == 0)
            {
                issuedto.NombreArea = 5;
            }
            _context.Configuration.ValidateOnSaveEnabled = false;
            if (issuedto.Criticidad == 0)
                issuedto.Criticidad = 1;
            if (issuedto.TecnicoAsignadoId != null)
            {
                dto.Nombre = issuedto.TecnicoAsignadoId;
                issue.TecnicoAsignadoId = _context.Users.Single(m => m.Id == issuedto.TecnicoAsignadoId).Id;
                dto.Numero = ultimonumero;



            }

            string currentUserId = User.Identity.GetUserId();
            var user = _context.Users.Single(m => m.Id == currentUserId).CantTareasTotal++;

            issue.CreadaPorId = currentUserId;
            issue.VecesReclamado = 1;
            issue.FechaCreada = DateTime.Now;
            issue.FechaCreadaString = DateTime.Now.ToString();
            issue.EstadoIssueId = _context.EstadoIssue.Single(m => m.Nombre == "Abierto").Id;
            issue.TiempoDedicado = issuedto.Minutos.ToString();
            issue.NumeroIssue = ultimonumero;

            issue.ClientesId = _context.Clientes.Single(m => m.Nombre == issuedto.NombreCliente).Id;
            issue.AreaTecnicosId = _context.AreaTecnicos.Single(m => m.Id == issuedto.NombreArea).Id;
            issue.Titulo = issuedto.Titulo;
            issue.Descripcion = issuedto.Resumen;
            issue.CriticidadIssueId = issuedto.Criticidad;
            _context.Issue.Add(issue);

            _context.SaveChanges();
            if (issuedto.TecnicoAsignadoId != null)
            {
                MailControler.enviarEmailByNumber(dto);
            }

            return Ok();
        }

    }
}
