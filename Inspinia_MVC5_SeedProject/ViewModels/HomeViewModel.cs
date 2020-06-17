using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Inspinia_MVC5_SeedProject.ViewModels
{
    public class HomeViewModel
    {
        public List<HorasExtras> HorasExtras { get; set; }
        public List<ApplicationUser> Resumen { get; set; }
        public List<Issue> MisPendientes { get; set; }
        public List<Issue> MisAsignadasPendientes { get; set; }
        public List<Issue> GuardiasPendientes { get; set; }
        public List<PendientesMesa> PendientesMesa { get; set; }
        public int intGenerico { get; set; }
        public string stringGenerico { get; set; }
    }
}