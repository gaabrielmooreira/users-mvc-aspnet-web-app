using System.ComponentModel.DataAnnotations;

namespace Usuarios.Data.ViewModels
{
    public class LoginVM
    {
        [Required]
        [StringLength(20)]
        public string Login { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
