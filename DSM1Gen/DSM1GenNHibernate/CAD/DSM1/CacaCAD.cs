
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
 * Clase Caca:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class CacaCAD : BasicCAD, ICacaCAD
{
public CacaCAD() : base ()
{
}

public CacaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CacaEN ReadOIDDefault (string NIF
                              )
{
        CacaEN cacaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cacaEN = (CacaEN)session.Get (typeof(CacaEN), NIF);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CacaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cacaEN;
}

public System.Collections.Generic.IList<CacaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CacaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CacaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CacaEN>();
                        else
                                result = session.CreateCriteria (typeof(CacaEN)).List<CacaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CacaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CacaEN caca)
{
        try
        {
                SessionInitializeTransaction ();
                CacaEN cacaEN = (CacaEN)session.Load (typeof(CacaEN), caca.NIF);

                cacaEN.Nombre = caca.Nombre;


                cacaEN.FNacimiento = caca.FNacimiento;


                session.Update (cacaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CacaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Crear (CacaEN caca)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (caca);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CacaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caca.NIF;
}
}
}
