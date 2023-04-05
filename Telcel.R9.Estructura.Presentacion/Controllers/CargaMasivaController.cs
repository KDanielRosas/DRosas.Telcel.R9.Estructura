using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivoTxt)
        {
            string connSQL = "Data Source=.;Initial Catalog=DRosasEstructura;Persist Security Info=True;User ID=sa;Password=pass@word1";
            SqlConnection sqlConnection = new SqlConnection(connSQL);
            var file = archivoTxt.InputStream;
            int counter = 0;
            string line = "";

            string fileDelimiter = ",";

            using (StreamReader reader = new StreamReader(file))
            {
                sqlConnection.Open();
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        //string query = "INSERT INTO Usuario VALUES('" + line.Replace(fileDelimiter, "','") + "')";
                        string query = "EXEC EmpleadoAdd '" + line.Replace(fileDelimiter, "','") + "'";

                        //ejecutar query
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    counter++;
                }
            }
            sqlConnection.Close();
            ViewBag.Message = "Exito en la carga";
            return View("Modal");

        }//Index(archivo Txt)
    }
}