using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Usuarios.Models;
using Usuarios.Data.DTOs;

namespace Usuarios.Data.ViewModels
{
    public class HomeVM
    {
        public UsuarioVMDTO? SessaoUsuario { get; set; }
        public List<UsuarioVMDTO>? Usuarios;
    }
}
