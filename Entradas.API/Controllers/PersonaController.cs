using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entradas.API.Controllers
{
    [Route("PersonaService")]
    [ApiController]
    public class PersonaController : Controller
    {
        private readonly PersonaBusiness objPersona = new PersonaBusiness();

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        #region Persona

        [HttpPost]
        public IActionResult CrudPersona(GeneralEntity genEnt)
        {

            if (genEnt.nOpcion == 1 || genEnt.nOpcion == 2 )
            {
                try
                {
                    var vRes = objPersona.BusinessPersona(genEnt);

                    return Ok(vRes);
                }
                catch (Exception e)
                {

                    logger.Error(e);
                    throw;

                }
            }

            else if (genEnt.nOpcion == 3 || genEnt.nOpcion == 4 || genEnt.nOpcion == 5 || genEnt.nOpcion == 6)
            {
                try
                {
                    string[] listaRes;

                    string sResultado = Convert.ToString(objPersona.BusinessPersona(genEnt));
                    listaRes = sResultado.Split('|');

                    return Ok(new { cod = listaRes[0], mensaje = listaRes[1] });
                }
                catch (Exception e)
                {

                    logger.Error(e);
                    throw;

                }
            }

            else
            {
                return null;
            }

        }

        #endregion
    }
}
