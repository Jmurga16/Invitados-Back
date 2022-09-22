﻿using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MenuData
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #region Conexion
        private readonly Conexion oCon;
        public MenuData()
        {
            oCon = new Conexion(1);
        }
        #endregion

        #region Menu
        public object DataMenu(GeneralEntity genEnt)
        {

            string msj = string.Empty;

            switch (genEnt.nOpcion)
            {
                #region 1. Menu
                case 1:
                    try
                    {
                        List<MenuEntity> listaMenus = new List<MenuEntity>();
                        using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_Menu", genEnt.nOpcion, genEnt.pParametro))
                        {
                            while (dr.Read())
                            {
                                MenuEntity entity = new MenuEntity();


                                entity.IdMenu = Int32.Parse(Convert.ToString(dr["IdMenu"]));
                                entity.Name = Convert.ToString(dr["Name"]);
                                entity.Route = Convert.ToString(dr["Route"]);
                                entity.Icon = Convert.ToString(dr["Icon"]);
                                entity.IdParent = Int32.Parse(Convert.ToString(dr["IdParent"]));
                                entity.Level = Int32.Parse(Convert.ToString(dr["Level"]));
                                entity.Status = Boolean.Parse(Convert.ToString(dr["Status"]));
                               

                                listaMenus.Add(entity);

                            }

                            return listaMenus;
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Error(e);
                        throw;
                    }
                #endregion

                #region 2. Insertar | 3. Actualizar | 4. Eliminar(Logica) -- Menu                
                case 4:
                case 5:
                case 6:
               
                    try
                    {
                        string sResultado = Convert.ToString(oCon.EjecutarEscalar("USP_MNT_Menu", genEnt.nOpcion, genEnt.pParametro));

                        msj = sResultado;
                    }
                    catch (Exception ex)
                    {
                        msj = ex.Message;
                    }
                    return msj;
                #endregion

                default:
                    return null;

            }


        }
        #endregion
    }
}
