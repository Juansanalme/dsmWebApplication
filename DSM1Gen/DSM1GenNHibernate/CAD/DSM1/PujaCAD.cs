
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
 * Clase Puja:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class PujaCAD : BasicCAD, IPujaCAD
{
public PujaCAD() : base ()
{
}

public PujaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PujaEN ReadOIDDefault (int id
                              )
{
        PujaEN pujaEN = null;

        try
        {
                SessionInitializeTransaction ();
                pujaEN = (PujaEN)session.Get (typeof(PujaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pujaEN;
}

public System.Collections.Generic.IList<PujaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PujaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PujaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PujaEN>();
                        else
                                result = session.CreateCriteria (typeof(PujaEN)).List<PujaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PujaEN puja)
{
        try
        {
                SessionInitializeTransaction ();
                PujaEN pujaEN = (PujaEN)session.Load (typeof(PujaEN), puja.Id);

                pujaEN.Fecha = puja.Fecha;


                pujaEN.Puja_inicial = puja.Puja_inicial;




                pujaEN.Puja_max = puja.Puja_max;



                pujaEN.Id_usuario = puja.Id_usuario;


                pujaEN.Cerrada = puja.Cerrada;

                session.Update (pujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PujaEN puja)
{
        try
        {
                SessionInitializeTransaction ();
                if (puja.Articulo != null) {
                        // Argumento OID y no colección.
                        puja.Articulo = (DSM1GenNHibernate.EN.DSM1.ArticuloEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.ArticuloEN), puja.Articulo.Id);

                        puja.Articulo.Puja
                                = puja;
                }

                session.Save (puja);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return puja.Id;
}

public void Modify (PujaEN puja)
{
        try
        {
                SessionInitializeTransaction ();
                PujaEN pujaEN = (PujaEN)session.Load (typeof(PujaEN), puja.Id);

                pujaEN.Fecha = puja.Fecha;


                pujaEN.Puja_inicial = puja.Puja_inicial;


                pujaEN.Puja_max = puja.Puja_max;


                pujaEN.Id_usuario = puja.Id_usuario;


                pujaEN.Cerrada = puja.Cerrada;

                session.Update (pujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
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
                PujaEN pujaEN = (PujaEN)session.Load (typeof(PujaEN), id);
                session.Delete (pujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Actualizar (PujaEN puja)
{
        try
        {
                SessionInitializeTransaction ();
                PujaEN pujaEN = (PujaEN)session.Load (typeof(PujaEN), puja.Id);

                pujaEN.Fecha = puja.Fecha;


                pujaEN.Puja_inicial = puja.Puja_inicial;


                pujaEN.Puja_max = puja.Puja_max;


                pujaEN.Id_usuario = puja.Id_usuario;


                pujaEN.Cerrada = puja.Cerrada;

                session.Update (pujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Declarar_ganador (int p_Puja_OID, int p_usuarioGanador_OID)
{
        DSM1GenNHibernate.EN.DSM1.PujaEN pujaEN = null;
        try
        {
                SessionInitializeTransaction ();
                pujaEN = (PujaEN)session.Load (typeof(PujaEN), p_Puja_OID);
                pujaEN.UsuarioGanador = (DSM1GenNHibernate.EN.DSM1.RegistradoEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.RegistradoEN), p_usuarioGanador_OID);

                pujaEN.UsuarioGanador.PujaGanadora.Add (pujaEN);



                session.Update (pujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Terminar_puja (PujaEN puja)
{
        try
        {
                SessionInitializeTransaction ();
                PujaEN pujaEN = (PujaEN)session.Load (typeof(PujaEN), puja.Id);

                pujaEN.Fecha = puja.Fecha;


                pujaEN.Puja_inicial = puja.Puja_inicial;


                pujaEN.Puja_max = puja.Puja_max;


                pujaEN.Id_usuario = puja.Id_usuario;


                pujaEN.Cerrada = puja.Cerrada;

                session.Update (pujaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<PujaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PujaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PujaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PujaEN>();
                else
                        result = session.CreateCriteria (typeof(PujaEN)).List<PujaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in PujaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
