
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using DSM1GenNHibernate.Exceptions;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CEN.DSM1;


namespace DSM1GenNHibernate.CP.DSM1
{
public partial class LineaPedidoCP : BasicCP
{
public LineaPedidoCP() : base ()
{
}

public LineaPedidoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
