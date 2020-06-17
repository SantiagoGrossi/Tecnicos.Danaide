using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Dtos
{
	public class ClientesDto
	{
		public int Id { get; set; }

        public string Nombre { get; set; }

        public int? CantidadTecnicosAsignados { get; set; }
	}
}