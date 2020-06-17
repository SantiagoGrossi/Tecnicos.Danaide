using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Inspinia_MVC5_SeedProject.Dtos;
using Inspinia_MVC5_SeedProject.ViewModels;
using Inspinia_MVC5_SeedProject.Dtos;
using AutoMapper;
using Inspinia_MVC5_SeedProject.Models;
namespace Inspinia_MVC5_SeedProject.Controllers.Api
{
    public class ClientesApiController : ApiController
    {

        #region context
        private ApplicationDbContext _context;
        public ClientesApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion


        [HttpGet]
        public IHttpActionResult traerClientes(string query = null)
        {
            IQueryable<Clientes> clientesquery = _context.Clientes;


            if (!String.IsNullOrWhiteSpace(query))
                clientesquery = clientesquery.Where(c => c.Nombre.Contains(query));

            clientesquery

                .ToList()
                .Select(Mapper.Map<Clientes, ClientesDto>);

            return Ok(clientesquery);
        }
    }
}
