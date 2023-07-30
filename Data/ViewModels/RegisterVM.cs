using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Usuarios.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O login é obrigatório.")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "O cpf é obrigatório.")]
        [RegularExpression(@"^([0-9]){3}\.([0-9]){3}\.([0-9]){3}-([0-9]){2}$", 
            ErrorMessage = "O CPF deve estar no tipo XXX.XXX.XXX-XX")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(20, MinimumLength = 6)]
        public string Senha { get; set; } = null!;

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare("Senha", ErrorMessage = "A confirmação de senha não corresponde à senha.")]
        public string ConfirmarSenha { get; set; } = null!;
    }
}
