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
using System.IO;

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

        //DEVUELVE EL MISMO IENUMERABLE<ARTICULO> QUE LE PASES PERO CON LAS FOTOS DE CADA ARTICULO
        public IEnumerable<Articulo> GetAllFotos(IEnumerable<Articulo> art)
        {
            //SACO CADA FOTO DE CADA ARTICULO
            foreach (Articulo a in art)
            {
                string imagen = Path.Combine(Server.MapPath("~/Content/Uploads/Item_images"), a.Id.ToString());

                if ((System.IO.File.Exists(imagen + ".jpg")))
                {
                    a.Imagen = a.Id + ".jpg";
                }
                else if ((System.IO.File.Exists(imagen + ".jpeg")))
                {
                    a.Imagen = a.Id + ".jpeg";
                }
                else if ((System.IO.File.Exists(imagen + ".png")))
                {
                    a.Imagen = a.Id + ".png";
                }
                else if ((System.IO.File.Exists(imagen + ".gif")))
                {
                    a.Imagen = a.Id + ".gif";
                }
                else
                {
                    //SI NO TIENE FOTO DE PERFIL
                    a.Imagen = "";
                }
            }

            return art;
        }

        // POST: Articulo/Details/5
        // AL PUBLICAR UNA VALORACION
        [HttpPost]
        public ActionResult Details (ArticuloYOpinion op)
        {
            //CREO LA VALORACION
            //EL ID DEL ARTICULO LO PASO MEDIANTE UN CAMPO OCULTO EN EL FORMULARIO
            
            ValoracionCEN cen = new ValoracionCEN();

            int idUsuario = (int)Session["idUsuario"];

            cen.New_(op.Puntuacion, op.Texto, idUsuario, op.IdArt);
            
            return RedirectToAction("Details", new { id = op.IdArt });
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

            int n = (int)Session["nCarrito"];
            n++;
            Session["nCarrito"] = n;

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

            art = GetAllFotos(art);

            SessionClose();

            return View(art);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id=0)
        {
            if (id != 0)
            {

                SessionInitialize();

                ArticuloCAD articuloCAD = new ArticuloCAD(session);
                ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

                ArticuloEN articuloEN = articuloCAD.ReadOIDDefault(id);
                ArticuloYOpinion art = new AssemblerArticulo().ConvertENToViewModelUI(articuloEN);
                SessionClose();

                return View(art);
            }
            else
                return RedirectToAction("Index","Home",null);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Models.Admin art)

        {
            try
            {

                // TODO: Add insert logic here
                ArticuloCEN artCen = new ArticuloCEN();
                CategoriaCEN catCEN = new CategoriaCEN();

                if (art.Articulo.Img_3d == null)
                    art.Articulo.Img_3d = "";
                
                String path2 = "";

                if(file!=null)
                    path2 = file.FileName; 

                art.Articulo.NombreCategoria = catCEN.get_ICategoriaCAD().ReadOIDDefault(art.Articulo.NomCategoria).Nombre;


                int art2 = artCen.New_(art.Articulo.Nombre, art.Articulo.Precio, art.Articulo.NomCategoria, art.Articulo.Descripcion, art.Articulo.Stock, path2, art.Articulo.Img_3d,art.Articulo.IdVideojuego);

                //Modifico solo el atributo que guarda el nombre de la imagen
                
                var path = "";

                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        //PARA UTILIZAR PATH SE NECESITA using System.IO
                        if ((Path.GetExtension(file.FileName).ToLower() == ".jpg") || (Path.GetExtension(file.FileName).ToLower() == ".png") ||
                                (Path.GetExtension(file.FileName).ToLower() == ".gif") || (Path.GetExtension(file.FileName).ToLower() == ".jpeg"))
                        {
                            path = Path.Combine(Server.MapPath("~/Content/Uploads/Item_images"), art2 + Path.GetExtension(file.FileName).ToLower());
                            file.SaveAs(path);

                        }

                    }
                }

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
        public ActionResult Edit(Models.Admin art)
        {
            try
            {
                ArticuloCEN articuloCEN = new ArticuloCEN();

                ArticuloEN new_art = new ArticuloEN();

                articuloCEN.Modify(art.Articulo.Id, art.Articulo.Nombre, art.Articulo.Precio, art.Articulo.Descripcion, art.Articulo.Stock, art.Articulo.Imagen, art.Articulo.Img_3d);

                return RedirectToAction("Details/"+art.Articulo.Id);
            }
            catch
            {
                System.Web.HttpContext.Current.Session["PujaError"] = "Error al actualizar artículo";
                return RedirectToAction("../Registrado/Admin");
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View();
            

        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.Admin cat)
        {
            try
            {
                // TODO: Add insert logic here
                ArticuloCEN cen = new ArticuloCEN();

                cen.Destroy(cat.Articulo.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Busqueda(String termino)
        {
            SessionInitialize();

            ArticuloCAD articuloCAD = new ArticuloCAD(session);
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

            IList<ArticuloEN> articulos = articuloCEN.Busqueda_por_nombre(termino);
            IEnumerable<Articulo> art = new AssemblerArticulo().ConvertListENToModel(articulos).ToList();

            SessionClose();

            art = GetAllFotos(art);

            return View("Index", art);
        }

        public ActionResult Categoria(String item)
        {
            SessionInitialize();

            ArticuloCAD articuloCAD = new ArticuloCAD(session);
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

            CategoriaCAD categoriaCAD = new CategoriaCAD(session);
            CategoriaCEN categoriaCEN = new CategoriaCEN(categoriaCAD);

            List<ArticuloEN> articulosEN = new List<ArticuloEN>();
            articulosEN.AddRange(articuloCEN.Busqueda_por_categoria(item));

            foreach (CategoriaEN cat in categoriaCAD.ReadAll(0, -1))
            {
                if(cat.Nombre == item)
                {
                    foreach (CategoriaEN subcat in cat.Subcategoria)
                    {
                        IList<ArticuloEN> articulos = articuloCEN.Busqueda_por_categoria(subcat.Nombre);
                        articulosEN.AddRange(articulos);
                    }
                }
            }

            IEnumerable<Articulo> art = new AssemblerArticulo().ConvertListENToModel(articulosEN);

            SessionClose();

            art = GetAllFotos(art);

            return View("Index", art);
        }

        public ActionResult Videojuego(String item)
        {
            SessionInitialize();

            ArticuloCAD articuloCAD = new ArticuloCAD(session);
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);
            IList<ArticuloEN> articulosEN = articuloCEN.Busqueda_por_videojuego(item);

            IEnumerable<Articulo> art = new AssemblerArticulo().ConvertListENToModel(articulosEN);

            SessionClose();

            art = GetAllFotos(art);
            return View("Index", art);
        }

        public ActionResult LoadFavoritos()
        {
            try
            {
                SessionInitialize();

                RegistradoCAD registradoCAD = new RegistradoCAD(session);
                RegistradoCEN registradoCEN = new RegistradoCEN(registradoCAD);

                ArticuloCAD articuloCAD = new ArticuloCAD(session);
                ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

                int miID = (int)Session["idUsuario"];
                RegistradoEN registradoEN = registradoCEN.get_IRegistradoCAD().ReadOIDDefault(miID);

                IList<ArticuloEN> articulosEN = registradoEN.A_favorito;
                IEnumerable<Articulo> art = new AssemblerArticulo().ConvertListENToModel(articulosEN);

                SessionClose();

                art = GetAllFotos(art);
                return View("Favoritos", art);
            }
            catch (Exception e)
            {
                return RedirectToAction("../Home");
            }
        }

        public ActionResult FavAnyadir(int artId)
        {
            try
            {
                SessionInitialize();

                RegistradoCEN registradoCEN = new RegistradoCEN();

                List<int> lista = new List<int>();
                lista.Add(artId);

                int miID = (int)Session["idUsuario"];
                registradoCEN.Añadir_fav(miID, lista);

                return RedirectToAction("../Articulo/Details", new { id = artId });
            }
            catch (Exception e)
            {
                return RedirectToAction("../Home");
            }
        }

        public ActionResult FavQuitar(int artId)
        {
            try
            {
                SessionInitialize();

                RegistradoCEN registradoCEN = new RegistradoCEN();

                List<int> lista = new List<int>();
                lista.Add(artId);

                int miID = (int)Session["idUsuario"];
                registradoCEN.Eliminar_fav(miID, lista);

                return RedirectToAction("../Articulo/Details", new { id = artId });
            }
            catch (Exception e)
            {
            return RedirectToAction("../Home");
            }
        }

        [HttpPost]
        public JsonResult AjaxMethod(int id)
        {
            ArticuloCEN articuloCEN = new ArticuloCEN();
            ArticuloEN articuloEN = articuloCEN.get_IArticuloCAD().ReadOIDDefault(id);
            Articulo art = new Articulo
            {
                Nombre = articuloEN.Nombre,
                Precio = articuloEN.Precio,
                NomCategoria = articuloEN.Categoria.Id,
                Descripcion = articuloEN.Descripcion,
                Stock = articuloEN.Stock
            };
            return Json(art);
        }
    }
}
