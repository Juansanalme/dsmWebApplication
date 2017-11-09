
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


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_Puja_cerrar_puja) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class PujaCEN
{
public void Cerrar_puja (int p_oid)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_Puja_cerrar_puja) ENABLED START*/

        // Write here your custom code...

        PujaEN pujaEN = _IPujaCAD.ReadOIDDefault (p_oid);

        pujaEN.Cerrada = true;
        _IPujaCAD.Modify (pujaEN);


        //throw new NotImplementedException ("Method Cerrar_puja() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
