using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerCategoria
    {
        public Categoria ConvertENToModelUI(CategoriaEN en)
        {
            
            Categoria cat = new Categoria();
            cat.Id = en.Id;
            cat.Nombre = en.Nombre;
            cat.Arts = en.Articulo_0.Count();
            cat.Imagen = en.Imagen;

            if (en.Supercategoria != null)
            {
                cat.NomSuper = en.Supercategoria.Nombre;
                cat.SuperId = en.Supercategoria.Id;
            }
            
            if (en.Subcategoria != null)
            {
                cat.Subs = new List<Categoria>();
                foreach (CategoriaEN item in en.Subcategoria)
                {
                    Categoria sub = ConvertENToModelUI(item);
                    cat.Subs.Add(sub);
                    cat.Arts += item.Articulo_0.Count();
                }
            }

            return cat;
        }

        public IList<Categoria> ConvertListENToModel(IList<CategoriaEN> ens)
        {
            IList<Categoria> regs = new List<Categoria>();
            foreach (CategoriaEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}