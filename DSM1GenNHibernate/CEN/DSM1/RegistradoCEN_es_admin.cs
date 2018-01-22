
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


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_Registrado_es_admin) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class RegistradoCEN
{
public bool Es_admin (int p_oid)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_Registrado_es_admin) ENABLED START*/

        // Write here your custom code...

        RegistradoEN registradoEN = _IRegistradoCAD.ReadOIDDefault (p_oid);

        return registradoEN.Admin;

        //throw new NotImplementedException ("Method Es_admin() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
