
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
 * Clase Admin:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class AdminCAD : BasicCAD, IAdminCAD
{
public AdminCAD() : base ()
{
}

public AdminCAD(ISession sessionAux) : base (sessionAux)
{
}



public AdminEN ReadOIDDefault (int id
                               )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdminEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                        else
                                result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.Id);
                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                if (admin.Carrito != null) {
                        // p_carrito
                        admin.Carrito.Registrado = admin;
                        session.Save (admin.Carrito);
                }

                session.Save (admin);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return admin.Id;
}

public void Modify (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.Id);

                adminEN.Nombre = admin.Nombre;


                adminEN.Apellidos = admin.Apellidos;


                adminEN.Edad = admin.Edad;


                adminEN.Fecha_nac = admin.Fecha_nac;


                adminEN.Dni = admin.Dni;


                adminEN.Contraseña = admin.Contraseña;


                adminEN.N_usuario = admin.N_usuario;

                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
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
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), id);
                session.Delete (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
