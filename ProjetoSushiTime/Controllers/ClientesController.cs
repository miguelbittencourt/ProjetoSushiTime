using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSushiTime.Entidades;
using ProjetoSushiTime.Models;
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
            return View(db.CLIENTES.ToList());
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
        public ActionResult Create(CadastroViewModel collection)
        {
            try
            {
                Usuarios usuarios = new Usuarios();
                usuarios.Login = collection.Login;
                usuarios.Senha = collection.Senha;

                db.USUARIOS.Add(usuarios);
                db.SaveChanges();

                Cliente cliente = new Cliente();
                cliente.Nome = collection.Login;
                cliente.Logradouro = collection.Logradouro;
                cliente.NumeroCasa = collection.NumeroCasa;
                cliente.Telefone = collection.Telefone;
                cliente.Bairro = collection.Bairro;
                cliente.Cidade = collection.Cidade;

                db.CLIENTES.Add(cliente);
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
