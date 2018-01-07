

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.Exceptions;

using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;


namespace DSM1GenNHibernate.CEN.DSM1
{
/*
 *      Definition of the class VideojuegoCEN
 *
 */
public partial class VideojuegoCEN
{
private IVideojuegoCAD _IVideojuegoCAD;

public VideojuegoCEN()
{
        this._IVideojuegoCAD = new VideojuegoCAD ();
}

public VideojuegoCEN(IVideojuegoCAD _IVideojuegoCAD)
{
        this._IVideojuegoCAD = _IVideojuegoCAD;
}

public IVideojuegoCAD get_IVideojuegoCAD ()
{
        return this._IVideojuegoCAD;
}

public int New_ (string p_nombre)
{
        VideojuegoEN videojuegoEN = null;
        int oid;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Nombre = p_nombre;

        //Call to VideojuegoCAD

        oid = _IVideojuegoCAD.New_ (videojuegoEN);
        return oid;
}

public void Modify (int p_Videojuego_OID, string p_nombre)
{
        VideojuegoEN videojuegoEN = null;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Id = p_Videojuego_OID;
        videojuegoEN.Nombre = p_nombre;
        //Call to VideojuegoCAD

        _IVideojuegoCAD.Modify (videojuegoEN);
}

public void Destroy (int id
                     )
{
        _IVideojuegoCAD.Destroy (id);
}

public System.Collections.Generic.IList<VideojuegoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> list = null;

        list = _IVideojuegoCAD.ReadAll (first, size);
        return list;
}
}
}
