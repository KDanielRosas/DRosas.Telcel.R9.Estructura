using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telcel.R9.Estructura.AccesoDatos;

namespace Telcel.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public Puesto Puesto { get; set; }
        public Departamento Departamento { get; set; }
        public List<object> Empleados { get; set; }

        public static Result GetAll(Empleado empleado)
        {
            empleado.Nombre = empleado.Nombre != null ? empleado.Nombre : "";
            empleado.Puesto = empleado.Puesto != null ? empleado.Puesto : new Puesto();
            empleado.Departamento = empleado.Departamento != null ? empleado.Departamento : new Departamento();

            Result result = new Result();
            try
            {
                using (AccesoDatos.DRosasEstructuraEntities context = new AccesoDatos.DRosasEstructuraEntities())
                {
                    var query = context.EmpleadoGetAll(empleado.Nombre, 
                        empleado.Puesto.PuestoID, empleado.Departamento.DepartamentoID).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        
                        foreach (var obj in query)
                        {
                            Empleado employee = new Empleado();

                            employee.EmpleadoID = obj.EmpleadoID;
                            employee.Nombre = obj.Nombre;
                            employee.Departamento = new Departamento();
                            employee.Departamento.DepartamentoID = obj.DepartamentoID.Value;
                            employee.Departamento.Descripcion = obj.DescripcionDepartamento;
                            employee.Puesto = new Puesto();
                            employee.Puesto.PuestoID = obj.PuestoID.Value;
                            employee.Puesto.Descripcion = obj.DescripcionPuesto;

                            result.Objects.Add(employee);
                        }//foreach
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

        public static Result GetById(int EmpleadoID)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DRosasEstructuraEntities context = new AccesoDatos.DRosasEstructuraEntities())
                {
                    var query = context.EmpleadoGetById(EmpleadoID).FirstOrDefault();

                    if (query != null)
                    {
                        Empleado employee = new Empleado();
                        employee.EmpleadoID = query.EmpleadoID;
                        employee.Nombre = query.Nombre;
                        employee.Puesto = new Puesto();
                        employee.Puesto.PuestoID = query.PuestoID.Value;
                        employee.Departamento = new Departamento();
                        employee.Departamento.DepartamentoID = query.DepartamentoID.Value;

                        result.Correct = true;
                        result.Object = employee;
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
        }//GetById

        public static Result Add(Empleado empleado)
        {
            Result result = new Result();

            try
            {
                using (DRosasEstructuraEntities context = new DRosasEstructuraEntities())
                {
                    int query = context.EmpleadoAdd(empleado.Nombre,empleado.Puesto.PuestoID, empleado.Departamento.DepartamentoID);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//Add

        public static Result Delete(int EmpleadoID)
        {
            Result result = new Result();

            try
            {
                using (DRosasEstructuraEntities context = new DRosasEstructuraEntities())
                {
                    int query = context.EmpleadoDelete(EmpleadoID);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                throw;
            }
            return result;
        }//Delete

        public static Result Update(Empleado empleado)
        {
            Result result = new Result();

            try
            {
                using (DRosasEstructuraEntities context = new DRosasEstructuraEntities())
                {
                    int query = context.EmpleadoUpdate(empleado.EmpleadoID, empleado.Nombre, 
                        empleado.Puesto.PuestoID, empleado.Departamento.DepartamentoID);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return result;
        }//Update
    }//Empleado
}//NS
