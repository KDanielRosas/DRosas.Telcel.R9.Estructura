using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telcel.R9.Estructura.AccesoDatos;

namespace Telcel.R9.Estructura.Negocio
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Departamentos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DRosasEstructuraEntities context = new DRosasEstructuraEntities())
                {
                    var query = context.DepartamentoGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Departamento departamento = new Departamento();
                            departamento.DepartamentoID = item.DepartamentoID;
                            departamento.Descripcion = item.Descripcion;

                            result.Objects.Add(departamento);
                        }
                        result.Correct = true;
                    }//if
                }//using
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//GetAll
    }
}
