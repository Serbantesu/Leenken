using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Empleado/GetById/{idEmpleado}")]
        public IHttpActionResult GetById(int idEmpleado)
        {
            ML.Result result = BL.Empleado.EmpleadoGetById(idEmpleado);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Empleado/Add")]
        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.EmpleadoAdd(empleado);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Empleado/Update")]
        public IHttpActionResult Update([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.EmpleadoUpdate(empleado);
            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Empleado/Delete/{idEmpleado}")]
        public IHttpActionResult Delete(int idEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = idEmpleado;
            
            ML.Result result = BL.Empleado.EmpleadoDelete(empleado);
            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Entidad/GetAll")]
        public IHttpActionResult EstadoGetAll()
        {
            ML.Result result = BL.EntidadFederativa.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


    }
}