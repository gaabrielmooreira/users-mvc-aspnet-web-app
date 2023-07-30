using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Models;

public class Usuario
{
    [Key]
    public int Codigo { get; set; }
    [Column(TypeName = "varchar")]
    [MaxLength(50)]
    public string Nome { get; set; } = null!;
    [Column(TypeName = "varchar")]
    [MaxLength(20)]
    public string Login { get; set; } = null!;
    [Column(TypeName = "varchar")]
    [MaxLength(14)]
    public string Cpf { get; set; } = null!;
    [Column(TypeName = "varchar")]
    [MaxLength(20)]
    public string Senha { get; set; } = null!;
    [Column(TypeName = "datetime")]
    public DateTime UltimoAcesso { get; set; }

    public int QtdErroLogin { get; set; }

    public bool BlAtivo { get; set; }
}
