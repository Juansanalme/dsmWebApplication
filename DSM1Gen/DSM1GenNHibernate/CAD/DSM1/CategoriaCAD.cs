
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
 * Clase Categoria:
 *
 */

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial class CategoriaCAD : BasicCAD, ICategoriaCAD
{
public CategoriaCAD() : base ()
{
}

public CategoriaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CategoriaEN ReadOIDDefault (int id
                                   )
{
        CategoriaEN categoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Get (typeof(CategoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaEN)).List<CategoriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), categoria.Id);

                categoriaEN.Nombre = categoria.Nombre;


                categoriaEN.Articulo = categoria.Articulo;




                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (categoria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoria.Id;
}

public void Modify (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), categoria.Id);

                categoriaEN.Nombre = categoria.Nombre;


                categoriaEN.Articulo = categoria.Articulo;

                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
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
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), id);
                session.Delete (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Anyadir_supercat (int p_Categoria_OID, int p_supercategoria_OID)
{
        DSM1GenNHibernate.EN.DSM1.CategoriaEN categoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), p_Categoria_OID);
                categoriaEN.Supercategoria = (DSM1GenNHibernate.EN.DSM1.CategoriaEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.CategoriaEN), p_supercategoria_OID);

                categoriaEN.Supercategoria.Subcategoria.Add (categoriaEN);



                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<CategoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CategoriaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                else
                        result = session.CreateCriteria (typeof(CategoriaEN)).List<CategoriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Quitar_supercat (int p_Categoria_OID, int p_supercategoria_OID)
{
        try
        {
                SessionInitializeTransaction ();
                DSM1GenNHibernate.EN.DSM1.CategoriaEN categoriaEN = null;
                categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), p_Categoria_OID);

                if (categoriaEN.Supercategoria.Id == p_supercategoria_OID) {
                        categoriaEN.Supercategoria = null;
                }
                else
                        throw new ModelException ("The identifier " + p_supercategoria_OID + " in p_supercategoria_OID you are trying to unrelationer, doesn't exist in CategoriaEN");

                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Quitar_subcat (int p_Categoria_OID, System.Collections.Generic.IList<int> p_subcategoria_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                DSM1GenNHibernate.EN.DSM1.CategoriaEN categoriaEN = null;
                categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), p_Categoria_OID);

                DSM1GenNHibernate.EN.DSM1.CategoriaEN subcategoriaENAux = null;
                if (categoriaEN.Subcategoria != null) {
                        foreach (int item in p_subcategoria_OIDs) {
                                subcategoriaENAux = (DSM1GenNHibernate.EN.DSM1.CategoriaEN)session.Load (typeof(DSM1GenNHibernate.EN.DSM1.CategoriaEN), item);
                                if (categoriaEN.Subcategoria.Contains (subcategoriaENAux) == true) {
                                        categoriaEN.Subcategoria.Remove (subcategoriaENAux);
                                        subcategoriaENAux.Supercategoria = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_subcategoria_OIDs you are trying to unrelationer, doesn't exist in CategoriaEN");
                        }
                }

                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSM1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSM1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
