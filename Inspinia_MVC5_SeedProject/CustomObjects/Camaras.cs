using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.CustomObjects
{
    public class Camaras
    {
        public string NombreCamara { get; set; }
        public string Ip { get; set; }

        public string StorageDrive { get; set; }
        public string StorageDrive2 { get; set; }

        public string Usuario { get; set; }
        public string Pass { get; set; }

        public string NodoNombre { get; set; }

        public string Retention { get; set; }
        public string Retention2 { get; set; }
        public string ChannelName { get; internal set; }
        public string System { get; internal set; }
    }
}