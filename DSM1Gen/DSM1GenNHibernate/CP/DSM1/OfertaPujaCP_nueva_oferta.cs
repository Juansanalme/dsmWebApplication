
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_OfertaPuja_nueva_oferta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class OfertaPujaCP : BasicCP
{
public DSM1GenNHibernate.EN.DSM1.OfertaPujaEN Nueva_oferta (Nullable<DateTime> p_fecha, Nullable<DateTime> p_tiempo, int p_registrado, int p_puja, float p_cantidad_puja)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_OfertaPuja_nueva_oferta) ENABLED START*/

        IOfertaPujaCAD ofertaPujaCAD = null;
        OfertaPujaCEN ofertaPujaCEN = null;

        DSM1GenNHibernate.EN.DSM1.OfertaPujaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                ofertaPujaCAD = new OfertaPujaCAD (session);
                ofertaPujaCEN = new  OfertaPujaCEN (ofertaPujaCAD);




                int oid;
                //Initialized OfertaPujaEN
                OfertaPujaEN ofertaPujaEN;
                ofertaPujaEN = new OfertaPujaEN ();
                ofertaPujaEN.Fecha = p_fecha;

                ofertaPujaEN.Tiempo = p_tiempo;


                if (p_registrado != -1) {
                        ofertaPujaEN.Registrado = new DSM1GenNHibernate.EN.DSM1.RegistradoEN ();
                        ofertaPujaEN.Registrado.Id = p_registrado;
                }


                if (p_puja != -1) {
                        ofertaPujaEN.Puja = new DSM1GenNHibernate.EN.DSM1.PujaEN ();
                        ofertaPujaEN.Puja.Id = p_puja;
                }

                ofertaPujaEN.Cantidad_puja = p_cantidad_puja;

                //Call to OfertaPujaCAD

                oid = ofertaPujaCAD.Nueva_oferta (ofertaPujaEN);
                result = ofertaPujaCAD.ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
