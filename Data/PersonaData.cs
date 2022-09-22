using Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersonaData
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #region Conexion
        private readonly Conexion oCon;
        public PersonaData()
        {
            oCon = new Conexion(1);
        }
        #endregion

        #region Persona
        public object DataPersona(GeneralEntity genEnt)
        {

            string msj = string.Empty;

            switch (genEnt.nOpcion)
            {
                #region 1. Lista de Invitados
                case 1:
                    try
                    {
                        List<PersonaEntity> listaPersonas = new List<PersonaEntity>();
                        using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_Persona", genEnt.nOpcion, genEnt.pParametro))
                        {
                            while (dr.Read())
                            {
                                PersonaEntity entity = new PersonaEntity();


                                entity.nIdPersona = Int32.Parse(Convert.ToString(dr["nIdPersona"]));
                                entity.sDNI = Convert.ToString(dr["sDNI"]);
                                entity.sNombrePersona = Convert.ToString(dr["sNombrePersona"]);

                                entity.sNombre = Convert.ToString(dr["sNombre"]);
                                entity.sApellidoPaterno = Convert.ToString(dr["sApellidoPaterno"]);
                                entity.sApellidoMaterno = Convert.ToString(dr["sApellidoMaterno"]);
                                entity.bEstado = Boolean.Parse(Convert.ToString(dr["bEstado"]));                               

                                listaPersonas.Add(entity);

                            }

                            return listaPersonas;
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Error(e);
                        throw;
                    }
                #endregion

                #region 2. Persona por DNI
                case 2:
                    try
                    {
                        List<PersonaEntity> listaPersonaDNI = new List<PersonaEntity>();
                        using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_Persona", genEnt.nOpcion, genEnt.pParametro))
                        {

                            while (dr.Read())
                            {
                                PersonaEntity entity = new PersonaEntity();

                                entity.nIdPersona = Int32.Parse(Convert.ToString(dr["nIdPersona"]));
                                entity.sDNI = Convert.ToString(dr["sDNI"]);
                                entity.sNombrePersona = Convert.ToString(dr["sNombrePersona"]);

                                entity.sNombre = Convert.ToString(dr["sNombre"]);
                                entity.sApellidoPaterno = Convert.ToString(dr["sApellidoPaterno"]);
                                entity.sApellidoMaterno = Convert.ToString(dr["sApellidoMaterno"]);
                                entity.bEstado = Boolean.Parse(Convert.ToString(dr["bEstado"]));


                                listaPersonaDNI.Add(entity);

                            }

                            return listaPersonaDNI;
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Error(e);
                        throw;
                    }
                #endregion

                #region 3. Insertar | 4. Actualizar | 5. Eliminar(Logica) -- Clientes | Ingresar    
                case 3:
                case 4:
                case 5:
                case 6:

                    try
                    {
                        string sResultado = Convert.ToString(oCon.EjecutarEscalar("USP_MNT_Persona", genEnt.nOpcion, genEnt.pParametro));

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
