using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PracticaCore2EMQ.Filters;
using PracticaCore2EMQ.Models;
using PracticaCore2EMQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Controllers
{
    public class ManageController : Controller
    {
        private RepositoryLibros repo;


        public ManageController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public IActionResult IniciarSesion()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> IniciarSesion(String email, String password)
        {
            Usuario usuario = this.repo.LogIn(email, password);
            if (usuario != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                Claim claimIdUsuario = new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString());
                identity.AddClaim(claimIdUsuario);

                Claim claimNombreUsuario = new Claim(ClaimTypes.Name, usuario.Nombre);
                identity.AddClaim(claimNombreUsuario);

                Claim claimFoto = new Claim("fotousuario",usuario.Foto);
                identity.AddClaim(claimFoto);                            

                ClaimsPrincipal usuarioPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, usuarioPrincipal);
             
                string controller = TempData["controller"].ToString();
                string action = TempData["action"].ToString();

                return RedirectToAction(action, controller);
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
            }
            return View();
        }

        [AuthorizeUsuario]
        public IActionResult Perfil()
        {
         
            Usuario user = this.repo.FindUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(user);
        
        }

        [AuthorizeUsuario]
        public IActionResult Pedidos()
        {
            List<VistaPedidos> pedidos = this.repo.GetPedidosUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            pedidos.OrderByDescending(x => x.FechaPedido);
            return View(pedidos);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


    }
}
