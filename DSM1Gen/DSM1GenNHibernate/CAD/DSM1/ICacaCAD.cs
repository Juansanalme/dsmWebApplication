
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface ICacaCAD
{
CacaEN ReadOIDDefault (string NIF
                       );

void ModifyDefault (CacaEN caca);



string Crear (CacaEN caca);
}
}
