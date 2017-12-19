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
                art.Valoracion.Add(v);

                i++;
                valor += item.Puntuacion;
            }
            valor = valor / i;

            art.Articulo.ValoracionMedia = valor;

            v = new Valoracion();
            v.Id = 50;
            v.Puntuacion = 10;
            v.Texto = "Hola";
            art.Valoracion.Add(v);

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