using Usuarios.Models;

namespace Usuarios.Data
{
    public class AppDbSeed
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                if (!context.Usuarios.Any())
                {
                    context.Usuarios.AddRange(new List<Usuario>()
                    {
                        new Usuario()
                        {
                            Nome = "Rosana",
                            Login = "rosana",
                            Cpf = "123.456.789-10",
                            Senha = "123456",
                            UltimoAcesso = new DateTime(1900,05,09,09,15,00),
                            QtdErroLogin = 0,
                            BlAtivo = false,
                        },
                        new Usuario()
                        {
                            Nome = "Thais",
                            Login = "thais",
                            Cpf = "123.456.789-11",
                            Senha = "123456",
                            UltimoAcesso = new DateTime(1900,05,09,09,15,00),
                            QtdErroLogin = 0,
                            BlAtivo = false,
                        },
                        new Usuario()
                        {
                            Nome = "Joao",
                            Login = "joao",
                            Cpf = "123.456.789-12",
                            Senha = "123456",
                            UltimoAcesso = new DateTime(1900,05,09,09,15,00),
                            QtdErroLogin = 0,
                            BlAtivo = false,
                        },
                        new Usuario()
                        {
                            Nome = "Larissa",
                            Login = "larissa",
                            Cpf = "123.456.789-13",
                            Senha = "123456",
                            UltimoAcesso = new DateTime(1900, 05, 09, 09, 15, 00),
                            QtdErroLogin = 0,
                            BlAtivo = false,
                        },
                        new Usuario()
                        {
                            Nome = "Thiago",
                            Login = "thiago",
                            Cpf = "123.456.789-14",
                            Senha = "123456",
                            UltimoAcesso = new DateTime(1900, 05, 09, 09, 15, 00),
                            QtdErroLogin = 0,
                            BlAtivo = false,
                        },
                        new Usuario()
                        {
                            Nome = "Kendy",
                            Login = "kendy",
                            Cpf = "123.456.789-15",
                            Senha = "123456",
                            UltimoAcesso = new DateTime(1900, 05, 09, 09, 15, 00),
                            QtdErroLogin = 0,
                            BlAtivo = false,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
