
using System;
// Definición clase CarritoEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class CarritoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo fecha_anyadido
 */
private Nullable<DateTime> fecha_anyadido;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo;



/**
 *	Atributo registrado
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado;



/**
 *	Atributo pedido
 */
private DSM1GenNHibernate.EN.DSM1.PedidoEN pedido;



/**
 *	Atributo precio
 */
private float precio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual Nullable<DateTime> Fecha_anyadido {
        get { return fecha_anyadido; } set { fecha_anyadido = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}





public CarritoEN()
{
        lineaPedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN>();
        articulo = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ArticuloEN>();
}



public CarritoEN(int id, int cantidad, Nullable<DateTime> fecha_anyadido, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.PedidoEN pedido, float precio
                 )
{
        this.init (Id, cantidad, fecha_anyadido, lineaPedido, articulo, registrado, pedido, precio);
}


public CarritoEN(CarritoEN carrito)
{
        this.init (Id, carrito.Cantidad, carrito.Fecha_anyadido, carrito.LineaPedido, carrito.Articulo, carrito.Registrado, carrito.Pedido, carrito.Precio);
}

private void init (int id
                   , int cantidad, Nullable<DateTime> fecha_anyadido, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> articulo, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.PedidoEN pedido, float precio)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Fecha_anyadido = fecha_anyadido;

        this.LineaPedido = lineaPedido;

        this.Articulo = articulo;

        this.Registrado = registrado;

        this.Pedido = pedido;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CarritoEN t = obj as CarritoEN;
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
