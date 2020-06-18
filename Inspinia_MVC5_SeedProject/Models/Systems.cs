using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class Systems
    {
        public int Id { get; set; }
        public string IpSystem { get; set; }


        public Clientes Cliente { get; set; }
        public int? ClienteId { get; set; }

        public string Nombre { get; set; }
    }
}