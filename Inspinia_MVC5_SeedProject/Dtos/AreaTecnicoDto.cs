using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Dtos
{
    public class AreaTecnicoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IssueId { get; set; }
        public int Tiempo { get; set; }
        public int? Numero { get; set; }
        public string stringGenerico { get; set; }
    }
}