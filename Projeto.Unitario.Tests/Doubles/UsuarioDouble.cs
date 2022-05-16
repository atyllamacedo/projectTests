using AutoFixture;
using Project.Metodista.Domain.DTOs;

namespace Projeto.Unitario.Tests.Doubles
{
    public class UsuarioDouble
    {
        private static Fixture fixture = new Fixture();

        public static MetodistaDTO Usuario
        {
            get
            {
                return fixture.Create<MetodistaDTO>();
            }
        }
    }
}
