
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_LineaPedido_anyado_lineaYprecio) ENABLED START*/
//  references to other libraries
using DSM1GenNHibernate.CP.DSM1;
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class LineaPedidoCEN
{
public void Anyado_lineaYprecio (int p_oid, int p_carrito_oid, int p_cantidad, int p_articulo_oid)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_LineaPedido_anyado_lineaYprecio) ENABLED START*/

        // Write here your custom code...

            LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN ();
            CarritoCEN carritoCEN = new CarritoCEN();
            CarritoCP carritoCP = new CarritoCP();

            //CREA UNA NUEVA LINEA DE PEDIDO
            int linpedId = lineaPedidoCEN.New_(p_cantidad, p_articulo_oid);

            //AÑADE AL CARRITO
            lineaPedidoCEN.Anyadir_producto(linpedId, p_carrito_oid);

            //CALCULA EL PRECIO DEL CARRITO
            carritoCP.Calcular_precio(p_carrito_oid, 0);


        //throw new NotImplementedException ("Method Anyado_lineaYprecio() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
