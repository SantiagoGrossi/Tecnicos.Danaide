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
using AutoMapper;
namespace Inspinia_MVC5_SeedProject.Controllers.Api
{
    public class AreasApiController : ApiController
    {

        #region context
        private ApplicationDbContext _context;
        public AreasApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        [HttpGet]
        public IHttpActionResult traerAreas(string query = null)
        {
            IQueryable<AreaTecnicos> areasQuery = _context.AreaTecnicos;


            if (!String.IsNullOrWhiteSpace(query))
                areasQuery = areasQuery.Where(c => c.Nombre.Contains(query));
            areasQuery

                            .ToList()
                .Select(Mapper.Map<AreaTecnicos, AreaTecnicoDto>);

            return Ok(areasQuery);
        }
    }
}
