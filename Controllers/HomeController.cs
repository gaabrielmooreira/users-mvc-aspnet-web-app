using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Usuarios.Data;
using Usuarios.Data.DTOs;
using Usuarios.Data.ViewModels;
using Usuarios.Models;

namespace Usuarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionUser")))
            {
                UsuarioVMDTO SessaoUsuarioNulo = new UsuarioVMDTO
                {
                    Codigo = 0,
                    Nome = "",
                    Login = "",
                    Cpf = "",
                    UltimoAcesso = DateTime.Now,
                    QtdErroLogin = 0,
                    BlAtivo = false,
                };
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(SessaoUsuarioNulo));
            }

            var sessaoUsuario = JsonConvert
                .DeserializeObject<UsuarioVMDTO>(
                    HttpContext.Session.GetString("SessionUser")
                );

            var usuarios = _context.Usuarios
                .Select( u => new UsuarioVMDTO {
                    Codigo = u.Codigo,
                    Nome = u.Nome,
                    Login = u.Login,
                    Cpf = u.Cpf,
                    UltimoAcesso = u.UltimoAcesso,
                    QtdErroLogin = u.QtdErroLogin,
                    BlAtivo = u.BlAtivo,
                })
                .ToList();

            HomeVM homeVM = new HomeVM()
            {
                SessaoUsuario = sessaoUsuario,
                Usuarios = usuarios
            };

            return View(homeVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}