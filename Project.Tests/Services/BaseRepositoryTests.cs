using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Repository;
using Project.Metodista.Operacoes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Tests.Services
{
    public class BaseRepositoryTests
    {
        private readonly IBaseRespository _baseRepo;
        private readonly string matriculaId = "312098";
        private readonly string nome = "Testes.TI";

        public BaseRepositoryTests()
        {
            _baseRepo = new BaseRepository(false);

            _baseRepo.ObterUsuarioPorId(matriculaId);
        }

        //[Fact]
        //public void Quando_tipo_acao_saque_deve_diminuir_valor_conta()
        //{
        //    var model = new BancoCommon(matriculaId, 10, nome, 0);

        //    _baseRepo.
           

        //}
    }
}
