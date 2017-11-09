
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
 * Clase Registrado:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class RegistradoCAD : BasicCAD, IRegistradoCAD
{
public RegistradoCAD() : base ()
{
}

public RegistradoCAD(ISession sessionAux) : base (sessionAux)
{
}



public RegistradoEN ReadOIDDefault (int id
                                    )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RegistradoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RegistradoEN>();
                        else
                                result = session.CreateCriteria (typeof(RegistradoEN)).List<RegistradoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), registrado.Id);

                registradoEN.Nombre = registrado.Nombre;


                registradoEN.Apellidos = registrado.Apellidos;


                registradoEN.Edad = registrado.Edad;


                registradoEN.Fecha_nac = registrado.Fecha_nac;


                registradoEN.Dni = registrado.Dni;


                registradoEN.Contraseña = registrado.Contraseña;


                registradoEN.N_usuario = registrado.N_usuario;








                registradoEN.Admin = registrado.Admin;

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Añadir_fav (int p_Registrado_OID, System.Collections.Generic.IList<int> p_a_favorito_OIDs)
{
        DSM1GenNHibernate.EN.DSM1.RegistradoEN registradoEN = null;
        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), p_Registrado_OID);
                DSM1GenNHibernate.EN.DSM1.ArticuloEN a_favoritoENAux = null;
                if (registradoEN.A_favorito == null) {
                        registradoEN.A_favorito = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ArticuloEN>();
                }

                foreach (int item in p_a_favorito_OIDs) {
                        a_favoritoENAux = new DSM1GenNHibernate.EN.DSM1.ArticuloEN ();
                        a_favoritoENAux = (DSM1GenNHibernate.EN.DSM1.ArticuloEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.ArticuloEN), item);
                        a_favoritoENAux.Registrado.Add (registradoEN);

                        registradoEN.A_favorito.Add (a_favoritoENAux);
                }


                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Eliminar_fav (int p_Registrado_OID, System.Collections.Generic.IList<int> p_a_favorito_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DSM1GenNHibernate.EN.DSM1.RegistradoEN registradoEN = null;
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), p_Registrado_OID);

                DSM1GenNHibernate.EN.DSM1.ArticuloEN a_favoritoENAux = null;
                if (registradoEN.A_favorito != null) {
                        foreach (int item in p_a_favorito_OIDs) {
                                a_favoritoENAux = (DSM1GenNHibernate.EN.DSM1.ArticuloEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.ArticuloEN), item);
                                if (registradoEN.A_favorito.Contains (a_favoritoENAux) == true) {
                                        registradoEN.A_favorito.Remove (a_favoritoENAux);
                                        a_favoritoENAux.Registrado.Remove (registradoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_a_favorito_OIDs you are trying to unrelationer, doesn't exist in RegistradoEN");
                        }
                }

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public int New_ (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (registrado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registrado.Id;
}

public void Modify (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), registrado.Id);

                registradoEN.Nombre = registrado.Nombre;


                registradoEN.Apellidos = registrado.Apellidos;


                registradoEN.Edad = registrado.Edad;


                registradoEN.Fecha_nac = registrado.Fecha_nac;


                registradoEN.Dni = registrado.Dni;


                registradoEN.Contraseña = registrado.Contraseña;


                registradoEN.N_usuario = registrado.N_usuario;


                registradoEN.Admin = registrado.Admin;

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
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
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), id);
                session.Delete (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: Ver_detalles_oid
//Con e: RegistradoEN
public RegistradoEN Ver_detalles_oid (int id
                                      )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}
}
}
