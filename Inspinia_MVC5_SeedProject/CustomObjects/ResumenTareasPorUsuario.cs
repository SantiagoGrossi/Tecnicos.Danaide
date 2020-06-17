using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.CustomObjects
{
    public class ResumenTareasPorUsuario
    {
        public string Usuario { get; set; }
        public string Color { get; set; }
        public int Totales { get; set; }
        public int Pendientes { get; set; }
        public int Hoy { get; set; }
        public int UserId { get; set; }
    }
}