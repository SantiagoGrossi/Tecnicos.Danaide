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
    public class PendientesComunitariasApiController : ApiController
    {
        #region context
        private ApplicationDbContext _context;
        public PendientesComunitariasApiController()
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
        public IHttpActionResult todoslosPendientes()
        {


            var pendientes = _context.PendientesMesa

                .Include(m => m.EstadoIssue)

                .Include(m => m.Clientes)
                .Include(m => m.CreadaPor)
                //.Include(m => m.CerradaPor)

                .Where(m => m.EstadoIssue.Nombre != "Finalizado")

                .ToList();
            foreach (var pendiente in pendientes)
            {
                // issue.Titulo = issue.Titulo.Substring(0, 10) + "...";

                pendiente.FechaCreadaString = String.Format("{0:d/M/yyyy}", pendiente.FechaCreada);
                //issue.FechaCreada = issue.FechaCreada.Value.Date;
            }
            return Ok(pendientes);
        }



        [HttpPatch]
        public IHttpActionResult enviarAporte(AreaTecnicoDto dto)
        {
            var pendienteobjeto = _context.PendientesMesa.Single(m => m.Id == dto.IssueId);
            //validaciones
            if (dto.Nombre == null)
                dto.Nombre = "";
            if (dto.stringGenerico == null)
                dto.stringGenerico = "1";
            // fin validaciones
            _context.Configuration.ValidateOnSaveEnabled = false;
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(m => m.Id == userId);

            var aporte = new AporteComunitaria
            {
                Descripcion = dto.stringGenerico,
                TiempoDedicado = dto.Nombre,
                FechaAporte = DateTime.Now,
                AportanteId = userId,
                PendientesMesaId = dto.IssueId,

            };
            var mensaje = new MensajesPendientes
            {
                FechaCreado = DateTime.Now,
                PendientesMesaId = dto.IssueId,
                UsuarioId = userId,
                Mensaje = "El usuario " + user.Nombre + " ha aportado " + dto.Nombre + " minutos en: " + dto.stringGenerico
            };

            //creacion issue
            int? ultimonumero = _context.Issue.ToList().Last().NumeroIssue.Value;
            ultimonumero++;
            var cliente = _context.Clientes.SingleOrDefault(m => m.Id == pendienteobjeto.ClientesId);

            var issue = new Issue
            {
                CreadaPorId = userId,
                CerradaPorId = userId,
                VecesReclamado = 1,
                FechaCreada = DateTime.Now,
                FechaCreadaString = DateTime.Now.ToString(),
                EstadoIssueId = _context.EstadoIssue.SingleOrDefault(m => m.Nombre == "Finalizado").Id,
                TiempoDedicado = dto.Nombre.ToString(),
                NumeroIssue = ultimonumero,
                ClientesId = cliente.Id,
                AreaTecnicosId = _context.AreaTecnicos.SingleOrDefault(m => m.Nombre == "Sin especificar").Id,
                Titulo = "Aporté a la tarea programada número " + dto.IssueId + " :" + pendienteobjeto.Titulo,
                CriticidadIssueId = _context.CriticidadIssue.SingleOrDefault(m => m.Nombre == "Bajo").Id



            };


            _context.Issue.Add(issue);
            _context.MensajesPendientes.Add(mensaje);
            _context.AporteComunitaria.Add(aporte);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult cerrarPendiente(int id)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;
            var pendiente = _context.PendientesMesa.SingleOrDefault(m => m.Id == id);
            if (pendiente != null)
                pendiente.EstadoIssueId = _context.EstadoIssue.SingleOrDefault(m => m.Nombre == "Finalizado").Id;
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult crearPendienteComunitaria(Dtos.nuevaIssueDto issuedto)
        {
            string currentUserId = User.Identity.GetUserId();
            _context.Configuration.ValidateOnSaveEnabled = false;
            var pendientesMesa = new PendientesMesa();





            pendientesMesa.CreadaPorId = currentUserId;
            pendientesMesa.FechaCreada = DateTime.Now;
            pendientesMesa.FechaCreadaString = DateTime.Now.ToString();
            pendientesMesa.EstadoIssueId = _context.EstadoIssue.Single(m => m.Nombre == "Abierto").Id;

            pendientesMesa.ClientesId = _context.Clientes.Single(m => m.Nombre == issuedto.NombreCliente).Id;
            pendientesMesa.Titulo = issuedto.Titulo;
            pendientesMesa.Descripcion = issuedto.Resumen;
            _context.PendientesMesa.Add(pendientesMesa);

            _context.SaveChanges();
            //if (issuedto.TecnicoAsignadoId != null)
            //{
            //    MailControler.enviarEmailByNumber(dto);
            //}

            return Ok();
        }

    }
}
