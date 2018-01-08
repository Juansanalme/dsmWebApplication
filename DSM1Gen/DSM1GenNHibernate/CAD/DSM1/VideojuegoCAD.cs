
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
 * Clase Videojuego:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class VideojuegoCAD : BasicCAD, IVideojuegoCAD
{
public VideojuegoCAD() : base ()
{
}

public VideojuegoCAD(ISession sessionAux) : base (sessionAux)
{
}



public VideojuegoEN ReadOIDDefault (int id
                                    )
{
        VideojuegoEN videojuegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videojuegoEN = (VideojuegoEN)session.Get (typeof(VideojuegoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videojuegoEN;
}

public System.Collections.Generic.IList<VideojuegoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VideojuegoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VideojuegoEN>();
                        else
                                result = session.CreateCriteria (typeof(VideojuegoEN)).List<VideojuegoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VideojuegoEN videojuego)
{
        try
        {
                SessionInitializeTransaction ();
                VideojuegoEN videojuegoEN = (VideojuegoEN)session.Load (typeof(VideojuegoEN), videojuego.Id);


                videojuegoEN.Nombre = videojuego.Nombre;


                videojuegoEN.Imagen = videojuego.Imagen;

                session.Update (videojuegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (VideojuegoEN videojuego)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (videojuego);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videojuego.Id;
}

public void Modify (VideojuegoEN videojuego)
{
        try
        {
                SessionInitializeTransaction ();
                VideojuegoEN videojuegoEN = (VideojuegoEN)session.Load (typeof(VideojuegoEN), videojuego.Id);

                videojuegoEN.Nombre = videojuego.Nombre;


                videojuegoEN.Imagen = videojuego.Imagen;

                session.Update (videojuegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
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
                VideojuegoEN videojuegoEN = (VideojuegoEN)session.Load (typeof(VideojuegoEN), id);
                session.Delete (videojuegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<VideojuegoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VideojuegoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VideojuegoEN>();
                else
                        result = session.CreateCriteria (typeof(VideojuegoEN)).List<VideojuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in VideojuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
