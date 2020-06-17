using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class RelacionesClientes
    {
        public int Id { get; set; }

        public Clientes Clientes { get; set; }
        public int ClientesId { get; set; }

        public ApplicationUser Tecnico { get; set; }
        public string TecnicoId { get; set; }
    }
}