
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IRegistradoCAD
{
RegistradoEN ReadOIDDefault (int id
                             );

void ModifyDefault (RegistradoEN registrado);



void Añadir_fav (int p_Registrado_OID, System.Collections.Generic.IList<int> p_a_favorito_OIDs);

void Eliminar_fav (int p_Registrado_OID, System.Collections.Generic.IList<int> p_a_favorito_OIDs);



int New_ (RegistradoEN registrado);

void Modify (RegistradoEN registrado);


void Destroy (int id
              );


RegistradoEN Ver_detalles_oid (int id
                               );
}
}
