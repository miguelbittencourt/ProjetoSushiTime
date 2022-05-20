using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjetoSushiTime.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoSushiTime.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto db;

        public LoginController(Contexto contexto)
        {
            db = contexto;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login, string senha)
        {
            Cliente usuarioLogado = db.CLIENTES.Where(a => a.Nome == login && a.Senha == senha).FirstOrDefault();

            if (usuarioLogado == null)
            {
                TempData["erro"] = "Usuario ou senha inválidos";
                return View();
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuarioLogado.Nome));
            claims.Add(new Claim(ClaimTypes.Sid, usuarioLogado.Id.ToString()));

            var userIdentity = new ClaimsIdentity(claims, "Acesso");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties());

            return Redirect("/");
        }
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return Redirect("/Login/Login");
        }
    }
}
