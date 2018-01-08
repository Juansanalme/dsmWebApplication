
using System;
// Definición clase VideojuegoEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class VideojuegoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public VideojuegoEN()
{
        articulo = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ArticuloEN>();
}



public VideojuegoEN(int id, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo, string nombre, string imagen
                    )
{
        this.init (Id, articulo, nombre, imagen);
}


public VideojuegoEN(VideojuegoEN videojuego)
{
        this.init (Id, videojuego.Articulo, videojuego.Nombre, videojuego.Imagen);
}

private void init (int id
                   , System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo, string nombre, string imagen)
{
        this.Id = id;


        this.Articulo = articulo;

        this.Nombre = nombre;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VideojuegoEN t = obj as VideojuegoEN;
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
