
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_LineaPedido_quito_linea_a_carroYprecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class LineaPedidoCP : BasicCP
{
public void Quito_linea_a_carroYprecio (int p_LineaPedido_OID)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_LineaPedido_quito_linea_a_carroYprecio) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;

        ICarritoCAD carritoCAD = null;
        CarritoCEN carritoCEN = null;
        CarritoCP carritoCP = null;


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new  LineaPedidoCEN (lineaPedidoCAD);

                carritoCAD = new CarritoCAD (session);
                carritoCEN = new CarritoCEN (carritoCAD);
                carritoCP = new CarritoCP (session);

                int carritoId = lineaPedidoCAD.ReadOIDDefault (p_LineaPedido_OID).Carrito.Id;

                //ELIMINO LA RELACION LINPED CON CARRITO
                lineaPedidoCEN.Eliminar_producto (p_LineaPedido_OID, carritoId);

                //CALCULO PRECIO DEL CARRITO
                carritoCP.Calcular_precio (carritoId);

                //DESTROY CP
                lineaPedidoCAD.Quito_linea_a_carroYprecio (p_LineaPedido_OID);


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
