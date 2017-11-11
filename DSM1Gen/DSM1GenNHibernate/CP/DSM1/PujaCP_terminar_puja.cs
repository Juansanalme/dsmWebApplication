
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
//  references to other libraries
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
                SessionInitializeTransaction ();
                pujaCAD = new PujaCAD (session);
                pujaCEN = new  PujaCEN (pujaCAD);




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
