
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IVideojuegoCAD
{
VideojuegoEN ReadOIDDefault (int id
                             );

void ModifyDefault (VideojuegoEN videojuego);



int New_ (VideojuegoEN videojuego);

void Modify (VideojuegoEN videojuego);


void Destroy (int id
              );


System.Collections.Generic.IList<VideojuegoEN> ReadAll (int first, int size);
}
}
