
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


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_Carrito_vaciar_carrito) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class CarritoCEN
{
public void Vaciar_carrito (int p_oid)
{
            /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_Carrito_vaciar_carrito) ENABLED START*/

            // Write here your custom code...

            CarritoEN carritoEN = null;
            CarritoCEN carritoCEN = null;
            
            //ICarritoCAD
            carritoEN = _ICarritoCAD.ReadOIDDefault(p_oid);
            /*
            carritoCEN = new ArticuloCEN()

            foreach (LineaPedidoEN linea in carritoEN.LineaPedido)
            {
                CarritoCEN.
            }
            */
            

            //throw new NotImplementedException ("Method Vaciar_carrito() not yet implemented.");

            /*PROTECTED REGION END*/
        }
}
}
