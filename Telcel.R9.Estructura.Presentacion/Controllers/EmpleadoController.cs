using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            Negocio.Empleado empleado = new Negocio.Empleado();
            Negocio.Result result = Negocio.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                Negocio.Result resultDepartamento = Negocio.Departamento.GetAll();
                Negocio.Result resultPuesto = Negocio.Puesto.GetAll();
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
                empleado.Puesto.Puestos = resultPuesto.Objects;
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View();
            }            
        }//GetAll

        [HttpPost]
        public ActionResult GetAll(Negocio.Empleado empleado)
        {
            Negocio.Result result = Negocio.Empleado.GetAll(empleado);
            if (result.Correct)
            {
                Negocio.Result resultDepartamento = Negocio.Departamento.GetAll();
                Negocio.Result resultPuesto = Negocio.Puesto.GetAll();
                empleado.Departamento = new Negocio.Departamento();
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
                empleado.Puesto = new Negocio.Puesto();
                empleado.Puesto.Puestos = resultPuesto.Objects;
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }//GetAll POST

        [HttpPost]
        public JsonResult Add(Negocio.Empleado empleado)
        {
            Negocio.Result result = Negocio.Empleado.Add(empleado);

            return Json(empleado);

        }//Add

        [HttpPost]
        public JsonResult Delete(int EmpleadoID)
        {
            Negocio.Result result = Negocio.Empleado.Delete(EmpleadoID);

            if (result.Correct)
            {
                return Json(result);
            }
            else
            {
                return null;
            }
            
        }//Delete

        [HttpPost]
        public JsonResult GetById(int EmpleadoID)
        {
            Negocio.Result result = Negocio.Empleado.GetById(EmpleadoID);

            if (result.Correct)
            {
                return Json(result);
            }
            else
            {
                return null;
            }
            

        }//GetById

        [HttpPost]
        public JsonResult Update(Negocio.Empleado empleado)
        {
            Negocio.Result result = Negocio.Empleado.Update(empleado);

            return Json(result);
        }

    }
}