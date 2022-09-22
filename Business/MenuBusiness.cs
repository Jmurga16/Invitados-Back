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
    public class MenuBusiness
    {
        private readonly MenuData MenuData = new MenuData();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public object BusinessMenu(GeneralEntity genEnt)
        {
            try
            {

                return MenuData.DataMenu(genEnt);

            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;

            }
        }
    }
}
