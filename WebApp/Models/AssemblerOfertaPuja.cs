using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerOfertaPuja
    {
        public OfertaPuja ConvertENToModelUI(OfertaPujaEN en)
        {
            OfertaPuja ofp = new OfertaPuja();
            ofp.Id = en.Id;
            ofp.Fecha = en.Fecha;
            ofp.Registrado = en.Registrado.Nombre;
            ofp.Puja = en.Puja.Id;
            ofp.Cantidad_puja = en.Cantidad_puja;

            return ofp;
        }

        public IList<OfertaPuja> ConvertListENToModel(IList<OfertaPujaEN> ens)
        {
            IList<OfertaPuja> regs = new List<OfertaPuja>();
            foreach (OfertaPujaEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}