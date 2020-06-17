using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.ModelosCamarasClientes
{
    public class CamarasMalvinas
    {
        public int Id { get; set; }
        public string NombreCamara { get; set; }
        public string Ip { get; set; }
        public bool TieneVideo { get; set; }
    }
}