
using System;
// Definición clase OfertaPujaEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class OfertaPujaEN
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
 *	Atributo tiempo
 */
private Nullable<DateTime> tiempo;



/**
 *	Atributo registrado
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado;



/**
 *	Atributo puja
 */
private DSM1GenNHibernate.EN.DSM1.PujaEN puja;



/**
 *	Atributo cantidad_puja
 */
private float cantidad_puja;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual Nullable<DateTime> Tiempo {
        get { return tiempo; } set { tiempo = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.PujaEN Puja {
        get { return puja; } set { puja = value;  }
}



public virtual float Cantidad_puja {
        get { return cantidad_puja; } set { cantidad_puja = value;  }
}





public OfertaPujaEN()
{
}



public OfertaPujaEN(int id, Nullable<DateTime> fecha, Nullable<DateTime> tiempo, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.PujaEN puja, float cantidad_puja
                    )
{
        this.init (Id, fecha, tiempo, registrado, puja, cantidad_puja);
}


public OfertaPujaEN(OfertaPujaEN ofertaPuja)
{
        this.init (Id, ofertaPuja.Fecha, ofertaPuja.Tiempo, ofertaPuja.Registrado, ofertaPuja.Puja, ofertaPuja.Cantidad_puja);
}

private void init (int id
                   , Nullable<DateTime> fecha, Nullable<DateTime> tiempo, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.PujaEN puja, float cantidad_puja)
{
        this.Id = id;


        this.Fecha = fecha;

        this.Tiempo = tiempo;

        this.Registrado = registrado;

        this.Puja = puja;

        this.Cantidad_puja = cantidad_puja;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        OfertaPujaEN t = obj as OfertaPujaEN;
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
