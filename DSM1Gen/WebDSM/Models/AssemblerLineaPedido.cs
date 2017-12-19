using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerLineaPedido
    {
        public LineaPedido ConvertENToModelUI(LineaPedidoEN en)
        {
            LineaPedido linped = new LineaPedido();

            linped.Id = en.Id;
            //linped.Articulo = en.Articulo.Nombre;
            linped.Cantidad = en.Cantidad;

            return linped;
        }

        public IList<LineaPedido> ConvertListENToModel(IList<LineaPedidoEN> ens)
        {
            IList<LineaPedido> regs = new List<LineaPedido>();
            foreach (LineaPedidoEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}