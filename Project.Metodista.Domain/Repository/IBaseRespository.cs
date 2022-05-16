using Project.Metodista.Domain.DTOs;

namespace Project.Metodista.Domain.Repository
{
    public interface IBaseRespository
    {
        MetodistaDTO Rendimentos(string matriculaId, double taxa, int meses);
        MetodistaDTO Aplicacao(string matriculaId, int tempo, double valor);
        MetodistaDTO SaqueBanco(string matriculaId, double valorSaque);
        MetodistaDTO Add(BancoCommon entity);
        MetodistaDTO ObterUsuarioPorId(string matriculaId);
        MetodistaDTO Deposito(string matriculaId, double valorDeposito);
    }
}
