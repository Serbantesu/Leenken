using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesLeenkenEntities1 context = new DL.JCervantesLeenkenEntities1())
                {
                    var query = context.EmpleadoGetAll();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var user in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.Entidad = new ML.EntidadFederativa();

                            empleado.IdEmpleado = user.IdEmpleado;
                            empleado.NumeroNomina = user.NumeroNomina;
                            empleado.Nombre = user.Nombre;
                            empleado.ApellidoPaterno = user.ApellidoPaterno;
                            empleado.ApellidoMaterno = user.ApellidoMaterno;

                            empleado.Entidad.IdEntidadFederativa = user.IdEntidadFederativa;
                            empleado.Entidad.Estado = user.Estado;

                            result.Objects.Add(empleado);   
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encuentran registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error con los registros" + ex;
            }
            return result;
        }

        public static ML.Result EmpleadoAdd(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesLeenkenEntities1 context = new DL.JCervantesLeenkenEntities1())
                {
                    int query = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Entidad.IdEntidadFederativa);
                    if(query > 0)
                    {
                        result.Correct = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al agregar el registro" + ex;
            }
            return result;
        }

        public static ML.Result EmpleadoUpdate(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesLeenkenEntities1 context = new DL.JCervantesLeenkenEntities1())
                {
                    int query = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Entidad.IdEntidadFederativa);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al actualizar el registro" + ex;
            }
            return result;
        }

        public static ML.Result EmpleadoDelete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesLeenkenEntities1 context = new DL.JCervantesLeenkenEntities1())
                {
                    int query = context.EmpleadoDelete(empleado.IdEmpleado);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "No se encuentra el registro seleccionado" + ex;
            }

            return result; 
        }

        public static ML.Result EmpleadoGetById(int idEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesLeenkenEntities1 context = new DL.JCervantesLeenkenEntities1())
                {
                    var query = context.EmpleadoGetById(idEmpleado).FirstOrDefault();
                    if(query != null)
                    {                        
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.Entidad = new ML.EntidadFederativa();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;

                        empleado.Entidad.IdEntidadFederativa = query.IdEntidadFederativa;
                        empleado.Entidad.Estado = query.Estado;

                        result.Object = empleado;

                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo obtener el registro seleccionado";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "No se encuentra el registro seleccionado" + ex;
            }
            return result;
        }
    }
}
