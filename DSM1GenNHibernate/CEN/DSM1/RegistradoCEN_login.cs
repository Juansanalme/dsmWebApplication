
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_Registrado_login) ENABLED START*/
//  references to other libraries
using DSM1GenNHibernate.Utils;
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class RegistradoCEN
{
public bool Login (int p_oid, String p_contrasenya, string p_n_usuario)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_Registrado_login) ENABLED START*/

        // Write here your custom code...

        bool login = false;
        RegistradoEN registradoEN = _IRegistradoCAD.ReadOIDDefault (p_oid);

        if (registradoEN.Contrasenya.Equals (Util.GetEncondeMD5 (p_contrasenya))) {
                login = true;
        }

        return login;


        //throw new NotImplementedException ("Method Login() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
