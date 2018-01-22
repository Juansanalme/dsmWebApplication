

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public int New_ (string p_nombre, string p_apellidos, int p_edad, Nullable<DateTime> p_fecha_nac, string p_dni, String p_contraseña, string p_n_usuario, DSM1GenNHibernate.EN.DSM1.CarritoEN p_carrito)
{
        AdminEN adminEN = null;
        int oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Nombre = p_nombre;

        adminEN.Apellidos = p_apellidos;

        adminEN.Edad = p_edad;

        adminEN.Fecha_nac = p_fecha_nac;

        adminEN.Dni = p_dni;

        adminEN.Contraseña = Utils.Util.GetEncondeMD5 (p_contraseña);

        adminEN.N_usuario = p_n_usuario;

        adminEN.Carrito = p_carrito;

        //Call to AdminCAD

        oid = _IAdminCAD.New_ (adminEN);
        return oid;
}

public void Modify (int p_Admin_OID, string p_nombre, string p_apellidos, int p_edad, Nullable<DateTime> p_fecha_nac, string p_dni, String p_contraseña, string p_n_usuario)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Id = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Apellidos = p_apellidos;
        adminEN.Edad = p_edad;
        adminEN.Fecha_nac = p_fecha_nac;
        adminEN.Dni = p_dni;
        adminEN.Contraseña = Utils.Util.GetEncondeMD5 (p_contraseña);
        adminEN.N_usuario = p_n_usuario;
        //Call to AdminCAD

        _IAdminCAD.Modify (adminEN);
}

public void Destroy (int id
                     )
{
        _IAdminCAD.Destroy (id);
}
}
}
