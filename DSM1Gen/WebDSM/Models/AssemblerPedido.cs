using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerPedido
    {
        public Pedido ConvertENToModelUI(PedidoEN en)
        {
            Pedido ped = new Pedido();
            ped.Id = en.Id;
            ped.Fecha = en.Fecha;
            //ped.Lineas = en.LineaPedido.id;
            ped.Registrado = en.Registrado.Id;

            return ped;
        }

        public IList<Pedido> ConvertListENToModel(IList<PedidoEN> ens)
        {
            IList<Pedido> regs = new List<Pedido>();
            foreach (PedidoEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }

    }
}