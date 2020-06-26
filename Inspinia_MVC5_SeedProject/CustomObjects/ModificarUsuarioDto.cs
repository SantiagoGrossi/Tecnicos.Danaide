using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.CustomObjects
{
    public class ModificarUsuarioDto
    {
        public string UserId { get; set; }
        //public List<int> ListaAreas { get; set; }
        //public List<int> ListaClientes { get; set; }
        public int[] ListaAreas { get; set; }
        public int[] ListaClientes { get; set; }

    }
}