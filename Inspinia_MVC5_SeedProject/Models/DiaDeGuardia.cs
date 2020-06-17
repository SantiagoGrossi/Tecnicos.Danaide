using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class DiaDeGuardia
    {
        public int Id { get; set; }

        public ApplicationUser UsuarioDeGuardia { get; set; }
        public string UsuarioDeGuardiaId { get; set; }

        public DateTime Inicia { get; set; }
        public DateTime Termina { get; set; }

        public string IniciaString { get; set; }
        public string TerminaString { get; set; }

        public bool EsDiaNoHabil { get; set; }



    }
}