using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSushiTime.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto db;
        public IActionResult cadastrarProduto()
        {
            return View();
        }
        public IActionResult listarProduto()
        {
            return View();
        }

    }
}
    