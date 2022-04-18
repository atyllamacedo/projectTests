using Project.Metodista.Domain.DTOs;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Metodista.Domain.Repository
{
    public interface IBaseRespository
    {
        MetodistaDTO Rendimentos(string matriculaId, double taxa, int meses);
        MetodistaDTO SaqueBanco(string matriculaId, double valorSaque);
        MetodistaDTO Add(BancoCommon entity);
        MetodistaDTO ObterUsuarioPorId(string matriculaId);
        MetodistaDTO Deposito(string matriculaId, double valorDeposito);
    }
}
