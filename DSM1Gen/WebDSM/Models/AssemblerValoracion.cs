using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerValoracion
    {
        public Valoracion ConvertENToModelUI(ValoracionEN en)
        {
            Valoracion val = new Valoracion();
            val.Id = en.Id;
            val.Registrado = en.Registrado.Id;
            val.Articulo = en.Articulo.Id;
            val.Texto = en.Texto;
            val.Puntuacion = en.Puntuacion;

            return val;
        }

        public IList<Valoracion> ConvertListENToModel(IList<ValoracionEN> ens)
        {
            IList<Valoracion> regs = new List<Valoracion>();
            foreach (ValoracionEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}