using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.ViewModels;
using Inspinia_MVC5_SeedProject.Dtos;
using Inspinia_MVC5_SeedProject.CustomObjects;
using System.Globalization;
using System.Data.Entity;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class AdminController : Controller
    {
        #region context
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminEstadosTickets()
        {
            return View();
        }
        public ActionResult PermisosUsuario()
        {
            var viewmodel = new PermisosUsuariosViewModel
            {
                ApplicationUsers = _context.Users.ToList()
            };
            return View(viewmodel);
        }

        public ActionResult traerAreas(string userId)
        {
            var Areas = _context.AreaTecnicos
                
                       .ToList();
            return Json(new { Areas }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult traerClientes(string userId)
        {
            var Clientes = _context.Clientes

                       .ToList();
            return Json(new { Clientes }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AdministrarUsuario(string userId)
        {
            var user = _context.Users.Single(m => m.Id == userId);
            if (user == null)
                return HttpNotFound("Usuario no encontrado");
            var viewmodel = new PermisosUsuariosViewModel
            {
                userId = user.Id,
                Usuario = user,
                RelacionesAreas = _context.RelacionesAreas.ToList(),
                RelacionesClientes = _context.RelacionesClientes.ToList()
            };
            return View();
        }
        //public ActionResult getUsersNoAdmin()
        //{
        //    var users = _context.Users
              
               
        //}
        public ActionResult ModificarUsuario(ModificarUsuarioDto dto)
        {
            var usuario =0;

            //eliminar permisos anteriores
            var areas = _context.AreaTecnicos.Where(
                 m => dto.ListaAreas.Contains(m.Id)).ToList();

            var relacionesAreasDelUsuarioExistentes = _context.RelacionesAreas.Where(
                 m => dto.UserId.Contains(m.TecnicoId)).ToList();


            foreach (var area in relacionesAreasDelUsuarioExistentes)
            {
                _context.RelacionesAreas.Remove(area);
            }


            var relacionesClientesDelUsuarioExistentes = _context.RelacionesClientes.Where(
                 m => dto.UserId.Contains(m.TecnicoId)).ToList();

            var clientes = _context.Clientes.Where(
                 m => dto.ListaClientes.Contains(m.Id)).ToList();
            foreach (var cliente in relacionesClientesDelUsuarioExistentes)
            {
                _context.RelacionesClientes.Remove(cliente);
            }


            //nuevos permisos

            foreach(var area in areas)
            {
                var relacionArea = new RelacionesAreas
                {
                    TecnicoId = dto.UserId,
                    AreasTecnicosId = area.Id

                };

                _context.RelacionesAreas.Add(relacionArea);
            }
            foreach(var cliente in clientes)
            {
                var relacionCliente = new RelacionesClientes
                {
                    TecnicoId = dto.UserId,
                    ClientesId = cliente.Id
                };
                _context.RelacionesClientes.Add(relacionCliente);
            }
            _context.SaveChanges();
            var nuevousuario = new ModificarUsuarioDto
            {
                NombreUsuario = _context.Users.Single(m => m.Id == dto.UserId).Nombre
                

            };
            return Json(nuevousuario, JsonRequestBehavior.AllowGet);
        }
        public ActionResult HorasExtras()
        {
            List<HsExtrasIndex> objetoFinal = new List<HsExtrasIndex>();
            var HorasExtrasGroupedByUser = _context.HorasExtras.GroupBy(u => u.UsuarioId)
                                      .Select(grp => new { GroupID = grp.Key, ListaHoras = grp.Where(m => m.Fecha.Value.Month == DateTime.Now.Month).ToList() })
                                      .ToList();
            foreach (var grupo in HorasExtrasGroupedByUser)
            {
                int cantNormales = 0;
                int cantFinDeSemana = 0;
                var UsuarioySusHoras = new HsExtrasIndex();
                UsuarioySusHoras.Horas = new List<HorasExtras>();
                UsuarioySusHoras.Usuario = _context.Users.Single(m => m.Id == grupo.GroupID);
                foreach (var hora in grupo.ListaHoras)
                {

                    if (hora.UsuarioId == grupo.GroupID)
                        UsuarioySusHoras.Horas.Add(hora);
                    if (hora.TipoHoraExtraNombre == "Fin de semana")
                        cantFinDeSemana = cantFinDeSemana + hora.Cantidad;
                    //cantFinDeSemana++;
                    else
                        cantNormales = cantNormales + hora.Cantidad;
                    //cantNormales++;
                }
                UsuarioySusHoras.CantHorasFinDeSemana = cantFinDeSemana;
                UsuarioySusHoras.CantHorasNormales = cantNormales;
                objetoFinal.Add(UsuarioySusHoras);
            }
            var viewmodel = new HorasExtrasViewModel
            {
                VistaHsExtrasModel = objetoFinal,
                NombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month)

            };

            return View(viewmodel);
        }


    }
}