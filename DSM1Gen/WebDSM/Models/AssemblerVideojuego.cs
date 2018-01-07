using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerVideojuego
    {


        public Videojuego ConvertENToModelUI(VideojuegoEN en)
        {
            Videojuego vid = new Videojuego();
            vid.Id = en.Id;
            vid.Nombre = en.Nombre;
            vid.Arts = en.Articulo.Count();

            return vid;
        }

        public IList<Videojuego> ConvertListENToModel(IList<VideojuegoEN> ens)
        {
            IList<Videojuego> vids = new List<Videojuego>();
            foreach (VideojuegoEN en in ens)
            {
                vids.Add(ConvertENToModelUI(en));
            }
            return vids;
        }


    }
}