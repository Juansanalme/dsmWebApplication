
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
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido;



/**
 *	Atributo registrado
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN>();
}



public PedidoEN(int id, string descripcion, Nullable<DateTime> fecha, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado
                )
{
        this.init (Id, descripcion, fecha, lineaPedido, registrado);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Descripcion, pedido.Fecha, pedido.LineaPedido, pedido.Registrado);
}

private void init (int id
                   , string descripcion, Nullable<DateTime> fecha, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.LineaPedidoEN> lineaPedido, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Fecha = fecha;

        this.LineaPedido = lineaPedido;

        this.Registrado = registrado;
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
