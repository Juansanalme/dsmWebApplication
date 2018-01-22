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
    public class CarritoController : BasicController
    {



        // GET: Carrito
        public ActionResult Index()
        {
            try
            {
                int miId = (int)Session["idUsuario"];

                SessionInitialize();

                CarritoCAD cad = new CarritoCAD(session);
                CarritoCEN cen = new CarritoCEN(cad);

                LineaPedidoCAD lpCAD = new LineaPedidoCAD(session);
                LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpCAD);

                CarritoEN en = cen.get_ICarritoCAD().ReadOIDDefault(miId);
                CarritoYLineas model = new AssemblerCarrito().ConvertENToViewModelUI(en);
                //Carrito model = new AssemblerCarrito().ConvertENToModelUI(en);

                CarritoCP cp = new CarritoCP();
                cp.Calcular_precio(miId);

                //SACAR LAS FOTOS DE CADA ARTICULO
                

                SessionClose();

                return View(model);
            }
            catch
            {
                return RedirectToAction("../Registrado/Login");
            }
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito/Edit/5
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

        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrito/Delete/5
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

        public ActionResult QuitarDeCarrito (int id)
        {
            
            LineaPedidoCP cp = new LineaPedidoCP();
            CarritoCP cp2 = new CarritoCP();

            cp.Quito_linea_a_carroYprecio(id);

            int idUsuario = (int)Session["idUsuario"];

            cp2.Calcular_precio(idUsuario);

            int n = (int)Session["nCarrito"];
            n--;
            Session["nCarrito"] = n;

            return RedirectToAction("Index", new { id = idUsuario } );
        }

        public ActionResult FinalizarCompra(int id)
        {
            try
            {
                CarritoCP cp = new CarritoCP();
                CarritoCEN cen = new CarritoCEN();

                float precio = cen.get_ICarritoCAD().ReadOIDDefault(id).Precio;

                if(precio != 0)
                {
                    cp.Finalizar_compra(id, precio);

                    Session["nCarrito"] = 0;
                    return RedirectToAction("LoadPedidos", "Pedido", (int)Session["idUsuario"]);

                }
                else
                {
                    return RedirectToAction("Index", "Carrito", new { id = id });
                }

            }
            catch
            {
                //ALGUNOS DE LOS ARTICULOS NO TIENEN STOCK
                return View();
            }
        }
    }
}
