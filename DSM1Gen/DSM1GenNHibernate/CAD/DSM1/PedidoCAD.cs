
using System;
using System.Text;
using DSM1GenNHibernate.CEN.DSM1;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.Exceptions;


/*
 * Clase Pedido:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class PedidoCAD : BasicCAD, IPedidoCAD
{
public PedidoCAD() : base ()
{
}

public PedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PedidoEN ReadOIDDefault (int id
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Descripcion = pedido.Descripcion;


                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.Direccion = pedido.Direccion;


                pedidoEN.Localidad = pedido.Localidad;


                pedidoEN.Provincia = pedido.Provincia;


                pedidoEN.Cp = pedido.Cp;




                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (pedido.Registrado != null) {
                        // Argumento OID y no colección.
                        pedido.Registrado = (DSM1GenNHibernate.EN.DSM1.RegistradoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.RegistradoEN), pedido.Registrado.Id);

                        pedido.Registrado.Pedido
                        .Add (pedido);
                }
                if (pedido.Carrito != null) {
                        // Argumento OID y no colección.
                        pedido.Carrito = (DSM1GenNHibernate.EN.DSM1.CarritoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.CarritoEN), pedido.Carrito.Id);

                        pedido.Carrito.Pedido
                                = pedido;
                }

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.Id;
}

public void Modify (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Descripcion = pedido.Descripcion;


                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.Direccion = pedido.Direccion;


                pedidoEN.Localidad = pedido.Localidad;


                pedidoEN.Provincia = pedido.Provincia;


                pedidoEN.Cp = pedido.Cp;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), id);
                session.Delete (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Anyadir_linea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        DSM1GenNHibernate.EN.DSM1.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                DSM1GenNHibernate.EN.DSM1.LineaPedidoEN lineaPedidoENAux = null;
                if (pedidoEN.LineaPedido == null) {
                        pedidoEN.LineaPedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN>();
                }

                foreach (int item in p_lineaPedido_OIDs) {
                        lineaPedidoENAux = new DSM1GenNHibernate.EN.DSM1.LineaPedidoEN ();
                        lineaPedidoENAux = (DSM1GenNHibernate.EN.DSM1.LineaPedidoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.LineaPedidoEN), item);
                        lineaPedidoENAux.Pedido = pedidoEN;

                        pedidoEN.LineaPedido.Add (lineaPedidoENAux);
                }


                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int Terminar_compra (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (pedido.Registrado != null) {
                        // Argumento OID y no colección.
                        pedido.Registrado = (DSM1GenNHibernate.EN.DSM1.RegistradoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.RegistradoEN), pedido.Registrado.Id);

                        pedido.Registrado.Pedido
                        .Add (pedido);
                }
                if (pedido.Carrito != null) {
                        // Argumento OID y no colección.
                        pedido.Carrito = (DSM1GenNHibernate.EN.DSM1.CarritoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.CarritoEN), pedido.Carrito.Id);

                        pedido.Carrito.Pedido
                                = pedido;
                }

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.Id;
}
}
}
