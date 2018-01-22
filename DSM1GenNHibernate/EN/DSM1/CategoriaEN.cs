
using System;
// Definición clase CategoriaEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class CategoriaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo articulo
 */
private int articulo;



/**
 *	Atributo subcategoria
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.CategoriaEN> subcategoria;



/**
 *	Atributo supercategoria
 */
private DSM1GenNHibernate.EN.DSM1.CategoriaEN supercategoria;



/**
 *	Atributo articulo_0
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo_0;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.CategoriaEN> Subcategoria {
        get { return subcategoria; } set { subcategoria = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.CategoriaEN Supercategoria {
        get { return supercategoria; } set { supercategoria = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Articulo_0 {
        get { return articulo_0; } set { articulo_0 = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public CategoriaEN()
{
        subcategoria = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.CategoriaEN>();
        articulo_0 = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ArticuloEN>();
}



public CategoriaEN(int id, string nombre, int articulo, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.CategoriaEN> subcategoria, DSM1GenNHibernate.EN.DSM1.CategoriaEN supercategoria, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo_0, string imagen
                   )
{
        this.init (Id, nombre, articulo, subcategoria, supercategoria, articulo_0, imagen);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (Id, categoria.Nombre, categoria.Articulo, categoria.Subcategoria, categoria.Supercategoria, categoria.Articulo_0, categoria.Imagen);
}

private void init (int id
                   , string nombre, int articulo, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.CategoriaEN> subcategoria, DSM1GenNHibernate.EN.DSM1.CategoriaEN supercategoria, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo_0, string imagen)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Articulo = articulo;

        this.Subcategoria = subcategoria;

        this.Supercategoria = supercategoria;

        this.Articulo_0 = articulo_0;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
