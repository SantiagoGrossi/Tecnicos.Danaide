using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Inspinia_MVC5_SeedProject.CustomObjects
{
    public class HsExtrasIndex
    {
        public ApplicationUser Usuario { get; set; }
        public List<HorasExtras> Horas { get; set; }

        public int CantHorasNormales { get; set; }
        public int CantHorasFinDeSemana { get; set; }
    }
}