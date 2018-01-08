

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.Exceptions;

using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;

using System.IO;

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

public int New_ (string p_nombre, double p_precio, int p_categoria, string p_descripcion, int p_stock, string p_imagen, string p_img_3d, int p_videojuego)
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

        articuloEN.Imagen = p_imagen;

        articuloEN.Img_3d = p_img_3d;


        if (p_videojuego != -1) {
                // El argumento p_videojuego -> Property videojuego es oid = false
                // Lista de oids id
                articuloEN.Videojuego = new DSM1GenNHibernate.EN.DSM1.VideojuegoEN ();
                articuloEN.Videojuego.Id = p_videojuego;
        }

        //Call to ArticuloCAD

        oid = _IArticuloCAD.New_ (articuloEN);

        if(p_imagen != "")
        {
            String new_img = oid.ToString() + Path.GetExtension(p_imagen);
            Modify(oid, p_nombre, p_precio, p_descripcion, p_stock, new_img, p_img_3d);
        }

        return oid;
}

public void Modify (int p_Articulo_OID, string p_nombre, double p_precio, string p_descripcion, int p_stock, string p_imagen, string p_img_3d)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Id = p_Articulo_OID;
        articuloEN.Nombre = p_nombre;
        articuloEN.Precio = p_precio;
        articuloEN.Descripcion = p_descripcion;
        articuloEN.Stock = p_stock;
        articuloEN.Imagen = p_imagen;
        articuloEN.Img_3d = p_img_3d;
        //Call to ArticuloCAD

        _IArticuloCAD.Modify (articuloEN);
}

public void Destroy (int id
                     )
{
        _IArticuloCAD.Destroy (id);
}

public System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Busqueda_por_categoria (string p_categoria)
{
        return _IArticuloCAD.Busqueda_por_categoria (p_categoria);
}
public System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Busqueda_por_nombre (string p_nombre)
{
        return _IArticuloCAD.Busqueda_por_nombre (p_nombre);
}
public ArticuloEN Ver_detalles (int id
                                )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloCAD.Ver_detalles (id);
        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> list = null;

        list = _IArticuloCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Busqueda_por_videojuego (string p_videojuego)
{
        return _IArticuloCAD.Busqueda_por_videojuego (p_videojuego);
}
}
}
