
using System;
// Definición clase PedidoEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo cp
 */
private int cp;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido;



/**
 *	Atributo registrado
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado;



/**
 *	Atributo carrito
 */
private DSM1GenNHibernate.EN.DSM1.CarritoEN carrito;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual int Cp {
        get { return cp; } set { cp = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN>();
}



public PedidoEN(int id, string descripcion, Nullable<DateTime> fecha, string direccion, string localidad, string provincia, int cp, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito
                )
{
        this.init (Id, descripcion, fecha, direccion, localidad, provincia, cp, lineaPedido, registrado, carrito);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Descripcion, pedido.Fecha, pedido.Direccion, pedido.Localidad, pedido.Provincia, pedido.Cp, pedido.LineaPedido, pedido.Registrado, pedido.Carrito);
}

private void init (int id
                   , string descripcion, Nullable<DateTime> fecha, string direccion, string localidad, string provincia, int cp, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Fecha = fecha;

        this.Direccion = direccion;

        this.Localidad = localidad;

        this.Provincia = provincia;

        this.Cp = cp;

        this.LineaPedido = lineaPedido;

        this.Registrado = registrado;

        this.Carrito = carrito;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
