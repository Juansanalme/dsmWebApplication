﻿using System;
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
    public class CategoriaController : BasicController
    {
        // GET: Categoria
        public ActionResult Index()
        {

            SessionInitialize();

            CategoriaCAD cad = new CategoriaCAD(session);
            CategoriaCEN cen = new CategoriaCEN(cad);

            IList<CategoriaEN> listEn = cen.ReadAll(0, -1);
            IEnumerable<Categoria> listModel = new AssemblerCategoria().ConvertListENToModel(listEn).ToList();

            SessionClose();


            return View(listModel);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            CategoriaCAD cad = new CategoriaCAD(session);
            CategoriaCEN cen = new CategoriaCEN(cad);

            CategoriaEN en = cad.ReadOIDDefault(id);
            Categoria model = new AssemblerCategoria().ConvertENToModelUI(en);


            SessionClose();


            return View(model);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {





            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Models.Admin cat)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriaCEN cen = new CategoriaCEN();

                String path2 = "";
                if (file != null)
                {
                    path2 = file.FileName;
                }

                int catId = cen.New_(cat.Categoria.Nombre, 0, path2); //SE LE PASA 0, POR LOS LOLES

                if (cat.Categoria.SuperId != 0)
                    cen.Anyadir_supercat(catId, cat.Categoria.SuperId);

                if (file != null)
                {
                    path2 = file.FileName;
                    if (file.ContentLength > 0)
                    {
                        //PARA UTILIZAR PATH SE NECESITA using System.IO
                        if ((Path.GetExtension(file.FileName).ToLower() == ".jpg") || (Path.GetExtension(file.FileName).ToLower() == ".png") ||
                                (Path.GetExtension(file.FileName).ToLower() == ".gif") || (Path.GetExtension(file.FileName).ToLower() == ".jpeg"))
                        {
                            var path = Path.Combine(Server.MapPath("~/Content/Uploads/Category"), path2);
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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, Models.Admin cat)
        {
            try
            {
                CategoriaCEN cen = new CategoriaCEN();
                CategoriaCP cp = new CategoriaCP();
                int n = cen.get_ICategoriaCAD().ReadOIDDefault(cat.Categoria.Id).Articulo;

                String path2 = cen.get_ICategoriaCAD().ReadOIDDefault(cat.Categoria.Id).Imagen;
                if (file != null)
                {
                    path2 = file.FileName;
                }
                if (file != null)
                {
                    path2 = file.FileName;
                    if (file.ContentLength > 0)
                    {
                        //PARA UTILIZAR PATH SE NECESITA using System.IO
                        if ((Path.GetExtension(file.FileName).ToLower() == ".jpg") || (Path.GetExtension(file.FileName).ToLower() == ".png") ||
                                (Path.GetExtension(file.FileName).ToLower() == ".gif") || (Path.GetExtension(file.FileName).ToLower() == ".jpeg"))
                        {
                            var path = Path.Combine(Server.MapPath("~/Content/Uploads/Category"), path2);
                            file.SaveAs(path);
                        }

                    }
                }

                cen.Modify(cat.Categoria.Id, cat.Categoria.Nombre, n, path2);
                if (cat.Categoria.SuperId != 0)
                    cen.Anyadir_supercat(cat.Categoria.Id, cat.Categoria.SuperId);
                //else
                  //  cen.Anyadir_supercat(cat.Categoria.Id, 0);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Web.HttpContext.Current.Session["PujaError"] = e.Message;
                return RedirectToAction("../Registrado/Admin");
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.Admin cat)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriaCEN cen = new CategoriaCEN();

                cen.Destroy(cat.Categoria.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult AjaxMethod(int id)
        {
            SessionInitialize();
            CategoriaCAD categoriaCAD = new CategoriaCAD(session);
            CategoriaCEN categoriaCEN = new CategoriaCEN(categoriaCAD);
            CategoriaEN categoriaEN = categoriaCEN.get_ICategoriaCAD().ReadOIDDefault(id);

            Categoria cat = null;

            Categoria sub_aux = null;
            List<Categoria> subs = new List<Categoria>();

            foreach (CategoriaEN sub in categoriaEN.Subcategoria)
            {
                sub_aux = new Categoria();
                sub_aux.Id = sub.Id;
                sub_aux.Nombre = sub.Nombre;
                subs.Add(sub_aux);
            }

            if(categoriaEN.Supercategoria != null)
            {
                cat = new Categoria
                {
                    Nombre = categoriaEN.Nombre,
                    SuperId = categoriaEN.Supercategoria.Id,
                    Subs = subs
                };
            }
            else
            {
                cat = new Categoria
                {
                    Nombre = categoriaEN.Nombre,
                    SuperId = 0,
                    Subs = subs
                };
            }

            return Json(cat);
        }
    }
}
