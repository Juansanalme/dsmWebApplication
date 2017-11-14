
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;



/*PROTECTED REGION ID(usingDSM1GenNHibernate.CP.DSM1_Registrado_nuevo_usuarioYcarrito) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CP.DSM1
{
public partial class RegistradoCP : BasicCP
{
public DSM1GenNHibernate.EN.DSM1.RegistradoEN Nuevo_usuarioYcarrito (string p_nombre, string p_apellidos, int p_edad, Nullable<DateTime> p_fecha_nac, string p_dni, String p_contrasenya, string p_n_usuario, bool p_admin)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CP.DSM1_Registrado_nuevo_usuarioYcarrito) ENABLED START*/

        IRegistradoCAD registradoCAD = null;
        RegistradoCEN registradoCEN = null;

        ICarritoCAD carritoCAD = null;
        CarritoCEN carritoCEN = null;

        DSM1GenNHibernate.EN.DSM1.RegistradoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                registradoCAD = new RegistradoCAD (session);
                registradoCEN = new  RegistradoCEN (registradoCAD);

                carritoCAD = new CarritoCAD(session);
                carritoCEN = new CarritoCEN(carritoCAD);


                int oid;
                //Initialized RegistradoEN
                RegistradoEN registradoEN;
                registradoEN = new RegistradoEN ();
                registradoEN.Nombre = p_nombre;

                registradoEN.Apellidos = p_apellidos;

                registradoEN.Edad = p_edad;

                registradoEN.Fecha_nac = p_fecha_nac;

                registradoEN.Dni = p_dni;

                registradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

                registradoEN.N_usuario = p_n_usuario;

                registradoEN.Admin = p_admin;

                //Call to RegistradoCAD

                oid = registradoCAD.Nuevo_usuarioYcarrito (registradoEN);
                result = registradoCAD.ReadOIDDefault (oid);


                //ASOCIO USUARIO CON EL CARRITO
                carritoCEN.New_ (oid,oid, 0);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
