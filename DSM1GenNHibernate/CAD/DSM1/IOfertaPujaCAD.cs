
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IOfertaPujaCAD
{
OfertaPujaEN ReadOIDDefault (int id
                             );

void ModifyDefault (OfertaPujaEN ofertaPuja);



int New_ (OfertaPujaEN ofertaPuja);

void Modify (OfertaPujaEN ofertaPuja);


void Destroy (int id
              );


int Nueva_oferta (OfertaPujaEN ofertaPuja);

System.Collections.Generic.IList<OfertaPujaEN> ReadAll (int first, int size);
}
}
