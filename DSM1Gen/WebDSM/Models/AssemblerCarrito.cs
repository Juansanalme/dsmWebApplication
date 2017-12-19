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