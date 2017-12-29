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
            ped.Registrado = en.Registrado.Nombre;

            return ped;
        }

        public PedidoYLineas ConvertENToViewModelUI(PedidoEN en)
        {
            PedidoYLineas pyl = new PedidoYLineas();

            pyl.Pedido.Id = en.Id;
            pyl.Pedido.Registrado = en.Registrado.Nombre;
            pyl.Pedido.Fecha = en.Fecha;
            pyl.Pedido.Total = 0;

            LineaPedido l;
            IList<LineaPedidoEN> lineas = en.LineaPedido;
            foreach (LineaPedidoEN item in lineas)
            {
                l = new LineaPedido();
                l.Id = item.Id;
                l.Articulo = item.Articulo.Nombre;
                l.PrecioUnidad = item.Articulo.Precio;
                l.Total = item.Articulo.Precio * item.Cantidad;
                l.Cantidad = item.Cantidad;

                pyl.Pedido.Total += l.Cantidad * l.PrecioUnidad;

                pyl.LineaPedido.Add(l);
            }

            return pyl;
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