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
            //cat.NomSuper = en.Supercategoria.Nombre;

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