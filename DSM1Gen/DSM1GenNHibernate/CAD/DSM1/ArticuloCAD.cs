
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
 * Clase Articulo:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class ArticuloCAD : BasicCAD, IArticuloCAD
{
public ArticuloCAD() : base ()
{
}

public ArticuloCAD(ISession sessionAux) : base (sessionAux)
{
}



public ArticuloEN ReadOIDDefault (int id
                                  )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ArticuloEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                        else
                                result = session.CreateCriteria (typeof(ArticuloEN)).List<ArticuloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloEN articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), articulo.Id);

                articuloEN.Nombre = articulo.Nombre;


                articuloEN.Precio = articulo.Precio;







                articuloEN.Descripcion = articulo.Descripcion;


                articuloEN.Stock = articulo.Stock;

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                if (articulo.Categoria != null) {
                        // Argumento OID y no colección.
                        articulo.Categoria = (DSM1GenNHibernate.EN.DSM1.CategoriaEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.CategoriaEN), articulo.Categoria.Id);

                        articulo.Categoria.Articulo_0
                        .Add (articulo);
                }

                session.Save (articulo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articulo.Id;
}

public void Modify (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloEN articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), articulo.Id);

                articuloEN.Nombre = articulo.Nombre;


                articuloEN.Precio = articulo.Precio;


                articuloEN.Descripcion = articulo.Descripcion;


                articuloEN.Stock = articulo.Stock;

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
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
                ArticuloEN articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), id);
                session.Delete (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: Ver_detalles
//Con e: ArticuloEN
public ArticuloEN Ver_detalles (int id
                                )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}
}
}
