using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.ViewModels;
using Inspinia_MVC5_SeedProject.CustomObjects;
using Microsoft.AspNet.Identity;
using System.Globalization;
using Microsoft.VisualBasic;
using AutoMapper;
using Inspinia_MVC5_SeedProject.Dtos;
namespace Inspinia_MVC5_SeedProject.Controllers.Api
{
    public class HorasExtrasApiController : ApiController
    {
        #region context
        private ApplicationDbContext _context;
        public HorasExtrasApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        [HttpPost]
        public IHttpActionResult guardarHorasExtras(HorasExtrasDto horas)
        {
            //SACAR ESTO POR DIOS
            #region validacion desde y hasta
            if (horas.Desde == null)
            {
                horas.Desde = "00:00 PM";
            }
            if (horas.Hasta == null)
            {
                horas.Hasta = "00:00 PM";
            }

            #endregion



            String mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            var HorasExtras = new HorasExtras
            {
                Motivo = horas.Motivo,
                Cantidad = horas.Cantidad,
                UsuarioId = User.Identity.GetUserId(),
                UsuarioNombre = User.Identity.GetUserName(),
                NombreMes = mes,
                NumeroMes = DateTime.Now.Month,
                Fecha = DateTime.Now,
                TipoHoraExtraNombre = horas.TipoHoraExtraNombre,
                Desde = horas.Desde.Substring(Math.Max(0, horas.Desde.Length - 7)),
                Hasta = horas.Hasta.Substring(Math.Max(0, horas.Hasta.Length - 7)),
                tipoHoraExtraId = _context.TipoHoraExtra.Single(m => m.Tipo == horas.TipoHoraExtraNombre).Id

            };


            _context.Configuration.ValidateOnSaveEnabled = false;
            _context.HorasExtras.Add(HorasExtras);
            _context.SaveChanges();

            return Ok();
        }
    }
}
