using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDSM.Models
{
    public class PedidoYLineas
    {
        public PedidoYLineas()
        {
            Pedido = new Pedido();
            LineaPedido = new List<LineaPedido>();
        }
        public Pedido Pedido { get; set; }
        public IList<LineaPedido> LineaPedido { get; set; }
    }
}