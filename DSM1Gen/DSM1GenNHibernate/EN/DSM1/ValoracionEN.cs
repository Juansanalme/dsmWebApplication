
using System;
// Definición clase ValoracionEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class ValoracionEN
{
/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo registrado
 */
private DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado;



/**
 *	Atributo articulo
 */
private DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo;






public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.RegistradoEN Registrado {
        get { return registrado; } set { registrado = value;  }
}



public virtual DSM1GenNHibernate.EN.DSM1.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, int puntuacion, string texto, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo
                    )
{
        this.init (Id, puntuacion, texto, registrado, articulo);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Puntuacion, valoracion.Texto, valoracion.Registrado, valoracion.Articulo);
}

private void init (int id
                   , int puntuacion, string texto, DSM1GenNHibernate.EN.DSM1.RegistradoEN registrado, DSM1GenNHibernate.EN.DSM1.ArticuloEN articulo)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Texto = texto;

        this.Registrado = registrado;

        this.Articulo = articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
