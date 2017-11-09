
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
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



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



/**
 *	Atributo cerrada
 */
private bool cerrada;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
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



public virtual bool Cerrada {
        get { return cerrada; } set { cerrada = value;  }
}





public PujaEN()
{
        ofertaPuja = new System.Collections.Generic.List<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN>();
}



public PujaEN(int id, Nullable<DateTime> fecha, float puja_inicial, DSM1GenNHibernate.EN.DSM1.RegistradoEN usuarioGanador, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo, float puja_max, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja, int id_usuario, bool cerrada
              )
{
        this.init (Id, fecha, puja_inicial, usuarioGanador, articulo, puja_max, ofertaPuja, id_usuario, cerrada);
}


public PujaEN(PujaEN puja)
{
        this.init (Id, puja.Fecha, puja.Puja_inicial, puja.UsuarioGanador, puja.Articulo, puja.Puja_max, puja.OfertaPuja, puja.Id_usuario, puja.Cerrada);
}

private void init (int id
                   , Nullable<DateTime> fecha, float puja_inicial, DSM1GenNHibernate.EN.DSM1.RegistradoEN usuarioGanador, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo, float puja_max, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja, int id_usuario, bool cerrada)
{
        this.Id = id;


        this.Fecha = fecha;

        this.Puja_inicial = puja_inicial;

        this.UsuarioGanador = usuarioGanador;

        this.Articulo = articulo;

        this.Puja_max = puja_max;

        this.OfertaPuja = ofertaPuja;

        this.Id_usuario = id_usuario;

        this.Cerrada = cerrada;
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
