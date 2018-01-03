
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

        IPujaCAD pujaCAD = null;
        PujaCEN pujaCEN = null;

        DSM1GenNHibernate.EN.DSM1.OfertaPujaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                ofertaPujaCAD = new OfertaPujaCAD (session);
                ofertaPujaCEN = new  OfertaPujaCEN (ofertaPujaCAD);

                pujaCAD = new PujaCAD (session);
                pujaCEN = new PujaCEN (pujaCAD);

                PujaEN pujaEN = pujaCEN.get_IPujaCAD ().ReadOIDDefault (p_puja);  //Consigo la puja a la cual va dirigida esta oferta

                if (pujaEN.Cerrada == true) {
                        Exception cerrada = new Exception ("Está cerrada, largo de aquí!");
                        throw cerrada;
                }

                if (pujaEN.Id_usuario == p_registrado) {
                        Exception PP = new Exception ("Ya eres el máximo pujador, vuelve más tarde");
                        throw PP;
                }

                if (pujaEN.Puja_max < p_cantidad_puja && pujaEN.Puja_inicial < p_cantidad_puja) {
                        //System.Console.WriteLine("NUEVA PUJA! "+p_registrado + " "+p_puja+ " "+p_cantidad_puja+"�");
                        PujaEN nueva = new PujaEN ();
                        nueva.Id = pujaEN.Id;
                        nueva.Fecha = pujaEN.Fecha;
                        nueva.Puja_inicial = pujaEN.Puja_inicial;

                        nueva.Puja_max = p_cantidad_puja; //Cambiamos la puja max
                        nueva.Id_usuario = p_registrado; //Y el usuario

                        nueva.Cerrada = pujaEN.Cerrada;

                        pujaCEN.get_IPujaCAD ().Actualizar (nueva); //Actualizamos
                }
                else{
                        Exception pasta = new Exception ("Debes introducir un importe mayor!");
                        throw pasta;
                }
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
