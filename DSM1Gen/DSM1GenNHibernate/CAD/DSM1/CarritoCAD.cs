
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
 * Clase Carrito:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class CarritoCAD : BasicCAD, ICarritoCAD
{
public CarritoCAD() : base ()
{
}

public CarritoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CarritoEN ReadOIDDefault (int id
                                 )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CarritoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(CarritoEN)).List<CarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoEN carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), carrito.Id);

                carritoEN.Cantidad = carrito.Cantidad;


                carritoEN.Fecha_anyadido = carrito.Fecha_anyadido;






                carritoEN.Precio = carrito.Precio;

                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                if (carrito.Registrado != null) {
                        // Argumento OID y no colección.
                        carrito.Registrado = (DSM1GenNHibernate.EN.DSM1.RegistradoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.RegistradoEN), carrito.Registrado.Id);

                        carrito.Registrado.Carrito
                                = carrito;
                }

                session.Save (carrito);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carrito.Id;
}

public void Modify (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoEN carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), carrito.Id);

                carritoEN.Cantidad = carrito.Cantidad;


                carritoEN.Fecha_anyadido = carrito.Fecha_anyadido;


                carritoEN.Precio = carrito.Precio;

                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
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
                CarritoEN carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), id);
                session.Delete (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Eliminar_producto (int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DSM1GenNHibernate.EN.DSM1.CarritoEN carritoEN = null;
                carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), p_Carrito_OID);

                DSM1GenNHibernate.EN.DSM1.ArticuloEN articuloENAux = null;
                if (carritoEN.Articulo != null) {
                        foreach (int item in p_articulo_OIDs) {
                                articuloENAux = (DSM1GenNHibernate.EN.DSM1.ArticuloEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.ArticuloEN), item);
                                if (carritoEN.Articulo.Contains (articuloENAux) == true) {
                                        carritoEN.Articulo.Remove (articuloENAux);
                                        articuloENAux.Carrito.Remove (carritoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_articulo_OIDs you are trying to unrelationer, doesn't exist in CarritoEN");
                        }
                }

                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: Ver_detalles
//Con e: CarritoEN
public CarritoEN Ver_detalles (int id
                               )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public void Anyadir_producto (int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        DSM1GenNHibernate.EN.DSM1.CarritoEN carritoEN = null;
        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Load (typeof(CarritoEN), p_Carrito_OID);
                DSM1GenNHibernate.EN.DSM1.ArticuloEN articuloENAux = null;
                if (carritoEN.Articulo == null) {
                        carritoEN.Articulo = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ArticuloEN>();
                }

                foreach (int item in p_articulo_OIDs) {
                        articuloENAux = new DSM1GenNHibernate.EN.DSM1.ArticuloEN ();
                        articuloENAux = (DSM1GenNHibernate.EN.DSM1.ArticuloEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.ArticuloEN), item);
                        articuloENAux.Carrito.Add (carritoEN);

                        carritoEN.Articulo.Add (articuloENAux);
                }


                session.Update (carritoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CarritoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
