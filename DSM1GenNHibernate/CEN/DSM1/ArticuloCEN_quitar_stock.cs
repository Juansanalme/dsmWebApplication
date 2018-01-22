
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


/*PROTECTED REGION ID(usingDSM1GenNHibernate.CEN.DSM1_Articulo_quitar_stock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSM1GenNHibernate.CEN.DSM1
{
public partial class ArticuloCEN
{
public bool Quitar_stock (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(DSM1GenNHibernate.CEN.DSM1_Articulo_quitar_stock) ENABLED START*/

        // Write here your custom code...

        ArticuloEN articuloEN = _IArticuloCAD.ReadOIDDefault (p_oid);

        if (articuloEN.Stock >= p_cantidad) {
                articuloEN.Stock -= p_cantidad;
                _IArticuloCAD.Modify (articuloEN);
                return true;
        }
        return false;



        //throw new NotImplementedException ("Method Quitar_stock() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
