using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Repository;
using System;
using System.IO;
using SQLite;


namespace Project.Metodista.Operacoes.Repository
{
    public class BaseRepository : IBaseRespository
    {
        private readonly SQLiteConnection _dbContext;
        public BaseRepository(bool exist = true)
        {
            string dbPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Metodista.db3");
            _dbContext = new SQLiteConnection(dbPath);

            if (exist)
                _dbContext.CreateTable<MetodistaDTO>();
        }

        public MetodistaDTO Add(BancoCommon entity)
        {
            try
            {
                var usuario = ObterUsuarioPorId(entity.MatriculaId);
                if (usuario == null)
                {
                    var model = new MetodistaDTO
                    {
                        Nome = entity.Nome,
                        Matricula = entity.MatriculaId.ToString(),
                        ValorConta = 0,
                        Rendimento = 0
                    };
                    _dbContext.Insert(model);
                    _dbContext.Commit();
                }
                else
                {
                    //Console.WriteLine("Usuário já poosui cadastro");
                }
                return usuario;
            }
            catch (Exception)
            {
                _dbContext.Rollback();
                return null;
            }
        }

        public MetodistaDTO Deposito(string matriculaId, double valorDeposito)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                user.ValorConta = user.ValorConta + valorDeposito;
                _dbContext.Update(user);
                _dbContext.Commit();
            }

            return user;
        }

        public MetodistaDTO ObterUsuarioPorId(string matriculaId)
        {
            var usuario = _dbContext.Table<MetodistaDTO>().FirstOrDefault(x => x.Matricula.Equals(matriculaId));

            return usuario;
        }

        public MetodistaDTO Rendimentos(string matriculaId, double taxa, int meses)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                double montante = user.ValorConta * Math.Pow((1 + taxa), meses);
                double juros = montante - user.ValorConta;

                user.Rendimento = juros;
                _dbContext.Update(user);
                _dbContext.Commit();
            }

            return user;
        }

        public MetodistaDTO SaqueBanco(string matriculaId, double valorSaque)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                if (valorSaque > user.ValorConta)
                {
                    Console.WriteLine("Valor de saque não permitido. Valor informado é maior que o seu valor em conta");
                }
                else
                {
                    user.ValorConta = user.ValorConta - valorSaque;
                    _dbContext.Update(user);
                    _dbContext.Commit();
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado. Operação não efetuada");
            }

            return user;
        }
    }
}
