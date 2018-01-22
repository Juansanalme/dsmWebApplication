
using System;
// Definición clase CacaEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class CacaEN
{
/**
 *	Atributo nIF
 */
private string nIF;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fNacimiento
 */
private Nullable<DateTime> fNacimiento;



/**
 *	Atributo pedidos
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedidos;






public virtual string NIF {
        get { return nIF; } set { nIF = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> FNacimiento {
        get { return fNacimiento; } set { fNacimiento = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> Pedidos {
        get { return pedidos; } set { pedidos = value;  }
}





public CacaEN()
{
        pedidos = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.PedidoEN>();
}



public CacaEN(string nIF, string nombre, Nullable<DateTime> fNacimiento, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedidos
              )
{
        this.init (NIF, nombre, fNacimiento, pedidos);
}


public CacaEN(CacaEN caca)
{
        this.init (NIF, caca.Nombre, caca.FNacimiento, caca.Pedidos);
}

private void init (string NIF
                   , string nombre, Nullable<DateTime> fNacimiento, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedidos)
{
        this.NIF = NIF;


        this.Nombre = nombre;

        this.FNacimiento = fNacimiento;

        this.Pedidos = pedidos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CacaEN t = obj as CacaEN;
        if (t == null)
                return false;
        if (NIF.Equals (t.NIF))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NIF.GetHashCode ();
        return hash;
}
}
}
