

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
}
}
