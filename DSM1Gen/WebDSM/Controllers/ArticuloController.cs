using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CP.DSM1;
using WebDSM.Models;
using WebMatrix.WebData;

namespace WebDSM.Controllers
{
    public class ArticuloController : BasicController
    {
        //PRUEBA
        public ActionResult IdNombres()
        {
            SessionInitialize();

            CategoriaCAD cad = new CategoriaCAD(session);
            CategoriaCEN cen = new CategoriaCEN(cad);
            
            IEnumerable<CategoriaEN> listaEN = cen.get_ICategoriaCAD().ReadAll(0, -1);

            List<SelectListItem> miLista = new List<SelectListItem>();

            foreach (CategoriaEN cat in listaEN)
            {
                SelectListItem item = new SelectListItem { Value = cat.Id.ToString(), Text = cat.Nombre };

                miLista.Add(item);
            }

            SessionClose();

            return View();
        }

        // GET: Articulo/AnyadirAlCarrito
        public ActionResult AnyadirAlCarrito(int id)
        {
            
            LineaPedidoCP lpCP = new LineaPedidoCP();
            ArticuloCEN aCEN = new ArticuloCEN();

            int idUsuario = (int)Session["idUsuario"];

            //POR AHORA LA CANTIDAD ES 1
            lpCP.Anyado_lineaYprecio(1, id, idUsuario);

            aCEN.Quitar_stock(id, 1);

                        
            return RedirectToAction("../Carrito/Index", new { id = idUsuario});
        }

        // GET: Articulo
        public ActionResult Index()
        {
            SessionInitialize();

            ArticuloCAD articuloCAD = new ArticuloCAD(session);
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

            IList<ArticuloEN> articulos = articuloCEN.ReadAll(0, -1);
            IEnumerable<Articulo> art = new AssemblerArticulo().ConvertListENToModel(articulos).ToList();

            SessionClose();

            return View(art);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            ArticuloCAD articuloCAD = new ArticuloCAD(session);
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

            ArticuloEN articuloEN = articuloCAD.ReadOIDDefault(id);
            ArticuloYOpinion art = new AssemblerArticulo().ConvertENToViewModelUI(articuloEN);
            SessionClose();

            return View(art);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Articulo art)
        {
            try
            {
                // TODO: Add insert logic here
                ArticuloCEN artCen = new ArticuloCEN();
                CategoriaCEN catCEN = new CategoriaCEN();

                art.NombreCategoria = catCEN.get_ICategoriaCAD().ReadOIDDefault(art.NomCategoria).Nombre;

                artCen.New_(art.Nombre, art.Precio, art.NomCategoria, art.Descripcion, art.Stock);
                


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
