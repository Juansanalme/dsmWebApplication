
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface ICarritoCAD
{
CarritoEN ReadOIDDefault (int id
                          );

void ModifyDefault (CarritoEN carrito);



int New_ (CarritoEN carrito);

void Modify (CarritoEN carrito);


void Destroy (int id
              );


void Vaciar_carrito (int p_Carrito_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs);

CarritoEN Ver_detalles (int id
                        );



void Finalizar_compra (CarritoEN carrito);
}
}
