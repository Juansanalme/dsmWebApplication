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

            if (en.UsuarioGanador == null)
            {
                puja.UsuarioGanador = "Sin pujas";
                puja.IdGanador = 0;
            }
            else
            {
                puja.UsuarioGanador = en.UsuarioGanador.Nombre;
                puja.IdGanador = en.UsuarioGanador.Id;
            }

            puja.Articulo = en.Articulo.Nombre;
            puja.Videojuego = en.Articulo.Videojuego.Nombre;
            puja.ArtDescripcion = en.Articulo.Descripcion;
            puja.PujaMaxima = en.Puja_max;
            puja.Cerrada = en.Cerrada;
            puja.Pagada = en.Pagada;

            return puja;
        }

        public IList<PujaYArticulo> ConvertCustom(IList<PujaEN> ens)
        {
            IList <PujaYArticulo> pya = new List<PujaYArticulo>();

            foreach(PujaEN en in ens)
            {
                PujaYArticulo puja = new PujaYArticulo();
                puja.Puja.Id = en.Id;
                puja.Puja.Fecha = en.Fecha;
                puja.Puja.PujaInicial = en.Puja_inicial;

                if (en.UsuarioGanador == null)
                {
                    puja.Puja.UsuarioGanador = "Sin pujas";
                    puja.Puja.IdGanador = 0;
                }
                else
                {
                    puja.Puja.UsuarioGanador = en.UsuarioGanador.Nombre;
                    puja.Puja.IdGanador = en.UsuarioGanador.Id;
                }

                puja.Articulo.Nombre = en.Articulo.Nombre;
                puja.Articulo.Imagen = en.Articulo.Imagen;
                puja.Puja.Videojuego = en.Articulo.Videojuego.Nombre;
                puja.Puja.ArtDescripcion = en.Articulo.Descripcion;
                puja.Puja.PujaMaxima = en.Puja_max;
                puja.Puja.Cerrada = en.Cerrada;
                puja.Puja.Pagada = en.Pagada;

                pya.Add(puja);
            }
            return pya;

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