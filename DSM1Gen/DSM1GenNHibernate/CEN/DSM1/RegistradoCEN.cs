

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
 *      Definition of the class RegistradoCEN
 *
 */
public partial class RegistradoCEN
{
private IRegistradoCAD _IRegistradoCAD;

public RegistradoCEN()
{
        this._IRegistradoCAD = new RegistradoCAD ();
}

public RegistradoCEN(IRegistradoCAD _IRegistradoCAD)
{
        this._IRegistradoCAD = _IRegistradoCAD;
}

public IRegistradoCAD get_IRegistradoCAD ()
{
        return this._IRegistradoCAD;
}

public void Añadir_fav (int p_Registrado_OID, System.Collections.Generic.IList<int> p_a_favorito_OIDs)
{
        //Call to RegistradoCAD

        _IRegistradoCAD.Añadir_fav (p_Registrado_OID, p_a_favorito_OIDs);
}
public void Eliminar_fav (int p_Registrado_OID, System.Collections.Generic.IList<int> p_a_favorito_OIDs)
{
        //Call to RegistradoCAD

        _IRegistradoCAD.Eliminar_fav (p_Registrado_OID, p_a_favorito_OIDs);
}
public int New_ (string p_nombre, string p_apellidos, int p_edad, Nullable<DateTime> p_fecha_nac, string p_dni, String p_contraseña, string p_n_usuario, bool p_admin)
{
        RegistradoEN registradoEN = null;
        int oid;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Nombre = p_nombre;

        registradoEN.Apellidos = p_apellidos;

        registradoEN.Edad = p_edad;

        registradoEN.Fecha_nac = p_fecha_nac;

        registradoEN.Dni = p_dni;

        registradoEN.Contraseña = Utils.Util.GetEncondeMD5 (p_contraseña);

        registradoEN.N_usuario = p_n_usuario;

        registradoEN.Admin = p_admin;

        //Call to RegistradoCAD

        oid = _IRegistradoCAD.New_ (registradoEN);
        return oid;
}

public void Modify (int p_Registrado_OID, string p_nombre, string p_apellidos, int p_edad, Nullable<DateTime> p_fecha_nac, string p_dni, String p_contraseña, string p_n_usuario, bool p_admin)
{
        RegistradoEN registradoEN = null;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Id = p_Registrado_OID;
        registradoEN.Nombre = p_nombre;
        registradoEN.Apellidos = p_apellidos;
        registradoEN.Edad = p_edad;
        registradoEN.Fecha_nac = p_fecha_nac;
        registradoEN.Dni = p_dni;
        registradoEN.Contraseña = Utils.Util.GetEncondeMD5 (p_contraseña);
        registradoEN.N_usuario = p_n_usuario;
        registradoEN.Admin = p_admin;
        //Call to RegistradoCAD

        _IRegistradoCAD.Modify (registradoEN);
}

public void Destroy (int id
                     )
{
        _IRegistradoCAD.Destroy (id);
}

public RegistradoEN Ver_detalles_oid (int id
                                      )
{
        RegistradoEN registradoEN = null;

        registradoEN = _IRegistradoCAD.Ver_detalles_oid (id);
        return registradoEN;
}
}
}
