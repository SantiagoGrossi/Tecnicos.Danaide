using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class HorasExtras
    {
        public int Id { get; set; }

        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }

        public int Cantidad { get; set; }
        public int NumeroMes { get; set; }
        public string NombreMes { get; set; }

        public TipoHoraExtra TipoHoraExtra { get; set; }
        public int? tipoHoraExtraId { get; set; }

        public string TipoHoraExtraNombre { get; set; }
        public string Motivo { get; set; }

        public string UsuarioNombre { get; set; }

        public DateTime? Fecha { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
    }
}