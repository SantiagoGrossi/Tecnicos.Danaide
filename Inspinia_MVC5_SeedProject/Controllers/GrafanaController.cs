using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5_SeedProject.CustomObjects;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class GrafanaController : Controller
    {
        // GET: Grafana
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGrafana(string NombreCliente)
        {
            var viewmodel = new CustomObjects.GenericoUnString
            {
                stringGenerico = NombreCliente
            };

            return View(viewmodel);
        }

        public ActionResult GrafanaCamaras(string ip)
        {
            var listastring = new List<String>();
            var Lista = new List<ListIntListString>();
            var camaras = new List<Camaras>();

            string connString = ("Data Source=" + ip + " ; User ID =evtAdmin;Password=a");
            //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
            //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
            //connString.Remove(21,1);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT InputChannels.InputChannelIdentity
	                    ,InputChannels.DeviceIdentity
	                    ,InputChannels.Name As NombreCanal
                        ,InputChannels.StorageDrive
                        ,InputChannels.StorageDrive2
                        ,InputChannels.MaxRetentionDays
                        ,InputChannels.MaxRetentionDays2
                        ,Devices.NodeIdentity
	                    ,Devices.DeviceIdentity
                        ,Devices.Name As DeviceName
                        ,Devices.UserName
                        ,Devices.Password
	                    ,Devices.EndPointIpAddress
                        ,Nodes.NodeIdentity
                        ,Nodes.Name As NodoNombre
               
	              FROM [EVT]. [dbo].[InputChannels]
 
INNER JOIN [EVT]. [dbo].[Devices]

ON
InputChannels.DeviceIdentity=Devices.DeviceIdentity

INNER JOIN [EVT]. [dbo].[Nodes]

ON
Devices.NodeIdentity=Nodes.NodeIdentity

                    ;";


                    SqlCommand cmd = new SqlCommand(query, conn);

                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();



                    //check if there are records
                    if (dr.HasRows)
                    {
                        var nombreCamara = dr.GetOrdinal("DeviceName");
                        var channelname = dr.GetOrdinal("NombreCanal");
                        var Ip = dr.GetOrdinal("EndPointIpAddress");
                        var Username = dr.GetOrdinal("Username");
                        var Password = dr.GetOrdinal("Password");
                        var StorageDrive = dr.GetOrdinal("StorageDrive");
                        var StorageDrive2 = dr.GetOrdinal("StorageDrive2");
                        var Retention = dr.GetOrdinal("MaxRetentionDays");
                        var Retention2 = dr.GetOrdinal("MaxRetentionDays2");
                        var NodoNombre = dr.GetOrdinal("NodoNombre");
                        // var NodoNombre = dr.GetOrdinal("NodoNombre");


                        while (dr.Read())
                        {
                            //display retrieved record (first column only/string value)
                            //var camara = dr.GetString(0);

                            //var camara = listastring.Add(dr["Name"].ToString());
                            //listastring.Add(dr.GetString(0));
                            var camaraNombre = new Camaras
                            {
                                NombreCamara = dr.GetString(nombreCamara),
                                ChannelName = dr.GetString(channelname),
                                Ip = dr.GetString(Ip),
                                Usuario = dr.GetString(Username),
                                Pass = dr.GetString(Password),
                                StorageDrive = dr.GetString(StorageDrive),
                                StorageDrive2 = dr.GetString(StorageDrive2),
                                Retention = dr.GetInt32(Retention).ToString(),
                                Retention2 = dr.GetInt32(Retention2).ToString(),
                                NodoNombre = dr.GetString(NodoNombre)


                            };
                            camaras.Add(camaraNombre);


                        }

                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
            }

            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }


        


        var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var jsonResult = Json(camaras, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}