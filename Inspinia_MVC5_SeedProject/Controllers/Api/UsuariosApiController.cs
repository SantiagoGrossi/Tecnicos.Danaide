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
    public class UsuariosApiController : ApiController
    {
         #region context
        private ApplicationDbContext _context;
        public UsuariosApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        //[HttpGet]
        //public IHttpActionResult todosLosUsuarios(string query = null)
        //{
        //    var listaDeUsuarios = new List<Usuarios>();
        //    IQueryable<ApplicationUser> usuariosquery = _context.Users.Where(m => m.Color != null);

        //    foreach (var usuario in usuariosquery)
        //    {
        //        var userActual = new Usuarios();
        //        userActual.Email = usuario.UserName;
        //        userActual.Nombre = usuario.Nombre;
        //        userActual.Id = usuario.Id;
        //        userActual.userName = usuario.UserName;
        //        listaDeUsuarios.Add(userActual);
        //    }

        //    if (!String.IsNullOrWhiteSpace(query))
        //        usuariosquery = usuariosquery.Where(c => c.Nombre.Contains(query));

        //    //usuariosquery

        //    //.ToList();
        //    //.Select(Mapper.Map<Applic, TareasDiariasDto>);

        //    return Ok(listaDeUsuarios);
        //}

    }
}
