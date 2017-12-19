using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class Pedido
    {
        public IList<LineaPedido> ListarLineasPedido(int id)
        {

            PedidoCEN ccen = new PedidoCEN();
            LineaPedidoCEN cen = new LineaPedidoCEN();

            IList<LineaPedidoEN> listaEN = cen.ReadAll(0, -1);
            IList<LineaPedidoEN> listAux = new List<LineaPedidoEN>();

            foreach (LineaPedidoEN en in listaEN)
            {
                if (en.Pedido != null)
                    if (en.Pedido.Id == id)
                    {
                        listAux.Add(en);
                    }
            }

            IList<LineaPedido> fin = new AssemblerLineaPedido().ConvertListENToModel(listAux);

            return (fin);
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        //[ScaffoldColumn(false)]
        //public string Descripcion { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }

        //[ScaffoldColumn(false)]
        //public IList<int> Lineas { get; set; }

        [ScaffoldColumn(false)]
        public String Registrado { get; set; }

        //[ScaffoldColumn(false)]
        //public Carrito carrito { get; set; }

    }
}