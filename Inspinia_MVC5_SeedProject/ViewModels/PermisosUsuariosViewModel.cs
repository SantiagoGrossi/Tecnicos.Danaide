using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
using Microsoft.AspNet.Identity;
using Inspinia_MVC5_SeedProject.Dtos;
using Inspinia_MVC5_SeedProject.CustomObjects;

namespace Inspinia_MVC5_SeedProject.ViewModels
{
    public class PermisosUsuariosViewModel
    {
        public ApplicationUser Usuario { get; set; }
        public string userId { get; set; }
        public List<RelacionesAreas> RelacionesAreas { get; set; }
        public List<RelacionesClientes> RelacionesClientes { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}