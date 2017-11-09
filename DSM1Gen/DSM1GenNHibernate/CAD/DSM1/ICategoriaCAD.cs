
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface ICategoriaCAD
{
CategoriaEN ReadOIDDefault (int id
                            );

void ModifyDefault (CategoriaEN categoria);



int New_ (CategoriaEN categoria);

void Modify (CategoriaEN categoria);


void Destroy (int id
              );


void Anyadir_supercat (int p_Categoria_OID, int p_supercategoria_OID);
}
}
