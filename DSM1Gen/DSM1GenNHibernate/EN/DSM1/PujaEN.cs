
using System;
// Definición clase PujaEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class PujaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tiempo
 */
private Nullable<DateTime> tiempo;



/**
 *	Atributo puja_inicial
 */
private float puja_inicial;



/**
 *	Atributo usuarioGanador
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN usuarioGanador;



/**
 *	Atributo articulo
 */
private DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo;



/**
 *	Atributo puja_max
 */
private float puja_max;



/**
 *	Atributo ofertaPuja
 */
private System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja;



/**
 *	Atributo id_usuario
 */
private int id_usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Tiempo {
        get { return tiempo; } set { tiempo = value;  }
}



public virtual float Puja_inicial {
        get { return puja_inicial; } set { puja_inicial = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN UsuarioGanador {
        get { return usuarioGanador; } set { usuarioGanador = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual float Puja_max {
        get { return puja_max; } set { puja_max = value;  }
}



public virtual System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> OfertaPuja {
        get { return ofertaPuja; } set { ofertaPuja = value;  }
}



public virtual int Id_usuario {
        get { return id_usuario; } set { id_usuario = value;  }
}





public PujaEN()
{
        ofertaPuja = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN>();
}



public PujaEN(int id, Nullable<DateTime> tiempo, float puja_inicial, DSM1GenNHibernate.EN.DSM1.RegistradoEN usuarioGanador, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo, float puja_max, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja, int id_usuario
              )
{
        this.init (Id, tiempo, puja_inicial, usuarioGanador, articulo, puja_max, ofertaPuja, id_usuario);
}


public PujaEN(PujaEN puja)
{
        this.init (Id, puja.Tiempo, puja.Puja_inicial, puja.UsuarioGanador, puja.Articulo, puja.Puja_max, puja.OfertaPuja, puja.Id_usuario);
}

private void init (int id
                   , Nullable<DateTime> tiempo, float puja_inicial, DSM1GenNHibernate.EN.DSM1.RegistradoEN usuarioGanador, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo, float puja_max, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja, int id_usuario)
{
        this.Id = id;


        this.Tiempo = tiempo;

        this.Puja_inicial = puja_inicial;

        this.UsuarioGanador = usuarioGanador;

        this.Articulo = articulo;

        this.Puja_max = puja_max;

        this.OfertaPuja = ofertaPuja;

        this.Id_usuario = id_usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PujaEN t = obj as PujaEN;
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
