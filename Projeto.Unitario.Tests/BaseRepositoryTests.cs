using Moq;
using Project.Metodista.Application.Service;
using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Enum;
using Project.Metodista.Domain.Repository;
using Projeto.Unitario.Tests.Doubles;
using Xunit;

namespace Projeto.Unitario.Tests
{
    public class BaseRepositoryTests
    {
        private readonly Mock<IBaseRespository> _mockBaseRepository = new Mock<IBaseRespository>();
        private readonly OperacoesService operacoesService;
        private readonly MetodistaDTO _usuario = UsuarioDouble.Usuario;
        private readonly BancoCommon bancoCommon;
        private readonly string matriculaId = "312098";
        private readonly string nome = "Testes.TI";

        public BaseRepositoryTests()
        {
            bancoCommon = new BancoCommon(It.IsAny<string>(),
                                          It.IsAny<double>(),
                                          It.IsAny<string>(),
                                          It.IsAny<double>(),
                                          It.IsAny<int>());

            _mockBaseRepository.Setup(x => x.ObterUsuarioPorId(It.IsAny<string>())).Returns(_usuario);

            operacoesService = new OperacoesService(_mockBaseRepository.Object);

        }

        [Fact]
        public void Quando_tipo_acao_saque_deve_diminuir_valor_conta()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.Saque);
        }
    }
}
