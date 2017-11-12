
using System;
using DSM1GenNHibernate.EN.DSM1;

namespace DSM1GenNHibernate.CAD.DSM1
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);



int New_ (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id
              );


void Anyadir_linea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs);

System.Collections.Generic.IList<PedidoEN> Obtener_pedidos (int first, int size);
}
}
