using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Inspinia_MVC5_SeedProject.Models;
using Inspinia_MVC5_SeedProject.CustomObjects;
using Inspinia_MVC5_SeedProject.ViewModels;

namespace Inspinia_MVC5_SeedProject.Controllers.Api
{
    public class GrafanaApiController : ApiController
    {

        #region context
        private ApplicationDbContext _context;
        public GrafanaApiController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        [HttpGet]
        public IHttpActionResult todasLasCamaras(string id)
        {
            if (id == null)
                id = "Malvinas";
            var ip = _context.Systems.SingleOrDefault(m => m.Nombre == id).IpSystem; ;
            var listastring = new List<String>();
            var Lista = new List<ListIntListString>();
            var camaras = new List<Camaras>();

            if (id != "Caba")
            {
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


            }
            else
            {
                #region Caba1A

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connString = @"Data Source = 172.23.31.116\XDR; User ID =evtAdmin;Password=a";
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 1A"


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
                #endregion
                #region Caba1B

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connStringB = @"Data Source = 172.23.31.118\XDR; User ID =evtAdmin;Password=a";
                //connString.Remove(21,1);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStringB))
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 1B"


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
                #endregion
                #region Caba2

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connString2 = @"Data Source = 172.23.31.120\XDR; User ID =evtAdmin;Password=a";
                //connString.Remove(21,1);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString2))
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 2"


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
                #endregion
                #region Caba3

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connString3 = @"Data Source = 172.23.3.198\XDR; User ID =evtAdmin;Password=a";
                //connString.Remove(21,1);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString3))
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 3"


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
                #endregion
                #region Caba4

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connString4 = @"Data Source = 172.23.31.105\XDR; User ID =evtAdmin;Password=a";
                //connString.Remove(21,1);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString4))
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 4"


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
                #endregion
                #region Caba5

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connString5 = @"Data Source = 172.23.31.121\XDR; User ID =evtAdmin;Password=a";
                //connString.Remove(21,1);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString5))
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 5"


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
                #endregion
                #region Caba6

                //string connString = @"Data Source = 10.200.3.120\XDR; User ID =evtAdmin;Password=a";
                string connString6 = @"Data Source = 172.23.31.26\XDR; User ID =evtAdmin;Password=a";
                //connString.Remove(21,1);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString6))
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
                                    NodoNombre = dr.GetString(NodoNombre),
                                    System = "Caba 6"


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
                #endregion
            }

            return Ok(camaras);


        }



    }
}
