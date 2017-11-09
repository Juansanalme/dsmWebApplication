

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
 *      Definition of the class ArticuloCEN
 *
 */
public partial class ArticuloCEN
{
private IArticuloCAD _IArticuloCAD;

public ArticuloCEN()
{
        this._IArticuloCAD = new ArticuloCAD ();
}

public ArticuloCEN(IArticuloCAD _IArticuloCAD)
{
        this._IArticuloCAD = _IArticuloCAD;
}

public IArticuloCAD get_IArticuloCAD ()
{
        return this._IArticuloCAD;
}

public int New_ (string p_nombre, double p_precio, int p_categoria, string p_descripcion, int p_stock)
{
        ArticuloEN articuloEN = null;
        int oid;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Nombre = p_nombre;

        articuloEN.Precio = p_precio;


        if (p_categoria != -1) {
                // El argumento p_categoria -> Property categoria es oid = false
                // Lista de oids id
                articuloEN.Categoria = new DSM1GenNHibernate.EN.DSM1.CategoriaEN ();
                articuloEN.Categoria.Id = p_categoria;
        }

        articuloEN.Descripcion = p_descripcion;

        articuloEN.Stock = p_stock;

        //Call to ArticuloCAD

        oid = _IArticuloCAD.New_ (articuloEN);
        return oid;
}

public void Modify (int p_Articulo_OID, string p_nombre, double p_precio, string p_descripcion, int p_stock)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Id = p_Articulo_OID;
        articuloEN.Nombre = p_nombre;
        articuloEN.Precio = p_precio;
        articuloEN.Descripcion = p_descripcion;
        articuloEN.Stock = p_stock;
        //Call to ArticuloCAD

        _IArticuloCAD.Modify (articuloEN);
}

public void Destroy (int id
                     )
{
        _IArticuloCAD.Destroy (id);
}

public ArticuloEN Ver_detalles (int id
                                )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloCAD.Ver_detalles (id);
        return articuloEN;
}
}
}
