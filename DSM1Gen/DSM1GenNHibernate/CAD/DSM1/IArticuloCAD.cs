
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IArticuloCAD
{
ArticuloEN ReadOIDDefault (int id
                           );

void ModifyDefault (ArticuloEN articulo);



int New_ (ArticuloEN articulo);

void Modify (ArticuloEN articulo);


void Destroy (int id
              );


System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Busqueda_por_categoria (string p_categoria);


System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> Busqueda_por_nombre (string p_nombre);




ArticuloEN Ver_detalles (int id
                         );
}
}
