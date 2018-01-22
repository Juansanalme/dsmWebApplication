
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
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido;



/**
 *	Atributo registrado
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado;



/**
 *	Atributo precio
 */
private float precio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}





public CarritoEN()
{
        lineaPedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN>();
}



public CarritoEN(int id, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, float precio
                 )
{
        this.init (Id, lineaPedido, registrado, precio);
}


public CarritoEN(CarritoEN carrito)
{
        this.init (Id, carrito.LineaPedido, carrito.Registrado, carrito.Precio);
}

private void init (int id
                   , System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, float precio)
{
        this.Id = id;


        this.LineaPedido = lineaPedido;

        this.Registrado = registrado;

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
