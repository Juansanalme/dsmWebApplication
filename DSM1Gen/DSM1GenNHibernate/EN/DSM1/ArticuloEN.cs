
using System;
// Definición clase ArticuloEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class ArticuloEN
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
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo categoria
 */
private DSM1GenNHibernate.EN.DSM1.CategoriaEN categoria;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido;



/**
 *	Atributo puja
 */
private DSM1GenNHibernate.EN.DSM1.PujaEN puja;



/**
 *	Atributo registrado
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.RegistradoEN> registrado;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo stock
 */
private int stock;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.CategoriaEN Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.PujaEN Puja {
        get { return puja; } set { puja = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.RegistradoEN> Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}





public ArticuloEN()
{
        valoracion = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ValoracionEN>();
        lineaPedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN>();
        registrado = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.RegistradoEN>();
}



public ArticuloEN(int id, string nombre, double precio, DSM1GenNHibernate.EN.DSM1.CategoriaEN categoria, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.PujaEN puja, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.RegistradoEN> registrado, string descripcion, int stock
                  )
{
        this.init (Id, nombre, precio, categoria, valoracion, lineaPedido, puja, registrado, descripcion, stock);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (Id, articulo.Nombre, articulo.Precio, articulo.Categoria, articulo.Valoracion, articulo.LineaPedido, articulo.Puja, articulo.Registrado, articulo.Descripcion, articulo.Stock);
}

private void init (int id
                   , string nombre, double precio, DSM1GenNHibernate.EN.DSM1.CategoriaEN categoria, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.PujaEN puja, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.RegistradoEN> registrado, string descripcion, int stock)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Precio = precio;

        this.Categoria = categoria;

        this.Valoracion = valoracion;

        this.LineaPedido = lineaPedido;

        this.Puja = puja;

        this.Registrado = registrado;

        this.Descripcion = descripcion;

        this.Stock = stock;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
