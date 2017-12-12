using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerArticulo
    {
        
        public Articulo ConvertENToModelUI(ArticuloEN en)
        {
            
            Articulo art = new Articulo();
            art.Id = en.Id;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Descripcion = en.Descripcion;
            art.Stock = en.Stock;
            
            return art;
            
        }

        public IList<Articulo> ConvertListENToModel(IList<ArticuloEN> ens)
        {
            IList<Articulo> regs = new List<Articulo>();
            foreach (ArticuloEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}