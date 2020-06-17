using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.CustomObjects;
using Inspinia_MVC5_SeedProject.Models;

namespace Inspinia_MVC5_SeedProject.ViewModels
{
    public class HorasExtrasViewModel
    {
        public List<HsExtrasIndex> VistaHsExtrasModel { get; set; }
        public string NombreMes { get; set; }
        public int? NumeroMes { get; set; }
    }
}