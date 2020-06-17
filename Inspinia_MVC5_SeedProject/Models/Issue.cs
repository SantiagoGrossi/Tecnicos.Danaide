using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public ApplicationUser DerivadaDe { get; set; }
        public string DerivadaDeId { get; set; }

        [Display(Name = "Asignar a:")]
        public ApplicationUser TecnicoAsignado { get; set; }
        public string TecnicoAsignadoId { get; set; }


        [Display(Name = "Area")]
        [Required]
        public AreaTecnicos AreaTecnicos { get; set; }
        public int AreaTecnicosId { get; set; }

        public DateTime? FechaCreada { get; set; }
        public DateTime? FechaCerrada { get; set; }
        public string FechaCreadaString { get; set; }
        public string FechaCerradaString { get; set; }

        public EstadoIssue EstadoIssue { get; set; }
        public int EstadoIssueId { get; set; }

        public ApplicationUser CreadaPor { get; set; }
        public string CreadaPorId { get; set; }

        [Display(Name = "Cliente")]
        [Required]
        public Clientes Clientes { get; set; }
        public int ClientesId { get; set; }

        [Display(Name = "Criticidad")]
        [Required]
        public CriticidadIssue CriticidadIssue { get; set; }
        public int CriticidadIssueId { get; set; }

        public int? VecesReclamado { get; set; }

        public string TiempoDedicado { get; set; }

        public ApplicationUser CerradaPor { get; set; }
        public string CerradaPorId { get; set; }
        public DateTime? ResultadoTiempo { get; set; }

        public int? NumeroIssue { get; set; }
    }
}