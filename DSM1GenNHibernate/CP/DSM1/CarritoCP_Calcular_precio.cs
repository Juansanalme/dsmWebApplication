
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Carrito_calcular_precio) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class CarritoCP : BasicCP
{
public void Calcular_precio (int p_Carrito_OID)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_Carrito_calcular_precio) ENABLED START*/

        ICarritoCAD carritoCAD = null;
        CarritoCEN carritoCEN = null;

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoCAD = new CarritoCAD (session);
                carritoCEN = new  CarritoCEN (carritoCAD);

                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new LineaPedidoCEN (lineaPedidoCAD);

                double nuevoPrecio = 0;

                IList<LineaPedidoEN> listaLineas = carritoCEN.get_ICarritoCAD ().ReadOIDDefault (p_Carrito_OID).LineaPedido;

                //ANYADIR LINEAS
                foreach (LineaPedidoEN linea in listaLineas) {
                        nuevoPrecio += linea.Articulo.Precio * linea.Cantidad;
                }



                CarritoEN carritoEN = null;
                //Initialized CarritoEN
                carritoEN = new CarritoEN ();
                carritoEN.Id = p_Carrito_OID;
                carritoEN.Precio = (float)nuevoPrecio;
                //Call to CarritoCAD

                carritoCAD.Calcular_precio (carritoEN);
                carritoCAD.ModifyDefault (carritoEN);

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
