using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EntidadFederativa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesLeenkenEntities1 context = new DL.JCervantesLeenkenEntities1())
                {
                    var query = context.EntidadGetAll();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var user in query)
                        {
                            ML.EntidadFederativa entidad = new ML.EntidadFederativa();

                            entidad.IdEntidadFederativa = user.IdEntidadFederativa;
                            entidad.Estado = user.Estado;

                            result.Objects.Add(entidad);
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
                result.ErrorMessage = "No se encontraron registros" + ex;
            }
            return result;
        }
    }
}
