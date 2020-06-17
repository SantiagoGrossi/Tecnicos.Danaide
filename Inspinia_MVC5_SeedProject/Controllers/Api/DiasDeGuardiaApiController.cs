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
    public class DiasDeGuardiasApiController : ApiController
    {
        #region context
        private ApplicationDbContext _context;
        public DiasDeGuardiasApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion

        [HttpGet]
        public IHttpActionResult traerTodosLosDiasDeGuardia(string query = null)
        {
            var dias = _context.DiaDeGuardia

                .Include(m => m.UsuarioDeGuardia)
                .ToList();
            return Ok(dias);
        }

    }
}


