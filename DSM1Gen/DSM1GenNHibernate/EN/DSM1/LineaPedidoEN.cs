
using System;
// Definición clase LineaPedidoEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class LineaPedidoEN
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
 *	Atributo articulo
 */
private DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo;



/**
 *	Atributo carrito
 */
private DSM1GenNHibernate.EN.DSM1.CarritoEN carrito;



/**
 *	Atributo pedido
 */
private DSM1GenNHibernate.EN.DSM1.PedidoEN pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, int cantidad, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito, DSM1GenNHibernate.EN.DSM1.PedidoEN pedido
                     )
{
        this.init (Id, cantidad, articulo, carrito, pedido);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Cantidad, lineaPedido.Articulo, lineaPedido.Carrito, lineaPedido.Pedido);
}

private void init (int id
                   , int cantidad, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito, DSM1GenNHibernate.EN.DSM1.PedidoEN pedido)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Articulo = articulo;

        this.Carrito = carrito;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
