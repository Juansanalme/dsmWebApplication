
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Carrito_terminar_compra) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class CarritoCP : BasicCP
{
public DSM1GenNHibernate.EN.DSM1.CarritoEN Terminar_compra (Nullable<DateTime> p_fecha_anyadido, int p_registrado, float p_precio)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_Carrito_terminar_compra) ENABLED START*/

        ICarritoCAD carritoCAD = null;
        CarritoCEN carritoCEN = null;

        DSM1GenNHibernate.EN.DSM1.CarritoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                carritoCAD = new CarritoCAD (session);
                carritoCEN = new  CarritoCEN (carritoCAD);




                int oid;
                //Initialized CarritoEN
                CarritoEN carritoEN;
                carritoEN = new CarritoEN ();
                carritoEN.Fecha_anyadido = p_fecha_anyadido;


                if (p_registrado != -1) {
                        carritoEN.Registrado = new DSM1GenNHibernate.EN.DSM1.RegistradoEN ();
                        carritoEN.Registrado.Id = p_registrado;
                }

                carritoEN.Precio = p_precio;

                //Call to CarritoCAD

                oid = carritoCAD.Terminar_compra (carritoEN);
                result = carritoCAD.ReadOIDDefault (oid);



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
