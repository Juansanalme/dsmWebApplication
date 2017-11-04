
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
 * Clase OfertaPuja:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class OfertaPujaCAD : BasicCAD, IOfertaPujaCAD
{
public OfertaPujaCAD() : base ()
{
}

public OfertaPujaCAD(ISession sessionAux) : base (sessionAux)
{
}



public OfertaPujaEN ReadOIDDefault (int id
                                    )
{
        OfertaPujaEN ofertaPujaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ofertaPujaEN = (OfertaPujaEN)session.Get (typeof(OfertaPujaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in OfertaPujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ofertaPujaEN;
}

public System.Collections.Generic.IList<OfertaPujaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<OfertaPujaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(OfertaPujaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<OfertaPujaEN>();
                        else
                                result = session.CreateCriteria (typeof(OfertaPujaEN)).List<OfertaPujaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in OfertaPujaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (OfertaPujaEN ofertaPuja)
{
        try
        {
                SessionInitializeTransaction ();
                OfertaPujaEN ofertaPujaEN = (OfertaPujaEN)session.Load (typeof(OfertaPujaEN), ofertaPuja.Id);

                ofertaPujaEN.Fecha = ofertaPuja.Fecha;


                ofertaPujaEN.Tiempo = ofertaPuja.Tiempo;




                ofertaPujaEN.Cantidad_puja = ofertaPuja.Cantidad_puja;

                session.Update (ofertaPujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in OfertaPujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (OfertaPujaEN ofertaPuja)
{
        try
        {
                SessionInitializeTransaction ();
                if (ofertaPuja.Registrado != null) {
                        // Argumento OID y no colección.
                        ofertaPuja.Registrado = (DSM1GenNHibernate.EN.DSM1.RegistradoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.RegistradoEN), ofertaPuja.Registrado.Id);

                        ofertaPuja.Registrado.OfertaPuja
                        .Add (ofertaPuja);
                }
                if (ofertaPuja.Puja != null) {
                        // Argumento OID y no colección.
                        ofertaPuja.Puja = (DSM1GenNHibernate.EN.DSM1.PujaEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.PujaEN), ofertaPuja.Puja.Id);

                        ofertaPuja.Puja.OfertaPuja
                        .Add (ofertaPuja);
                }

                session.Save (ofertaPuja);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in OfertaPujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ofertaPuja.Id;
}

public void Modify (OfertaPujaEN ofertaPuja)
{
        try
        {
                SessionInitializeTransaction ();
                OfertaPujaEN ofertaPujaEN = (OfertaPujaEN)session.Load (typeof(OfertaPujaEN), ofertaPuja.Id);

                ofertaPujaEN.Fecha = ofertaPuja.Fecha;


                ofertaPujaEN.Tiempo = ofertaPuja.Tiempo;


                ofertaPujaEN.Cantidad_puja = ofertaPuja.Cantidad_puja;

                session.Update (ofertaPujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in OfertaPujaCAD.", ex);
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
                OfertaPujaEN ofertaPujaEN = (OfertaPujaEN)session.Load (typeof(OfertaPujaEN), id);
                session.Delete (ofertaPujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in OfertaPujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
