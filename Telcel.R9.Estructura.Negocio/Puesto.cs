using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telcel.R9.Estructura.AccesoDatos;

namespace Telcel.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DRosasEstructuraEntities context = new DRosasEstructuraEntities())
                {
                    var query = context.PuestoGetAll().ToList();
                    if (query != null) 
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Puesto puesto = new Puesto();
                            puesto.PuestoID = item.PuestoID;
                            puesto.Descripcion = item.Descripcion;

                            result.Objects.Add(puesto);
                        }
                        result.Correct = true;
                    }//if
                }//using
            }//try
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                throw;
            }
            return result;
        }//GetAll
    }
}
