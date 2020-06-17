using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
using System.ComponentModel.DataAnnotations;
namespace Inspinia_MVC5_SeedProject.Models
{
    public class AporteComunitaria
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string TiempoDedicado { get; set; }

        public ApplicationUser Aportante { get; set; }
        public string AportanteId { get; set; }

        public DateTime? FechaAporte { get; set; }
        public string FechaAporteString { get; set; }

        public PendientesMesa PendientesMesa { get; set; }
        public int PendientesMesaId { get; set; }
    }
}