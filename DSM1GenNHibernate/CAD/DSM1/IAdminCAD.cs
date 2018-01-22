
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (int id
                        );

void ModifyDefault (AdminEN admin);




int New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (int id
              );
}
}
