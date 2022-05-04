using AutoFixture;
using Project.Metodista.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
