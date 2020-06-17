using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Dtos
{
    public class nuevaIssueDto
    {
        public string Titulo { get; set; }
        
        public string Resumen { get; set; }
        public int NombreArea { get; set; }
        public string NombreCliente { get; set; }
        public string TecnicoAsignadoId { get; set; }
        public int Criticidad { get; set; }
        public int Minutos { get; set; }

    }
}