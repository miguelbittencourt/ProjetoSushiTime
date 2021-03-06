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
            Usuarios usuarioLogado = db.USUARIOS.Where(a => a.Login == login && a.Senha == senha).FirstOrDefault();
            //Usuarios clienteLogado = db.USUARIOS.Where(a => a.Login == login && a.Senha == senha).FirstOrDefault();

            if (usuarioLogado == null)
            {
                TempData["erro"] = "Usuario ou senha inválidos";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuarioLogado.Login),
                new Claim(ClaimTypes.Sid, usuarioLogado.Id.ToString()),
                new Claim(ClaimTypes.Role, "Logado"),
                new Claim(ClaimTypes.Role, "Atendente")
            };

            var userIdentity = new ClaimsIdentity(claims, "Acesso");

            ClaimsPrincipal principal = new(userIdentity);
            await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(50),
                IsPersistent = true
            });

            return Redirect("/");
        }
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return Redirect("/Home/Index");
        }
    }
}
