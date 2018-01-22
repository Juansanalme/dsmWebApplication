
using System;
// Definición clase RegistradoEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class RegistradoEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo edad
 */
private int edad;



/**
 *	Atributo fecha_nac
 */
private Nullable<DateTime> fecha_nac;



/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo n_usuario
 */
private string n_usuario;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedido;



/**
 *	Atributo carrito
 */
private DSM1GenNHibernate.EN.DSM1.CarritoEN carrito;



/**
 *	Atributo pujaGanadora
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PujaEN> pujaGanadora;



/**
 *	Atributo a_favorito
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> a_favorito;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo ofertaPuja
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja;



/**
 *	Atributo admin
 */
private bool admin;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual int Edad {
        get { return edad; } set { edad = value;  }
}



public virtual Nullable<DateTime> Fecha_nac {
        get { return fecha_nac; } set { fecha_nac = value;  }
}



public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string N_usuario {
        get { return n_usuario; } set { n_usuario = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PujaEN> PujaGanadora {
        get { return pujaGanadora; } set { pujaGanadora = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> A_favorito {
        get { return a_favorito; } set { a_favorito = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> OfertaPuja {
        get { return ofertaPuja; } set { ofertaPuja = value;  }
}



public virtual bool Admin {
        get { return admin; } set { admin = value;  }
}





public RegistradoEN()
{
        valoracion = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ValoracionEN>();
        pedido = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.PedidoEN>();
        pujaGanadora = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.PujaEN>();
        a_favorito = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.ArticuloEN>();
        ofertaPuja = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN>();
}



public RegistradoEN(int id, string nombre, string apellidos, int edad, Nullable<DateTime> fecha_nac, string dni, String contrasenya, string n_usuario, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedido, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PujaEN> pujaGanadora, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> a_favorito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja, bool admin
                    )
{
        this.init (Id, nombre, apellidos, edad, fecha_nac, dni, contrasenya, n_usuario, valoracion, pedido, carrito, pujaGanadora, a_favorito, ofertaPuja, admin);
}


public RegistradoEN(RegistradoEN registrado)
{
        this.init (Id, registrado.Nombre, registrado.Apellidos, registrado.Edad, registrado.Fecha_nac, registrado.Dni, registrado.Contrasenya, registrado.N_usuario, registrado.Valoracion, registrado.Pedido, registrado.Carrito, registrado.PujaGanadora, registrado.A_favorito, registrado.OfertaPuja, registrado.Admin);
}

private void init (int id
                   , string nombre, string apellidos, int edad, Nullable<DateTime> fecha_nac, string dni, String contrasenya, string n_usuario, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedido, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PujaEN> pujaGanadora, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> a_favorito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja, bool admin)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Edad = edad;

        this.Fecha_nac = fecha_nac;

        this.Dni = dni;

        this.Contrasenya = contrasenya;

        this.N_usuario = n_usuario;

        this.Valoracion = valoracion;

        this.Pedido = pedido;

        this.Carrito = carrito;

        this.PujaGanadora = pujaGanadora;

        this.A_favorito = a_favorito;

        this.OfertaPuja = ofertaPuja;

        this.Admin = admin;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RegistradoEN t = obj as RegistradoEN;
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
