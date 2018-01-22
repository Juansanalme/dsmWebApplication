
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_LineaPedido_anyado_lineaYprecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class LineaPedidoCP : BasicCP
{
public DSM1GenNHibernate.EN.DSM1.LineaPedidoEN Anyado_lineaYprecio (int p_cantidad, int p_articulo, int p_carrito_oid)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_LineaPedido_anyado_lineaYprecio) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;

        ICarritoCAD carritoCAD = null;
        CarritoCEN carritoCEN = null;
        CarritoCP carritoCP = null;

        DSM1GenNHibernate.EN.DSM1.LineaPedidoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new  LineaPedidoCEN (lineaPedidoCAD);

                carritoCAD = new CarritoCAD (session);
                carritoCEN = new CarritoCEN (carritoCAD);
                carritoCP = new CarritoCP (session);

                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();
                lineaPedidoEN.Cantidad = p_cantidad;

                if (p_articulo != -1) {
                        lineaPedidoEN.Articulo = new DSM1GenNHibernate.EN.DSM1.ArticuloEN ();
                        lineaPedidoEN.Articulo.Id = p_articulo;
                }

                //lineaPedidoEN.Carrito_oid = p_carrito_oid;

                //Call to LineaPedidoCAD

                oid = lineaPedidoCAD.Anyado_lineaYprecio (lineaPedidoEN);
                result = lineaPedidoCAD.ReadOIDDefault (oid);

                //RELACIONO LINEA CON CARRITO
                lineaPedidoCEN.Anyadir_producto (oid, p_carrito_oid);

                //CALCULO PRECIO CARRITO
                carritoCP.Calcular_precio (p_carrito_oid);



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
