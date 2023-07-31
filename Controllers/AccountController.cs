using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Usuarios.Data;
using Usuarios.Data.DTOs;
using Usuarios.Data.ViewModels;
using Usuarios.Models;

namespace Usuarios.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = _context.Usuarios
                .Where(u => u.Login == loginVM.Login)
                .FirstOrDefault();

            if (user == null)
            {
                TempData["Error"] = "Login e/ou senha incorretos.";
                return View(loginVM);
            };

            if (user.BlAtivo) {
                TempData["Error"] = "Usuario foi bloqueado, após 3 tentativas incorretas.";
                return View(loginVM);
            }

            if(loginVM.Senha != user.Senha)
            {
                TempData["Error"] = "Login e/ou senha incorretos.";
                user.QtdErroLogin++;
                if (user.QtdErroLogin == 3) user.BlAtivo = true;
                _context.Usuarios.Update(user);
                _context.SaveChanges();
                return View(loginVM);
            }

            user.UltimoAcesso = DateTime.Now;
            user.QtdErroLogin = 0;
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
            UsuarioVMDTO SessaoUsuario = new UsuarioVMDTO
            {
                Codigo = user.Codigo,
                Nome = user.Nome,
                Login = user.Login,
                Cpf = user.Cpf,
                UltimoAcesso = user.UltimoAcesso,
                QtdErroLogin = user.QtdErroLogin,
                BlAtivo = user.BlAtivo,
            };
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(SessaoUsuario));
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
           if (!ModelState.IsValid) return View(registerVM);

            var user = _context.Usuarios.Where(u => u.Login == registerVM.Login).FirstOrDefault();
            
            if (user != null) {
                TempData["Error"] = "Esse Login já está em uso.";
                return View(registerVM);
            }
            
            var newUser = new Usuario()
            {
                Nome = registerVM.Nome,
                Login = registerVM.Login,
                Cpf = registerVM.Cpf,
                Senha = registerVM.Senha,
                QtdErroLogin = 0,
                UltimoAcesso = DateTime.Now,
                BlAtivo = false,
            };
            
            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Usuario cadastrado com sucesso.";
            
            return RedirectToAction("Register");
        }

        public IActionResult Logoff()
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

            return RedirectToAction("Index","Home");
        }
    }
}
