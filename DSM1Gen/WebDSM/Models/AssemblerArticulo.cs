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
            //Calcula la valoracion media
            IList<ValoracionEN> vals = en.Valoracion;
            int i = 0;
            double valor = 0;
            foreach (ValoracionEN valEN in vals)
            {
                i++;
                valor += valEN.Puntuacion;
            }
            valor = valor / i;

            Articulo art = new Articulo();
            art.Id = en.Id;
            art.ValoracionMedia = valor;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Descripcion = en.Descripcion;
            art.Stock = en.Stock;
            art.NomCategoria = en.Categoria.Id;
            art.NombreCategoria = en.Categoria.Nombre;
            art.Imagen = en.Imagen;
            art.Img_3d = en.Img_3d;

            art.IdVideojuego = en.Videojuego.Id;

            return art;
            
        }

        public ArticuloYOpinion ConvertENToViewModelUI(ArticuloEN en)
        {
            
            ArticuloYOpinion art = new ArticuloYOpinion();
            art.Articulo.Id = en.Id;
            art.Articulo.Nombre = en.Nombre;
            art.Articulo.Precio = en.Precio;
            art.Articulo.Descripcion = en.Descripcion;
            art.Articulo.Stock = en.Stock;
            art.Articulo.NomCategoria = en.Categoria.Id;
            art.Articulo.NombreCategoria = en.Categoria.Nombre;
            art.Articulo.Imagen = en.Imagen;
            art.Articulo.Img_3d = en.Img_3d;

            art.Articulo.IdVideojuego = en.Videojuego.Id;

            Valoracion v;
            IList<ValoracionEN> var = en.Valoracion;
            int i = 0;
            double valor = 0;
            foreach (ValoracionEN item in var)
            {
                v = new Valoracion();
                v.Id = item.Id;
                v.Puntuacion = item.Puntuacion;
                v.Texto = item.Texto;
                v.Registrado = item.Registrado.N_usuario;
                art.Valoracion.Add(v);

                i++;
                valor += item.Puntuacion;
            }
            art.Articulo.ValoracionMedia = valor / i;

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