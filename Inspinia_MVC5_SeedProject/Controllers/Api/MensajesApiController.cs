using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Inspinia_MVC5_SeedProject.Dtos;
using Inspinia_MVC5_SeedProject.ViewModels;
using Inspinia_MVC5_SeedProject.Models;

namespace Inspinia_MVC5_SeedProject.Controllers.Api
{
    public class MensajesApiController : ApiController
    {

        #region context
        private ApplicationDbContext _context;
        public MensajesApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        [HttpPost]
        public IHttpActionResult guardarMensaje(MensajesDto mensajedto)
        {


            var mensaje = new MensajesIssue
            {
                FechaCreado = DateTime.Now,
                IssueId = mensajedto.IssueId,
                UsuarioId = User.Identity.GetUserId(),
                Mensaje = mensajedto.Mensaje
            };
            //_context.Configuration.ValidateOnSaveEnabled = false;
            _context.MensajesIssue.Add(mensaje);
            _context.SaveChanges();
            return Ok();
        }
    }
}
