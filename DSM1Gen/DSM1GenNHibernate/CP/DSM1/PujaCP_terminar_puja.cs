
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Puja_terminar_puja) ENABLED START*/
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class PujaCP : BasicCP
{
public void Terminar_puja (int p_Puja_OID, Nullable<DateTime> p_fecha, float p_puja_inicial, float p_puja_max, int p_id_usuario, bool p_cerrada)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_Puja_terminar_puja) ENABLED START*/

        IPujaCAD pujaCAD = null;
        PujaCEN pujaCEN = null;



            try
            {
                SessionInitializeTransaction();
                pujaCAD = new PujaCAD(session);
                pujaCEN = new PujaCEN(pujaCAD);

                IList<OfertaPujaEN> pujas = pujaCEN.get_IPujaCAD().ReadOIDDefault(p_Puja_OID).OfertaPuja; //Lista de pujas hechas en esta subasta
                OfertaPujaEN puja_ganadora = null;

                if (pujaCEN.get_IPujaCAD().ReadOIDDefault(p_Puja_OID).Cerrada)
                {
                    Exception ex = new Exception("YA ESTABA CERRADA");
                    throw ex;
                }

                foreach (OfertaPujaEN p in pujas)
                {
                    if (p.Cantidad_puja == p_puja_max)
                    {
                        puja_ganadora = p;
                        break;
                    }
                }
                if (puja_ganadora == null)
                {
                    Exception ex = new Exception("NO HAN HABIDO PUJAS :D");
                    throw ex;
                }
                else {
                    pujaCEN.Declarar_ganador(p_Puja_OID, puja_ganadora.Registrado.Id);
                    RegistradoCEN registradoCEN = new RegistradoCEN();
                    System.Console.WriteLine("PUJA FINALIZADA -- GANADOR: "+registradoCEN.get_IRegistradoCAD().ReadOIDDefault(puja_ganadora.Registrado.Id).N_usuario+"\n");
                }

                PujaEN pujaEN = null;
                //Initialized PujaEN
                pujaEN = new PujaEN ();
                pujaEN.Id = p_Puja_OID;
                pujaEN.Fecha = p_fecha;
                pujaEN.Puja_inicial = p_puja_inicial;
                pujaEN.Puja_max = p_puja_max;
                pujaEN.Id_usuario = p_id_usuario;
                pujaEN.Cerrada = p_cerrada;
                //Call to PujaCAD

                pujaCAD.Terminar_puja (pujaEN);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
