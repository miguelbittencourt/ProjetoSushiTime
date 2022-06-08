using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSushiTime.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSushiTime.Controllers
{
    //[Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class ClientesController : Controller
    {
        private readonly Contexto db;
        public ClientesController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: ClientesController
        public ActionResult Index()
        {
            return View(db.USUARIOS.ToList());
        }

        //// GET: ClientesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios collection)
        {
            try
            {
                db.USUARIOS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: ClientesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault());
        //}

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Usuarios collection)
        //{
        //    try
        //    {
        //        db.USUARIOS.Update(collection);
        //        db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            db.USUARIOS.Remove(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
