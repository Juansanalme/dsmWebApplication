using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerCarrito
    {
        public Carrito ConvertENToModelUI(CarritoEN en)
        {
            Carrito car = new Carrito();

            car.Id = en.Id;
            car.Usuario = en.Registrado.Nombre;
            car.Precio = en.Precio;

            return car;
        }

        public CarritoYLineas ConvertENToViewModelUI(CarritoEN en)
        {
            CarritoYLineas cyl = new CarritoYLineas();

            cyl.Carrito.Id = en.Id;
            cyl.Carrito.Usuario = en.Registrado.Nombre;
            cyl.Carrito.Precio = en.Precio;

            LineaPedido l;
            IList<LineaPedidoEN> lineas = en.LineaPedido;
            foreach(LineaPedidoEN item in lineas)
            {
                l = new LineaPedido();
                l.Id = item.Id;
                l.Articulo = item.Articulo.Nombre;
                l.PrecioUnidad = item.Articulo.Precio;
                l.Total = item.Articulo.Precio * item.Cantidad;
                l.Cantidad = item.Cantidad;

                cyl.LineaPedido.Add(l);
            }

            return cyl;
        }

        public IList<Carrito> ConvertListENToModel(IList<CarritoEN> ens)
        {
            IList<Carrito> regs = new List<Carrito>();
            foreach (CarritoEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }

    }
}