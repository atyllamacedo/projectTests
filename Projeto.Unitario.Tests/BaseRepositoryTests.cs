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
        private readonly string matriculaId = "312090";
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

        [Fact(DisplayName = "Saque")]
        public void Quando_tipo_acao_saque_deve_diminuir_valor_conta()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.Saque);
        }

        [Fact(DisplayName = "Deposito")]
        public void Quando_tipo_acao_deposito_deve_aumentar_valor_conta()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.Deposito);
        }

        [Fact(DisplayName = "Cadastro")]
        public void Quando_tipo_acao_cadastro_deve_cadastrar_cliente()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.Cadastro);
        }

        [Fact(DisplayName = "Rendimento")]
        public void Quando_tipo_acao_aplicacao_rendimento_deve_aplicar_conta()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.AplicacaoRendimento);
        }

        [Fact(DisplayName = "ObterCliente")]
        public void Quando_tipo_acao_obter_cliente()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.ObterCliente);
        }

        [Fact(DisplayName = "Aplicacao")]
        public void Quando_tipo_acao_obter_aplicacao()
        {
            operacoesService.ProcessarFuncoes(bancoCommon, TipoOperacao.Aplicacao);
        }
    }
}
