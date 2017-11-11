
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using System.Collections.Generic;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Carrito_finalizar_compra) ENABLED START*/
//  references to other libraries
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
                SessionInitializeTransaction();
                carritoCAD = new CarritoCAD(session);
                carritoCEN = new CarritoCEN(carritoCAD);

                pedidoCAD = new PedidoCAD(session);
                pedidoCEN = new PedidoCEN(pedidoCAD);

                articuloCAD = new ArticuloCAD(session); //SU CEN ESTA MAS ABAJO


                int usuario = carritoCEN.get_ICarritoCAD().ReadOIDDefault(p_Carrito_OID).Registrado.Id;
                IList<LineaPedidoEN> listaLineas = carritoCEN.get_ICarritoCAD().ReadOIDDefault(p_Carrito_OID).LineaPedido;

                //NEW PEDIDO
                int pedidoid = pedidoCEN.New_("", DateTime.Now, usuario, p_Carrito_OID);

                //ANYADIR LINEAS
                IList<int> lineas = null;
                foreach (LineaPedidoEN linea in listaLineas)
                {
                    lineas.Add(linea.Id);
                }

                pedidoCEN.Anyadir_linea(pedidoid, lineas);

                //DECREMENTAR STOCK
                foreach (LineaPedidoEN linea in listaLineas)
                { 
                    
                    articuloCEN = new ArticuloCEN(articuloCAD);

                    if (!articuloCEN.Quitar_stock(linea.Articulo.Id, linea.Cantidad))
                    {
                        Exception ex = new Exception("TE HAS PASADO DE CANTIDAD CHACHO");
                        throw ex;
                    }

                }

                //VACIAR CARRITO
                carritoCEN.Vaciar_carrito(p_Carrito_OID, lineas);

                


                CarritoEN carritoEN = null;
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
