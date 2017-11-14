
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_LineaPedido_anyado_linea_a_carroYprecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class LineaPedidoCP : BasicCP
{
public DSM1GenNHibernate.EN.DSM1.LineaPedidoEN Anyado_linea_a_carroYprecio (int p_cantidad, int p_articulo)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_LineaPedido_anyado_linea_a_carroYprecio) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;

        DSM1GenNHibernate.EN.DSM1.LineaPedidoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new  LineaPedidoCEN (lineaPedidoCAD);




                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();
                lineaPedidoEN.Cantidad = p_cantidad;


                if (p_articulo != -1) {
                        lineaPedidoEN.Articulo = new DSM1GenNHibernate.EN.DSM1.ArticuloEN ();
                        lineaPedidoEN.Articulo.Id = p_articulo;
                }

                //Call to LineaPedidoCAD

                oid = lineaPedidoCAD.Anyado_linea_a_carroYprecio (lineaPedidoEN);
                result = lineaPedidoCAD.ReadOIDDefault (oid);



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
