using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
namespace Inspinia_MVC5_SeedProject.ViewModels
{
    public class IndexIssuesTecnicosViewModel
    {
        public int CantPendientes { get; set; }
        public int CantDisponibles { get; set; }
        public int Mias { get; set; }
        public IEnumerable<IUser> Usuarios { get; set; }
    }
}