

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
 *      Definition of the class CacaCEN
 *
 */
public partial class CacaCEN
{
private ICacaCAD _ICacaCAD;

public CacaCEN()
{
        this._ICacaCAD = new CacaCAD ();
}

public CacaCEN(ICacaCAD _ICacaCAD)
{
        this._ICacaCAD = _ICacaCAD;
}

public ICacaCAD get_ICacaCAD ()
{
        return this._ICacaCAD;
}

public string Crear (string p_NIF, string p_nombre, Nullable<DateTime> p_fNacimiento)
{
        CacaEN cacaEN = null;
        string oid;

        //Initialized CacaEN
        cacaEN = new CacaEN ();
        cacaEN.NIF = p_NIF;

        cacaEN.Nombre = p_nombre;

        cacaEN.FNacimiento = p_fNacimiento;

        //Call to CacaCAD

        oid = _ICacaCAD.Crear (cacaEN);
        return oid;
}
}
}
