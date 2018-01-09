using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class LineaPedido
    {
        public IList<LineaPedido> ListarLineasPedido(int id)
        {

            CarritoCEN ccen = new CarritoCEN();
            LineaPedidoCEN cen = new LineaPedidoCEN();

            IList<LineaPedidoEN> listaEN = cen.ReadAll(0, -1);
            IList<LineaPedidoEN> listAux = new List<LineaPedidoEN>();

            foreach (LineaPedidoEN en in listaEN)
            {
                if (en.Carrito != null)
                    if (en.Carrito.Id == id)
                    {
                        listAux.Add(en);
                    }
            }

            IList<LineaPedido> fin = new AssemblerLineaPedido().ConvertListENToModel(listAux);

            return (fin);
        }

        //ID, CANTIDAD, ARTICULO, CARRITO, PEDIDO
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public String Articulo { get; set; }

        [ScaffoldColumn(false)]
        public string Imagen { get; set; }

        [ScaffoldColumn(false)]
        public double PrecioUnidad { get; set; }

        [ScaffoldColumn(false)]
        public int Cantidad { get; set; }

        [ScaffoldColumn(false)]
        public double Total { get; set; }
    }
}