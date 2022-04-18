using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Enum;
using Project.Metodista.Domain.Repository;
using Project.Metodista.Domain.Service;
using Project.Metodista.Operacoes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Metodista.Application.Service
{
    public class OperacoesService : IOperacoesService
    {
        private readonly IBaseRespository _baseRespository;
        public OperacoesService()
        {
            _baseRespository = new BaseRepository();
        }
        public MetodistaDTO ProcessarFuncoes(BancoCommon common, TipoOperacao tipoOperacao)
        {
            try
            {
                Console.WriteLine($"Iniciando operação de {tipoOperacao}");

                switch (tipoOperacao)
                {
                    case TipoOperacao.Saque:
                        return _baseRespository.SaqueBanco(common.MatriculaId, common.Valor);
                    case TipoOperacao.Deposito:
                        return _baseRespository.Deposito(common.MatriculaId, common.Valor);
                    case TipoOperacao.AplicacaoRendimento:
                        return _baseRespository.Rendimentos(common.MatriculaId, common.Taxa, common.Meses);
                    case TipoOperacao.Cadastro:
                        return _baseRespository.Add(common);
                    default:
                        return null;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error na operação: {error.Message}");

                throw new Exception($"Error: {error.Message}");
            }
        }
    }


}
