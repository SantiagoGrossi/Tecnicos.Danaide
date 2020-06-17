using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5_SeedProject.Models;
namespace Inspinia_MVC5_SeedProject.ViewModels
{
    public class MensajesViewModel
    {
        public List<MensajesIssue> ListaMensajes { get; set; }
        public string TituloIssue { get; set; }
        public int Idissue { get; set; }
        public Issue Issue { get; set; }

    }
}