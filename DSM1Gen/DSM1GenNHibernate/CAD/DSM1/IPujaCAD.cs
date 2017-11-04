
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IPujaCAD
{
PujaEN ReadOIDDefault (int id
                       );

void ModifyDefault (PujaEN puja);



int New_ (PujaEN puja);

void Modify (PujaEN puja);


void Destroy (int id
              );


void Actualizar (PujaEN puja);


void Terminar_puja (int p_Puja_OID, int p_usuarioGanador_OID);
}
}
