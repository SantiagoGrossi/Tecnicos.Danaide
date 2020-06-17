using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
namespace Inspinia_MVC5_SeedProject.ViewModels
{
    public class IssueViewmodel
    {
        public Issue Issue { get; set; }
        public IEnumerable<ApplicationUser> Usuario { get; set; }
        public IEnumerable<CriticidadIssue> CriticidadIssue { get; set; }
        public IEnumerable<EstadoIssue> EstadoIssue { get; set; }
        public IEnumerable<AreaTecnicos> AreaTecnicos { get; set; }
        public IEnumerable<Clientes> Clientes { get; set; }

    }
}