
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Carrito_finalizar_compra) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class CarritoCP : BasicCP
{
public void Finalizar_compra (int p_Carrito_OID, float p_precio)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_Carrito_finalizar_compra) ENABLED START*/

        ICarritoCAD carritoCAD = null;
        CarritoCEN carritoCEN = null;

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        IArticuloCAD articuloCAD = null;
        ArticuloCEN articuloCEN = null;


        try
        {
                SessionInitializeTransaction ();
                carritoCAD = new CarritoCAD (session);
                carritoCEN = new CarritoCEN (carritoCAD);

                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new PedidoCEN (pedidoCAD);

                articuloCAD = new ArticuloCAD (session); //SU CEN ESTA MAS ABAJO


                int usuario = carritoCEN.get_ICarritoCAD ().ReadOIDDefault (p_Carrito_OID).Registrado.Id;
                IList<LineaPedidoEN> listaLineas = carritoCEN.get_ICarritoCAD ().ReadOIDDefault (p_Carrito_OID).LineaPedido;

                //NEW PEDIDO
                int pedidoid = pedidoCEN.New_ ("", DateTime.Now, usuario);

                //ANYADIR LINEAS
                IList<int> lineasId = new List<int>();
                foreach (LineaPedidoEN linea in listaLineas) {
                        lineasId.Add (linea.Id);
                }

                pedidoCEN.Anyadir_linea (pedidoid, lineasId);

                //DECREMENTAR STOCK
                foreach (LineaPedidoEN linea in listaLineas) {
                        articuloCEN = new ArticuloCEN (articuloCAD);

                        if (!articuloCEN.Quitar_stock (linea.Articulo.Id, linea.Cantidad)) {
                                Exception ex = new Exception ("TE HAS PASADO DE CANTIDAD CHACHO");
                                throw ex;
                        }
                }

                CarritoEN carritoEN = carritoCEN.get_ICarritoCAD ().ReadOIDDefault (p_Carrito_OID);

                //VACIAR CARRITO
                carritoCEN.Vaciar_carrito (p_Carrito_OID, lineasId);

                carritoEN = carritoCEN.get_ICarritoCAD ().ReadOIDDefault (p_Carrito_OID);


                //CarritoEN carritoEN = null;
                carritoEN = null;

                //Initialized CarritoEN
                carritoEN = new CarritoEN ();
                carritoEN.Id = p_Carrito_OID;
                carritoEN.Precio = 0;

                //Call to CarritoCAD
                carritoCAD.Finalizar_compra (carritoEN);


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
