
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Pedido_terminar_compra) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class PedidoCP : BasicCP
{
public DSM1GenNHibernate.EN.DSM1.PedidoEN Terminar_compra (string p_descripcion, Nullable<DateTime> p_fecha, string p_direccion, string p_localidad, string p_provincia, int p_cp, int p_registrado, int p_carrito)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_Pedido_terminar_compra) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        DSM1GenNHibernate.EN.DSM1.PedidoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);




                int oid;
                //Initialized PedidoEN
                PedidoEN pedidoEN;
                pedidoEN = new PedidoEN ();
                pedidoEN.Descripcion = p_descripcion;

                pedidoEN.Fecha = p_fecha;

                pedidoEN.Direccion = p_direccion;

                pedidoEN.Localidad = p_localidad;

                pedidoEN.Provincia = p_provincia;

                pedidoEN.Cp = p_cp;


                if (p_registrado != -1) {
                        pedidoEN.Registrado = new DSM1GenNHibernate.EN.DSM1.RegistradoEN ();
                        pedidoEN.Registrado.Id = p_registrado;
                }


                if (p_carrito != -1) {
                        pedidoEN.Carrito = new DSM1GenNHibernate.EN.DSM1.CarritoEN ();
                        pedidoEN.Carrito.Id = p_carrito;
                }

                //Call to PedidoCAD

                oid = pedidoCAD.Terminar_compra (pedidoEN);
                result = pedidoCAD.ReadOIDDefault (oid);



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
