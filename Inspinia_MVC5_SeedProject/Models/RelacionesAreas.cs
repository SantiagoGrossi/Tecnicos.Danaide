using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class RelacionesAreas
    {
        public int Id { get; set; }

        public AreaTecnicos AreaTecnicos { get; set; }
        public int AreasTecnicosId { get; set; }

        public ApplicationUser Tecnico { get; set; }
        public string TecnicoId { get; set; }
    }
}