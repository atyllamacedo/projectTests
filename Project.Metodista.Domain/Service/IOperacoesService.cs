using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Enum;

namespace Project.Metodista.Domain.Service
{
    public interface IOperacoesService
    {
        MetodistaDTO ProcessarFuncoes(BancoCommon common, TipoOperacao tipoOperacao);
    }
}
