

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.Exceptions;

using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;


namespace DSM1GenNHibernate.CEN.DSM1
{
/*
 *      Definition of the class CategoriaCEN
 *
 */
public partial class CategoriaCEN
{
private ICategoriaCAD _ICategoriaCAD;

public CategoriaCEN()
{
        this._ICategoriaCAD = new CategoriaCAD ();
}

public CategoriaCEN(ICategoriaCAD _ICategoriaCAD)
{
        this._ICategoriaCAD = _ICategoriaCAD;
}

public ICategoriaCAD get_ICategoriaCAD ()
{
        return this._ICategoriaCAD;
}

public int New_ (string p_nombre, int p_articulo)
{
        CategoriaEN categoriaEN = null;
        int oid;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Nombre = p_nombre;

        categoriaEN.Articulo = p_articulo;

        //Call to CategoriaCAD

        oid = _ICategoriaCAD.New_ (categoriaEN);
        return oid;
}

public void Modify (int p_Categoria_OID, string p_nombre, int p_articulo)
{
        CategoriaEN categoriaEN = null;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Id = p_Categoria_OID;
        categoriaEN.Nombre = p_nombre;
        categoriaEN.Articulo = p_articulo;
        //Call to CategoriaCAD

        _ICategoriaCAD.Modify (categoriaEN);
}

public void Destroy (int id
                     )
{
        _ICategoriaCAD.Destroy (id);
}

public void Anyadir_supercat (int p_Categoria_OID, int p_supercategoria_OID)
{
        //Call to CategoriaCAD

        _ICategoriaCAD.Anyadir_supercat (p_Categoria_OID, p_supercategoria_OID);
}
public System.Collections.Generic.IList<CategoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> list = null;

        list = _ICategoriaCAD.ReadAll (first, size);
        return list;
}
public void Quitar_supercat (int p_Categoria_OID, int p_supercategoria_OID)
{
        //Call to CategoriaCAD

        _ICategoriaCAD.Quitar_supercat (p_Categoria_OID, p_supercategoria_OID);
}
public void Quitar_subcat (int p_Categoria_OID, System.Collections.Generic.IList<int> p_subcategoria_OIDs)
{
        //Call to CategoriaCAD

        _ICategoriaCAD.Quitar_subcat (p_Categoria_OID, p_subcategoria_OIDs);
}
}
}
