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
            art.Valoracion = valor;
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
            art.articulo.Id = en.Id;
            art.articulo.Nombre = en.Nombre;
            art.articulo.Precio = en.Precio;
            art.articulo.Descripcion = en.Descripcion;
            art.articulo.Stock = en.Stock;
            art.articulo.NomCategoria = en.Categoria.Id;
            art.articulo.NombreCategoria = en.Categoria.Nombre;

            //art.valoracion.Texto = 
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