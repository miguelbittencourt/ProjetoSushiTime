using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSushiTime.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSushiTime.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto db;
        public ProdutosController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: ProdutosController
        public ActionResult Index()
        {
            return View(db.PRODUTOS.ToList());
        }

        // GET: ProdutosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produtos collection)
        {
            try
            {
                db.PRODUTOS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.PRODUTOS.Where(a => a.Id == id).FirstOrDefault());
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produtos dadosTela)
        {
            try
            {
                db.PRODUTOS.Update(dadosTela);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(int id)
        {
            db.PRODUTOS.Remove(db.PRODUTOS.Where(a => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
