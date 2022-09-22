using Data;
using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PersonaBusiness
    {
        private readonly PersonaData personaData = new PersonaData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public object BusinessPersona(GeneralEntity genEnt)
        {
            try
            {

                return personaData.DataPersona(genEnt);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
