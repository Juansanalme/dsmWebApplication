using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerPuja
    {
        public Puja ConvertENToModelUI(PujaEN en)
        {
            Puja puja = new Puja();
            puja.Id = en.Id;
            puja.Fecha = en.Fecha;
            puja.PujaInicial = en.Puja_inicial;
            puja.UsuarioGanador = en.UsuarioGanador.Id;
            puja.Articulo = en.Articulo.Id;
            puja.PujaMaxima = en.Puja_max;
            puja.Cerrada = en.Cerrada;

            return puja;
        }

        public IList<Puja> ConvertListENToModel(IList<PujaEN> ens)
        {
            IList<Puja> regs = new List<Puja>();
            foreach (PujaEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}