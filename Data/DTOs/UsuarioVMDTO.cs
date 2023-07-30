namespace Usuarios.Data.DTOs
{
    public class UsuarioVMDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public DateTime UltimoAcesso { get; set; }
        public int QtdErroLogin { get; set; }
        public bool BlAtivo { get; set; }
    }
}
