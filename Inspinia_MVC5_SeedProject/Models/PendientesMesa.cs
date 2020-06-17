using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
using System.ComponentModel.DataAnnotations;
namespace Inspinia_MVC5_SeedProject.Models
{
    public class PendientesMesa
    {

        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime? FechaCreada { get; set; }
        public DateTime? FechaCerrada { get; set; }
        public string FechaCreadaString { get; set; }
        public string FechaCerradaString { get; set; }

        public EstadoIssue EstadoIssue { get; set; }
        public int EstadoIssueId { get; set; }

        public ApplicationUser CreadaPor { get; set; }
        public string CreadaPorId { get; set; }

        public string TiempoDedicado { get; set; }

        public ApplicationUser CerradaPor { get; set; }
        public string CerradaPorId { get; set; }

        public int? NumeroPendiente { get; set; }

        [Display(Name = "Cliente")]
        [Required]
        public Clientes Clientes { get; set; }
        public int ClientesId { get; set; }

        public DateTime? TiempoResultante { get; set; }


    }
}