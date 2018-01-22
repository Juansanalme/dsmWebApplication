
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


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_Puja_pagar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class PujaCEN
{
public void Pagar (int p_oid)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_Puja_pagar) ENABLED START*/

        PujaCEN pujaCEN = new PujaCEN ();
        PujaEN pujaEN = pujaCEN.get_IPujaCAD ().ReadOIDDefault (p_oid);

        pujaEN.Pagada = true;

        /*PROTECTED REGION END*/
}
}
}
