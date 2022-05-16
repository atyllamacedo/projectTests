using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Repository;
using Project.Metodista.Operacoes.Helpers;
using SQLite;
using System;
using System.IO;

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

        public virtual MetodistaDTO Add(BancoCommon entity)
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

                    ConsoleExtension.WriteLineSucesso("Operação realizada com sucesso.");
                }
                else
                {
                    ConsoleExtension.WriteLineAlerta("Esse usuário já foi cadastrado.");
                }
                return usuario;
            }
            catch (Exception)
            {
                _dbContext.Rollback();
                return null;
            }
        }

        public virtual MetodistaDTO Aplicacao(string matriculaId, int tempo, double valor)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                double percentual = 20.3 / 100.0;
                double valorFinal = valor - (percentual * valor);

                user.Aplicacao = valorFinal;
                _dbContext.Update(user);
                _dbContext.Commit();

                ConsoleExtension.WriteLineSucesso("Operação realizada com sucesso.");
            }
            else
            {
                ConsoleExtension.WriteLineError("Usuário não encontrado. Operação não efetuada");
            }

            return user;
        }

        public virtual MetodistaDTO Deposito(string matriculaId, double valorDeposito)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                user.ValorConta = user.ValorConta + valorDeposito;
                _dbContext.Update(user);
                _dbContext.Commit();

                ConsoleExtension.WriteLineSucesso("Operação realizada com sucesso.");
            }
            else
            {
                ConsoleExtension.WriteLineError("Usuário não encontrado. Operação não efetuada");
            }

            return user;
        }

        public virtual MetodistaDTO ObterUsuarioPorId(string matriculaId)
        {
            var usuario = _dbContext.Table<MetodistaDTO>().FirstOrDefault(x => x.Matricula.Equals(matriculaId));

            return usuario;
        }

        public virtual MetodistaDTO Rendimentos(string matriculaId, double taxa, int meses)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                //Fórmula de Juros Compostos: Jc = P(1 + R / 100)T
                //Onde P = Valor Inicial, T = Intervalo de Tempo, R = Taxa.

                double montante = user.ValorConta * Math.Pow((1 + taxa), meses);
                double juros = montante - user.ValorConta;

                user.Rendimento = juros;
                _dbContext.Update(user);
                _dbContext.Commit();

                ConsoleExtension.WriteLineSucesso("Operação realizada com sucesso.");
            }
            else
            {
                ConsoleExtension.WriteLineError("Usuário não encontrado. Operação não efetuada");
            }

            return user;
        }

        public virtual MetodistaDTO SaqueBanco(string matriculaId, double valorSaque)
        {
            var user = ObterUsuarioPorId(matriculaId);

            if (user != null)
            {
                if (valorSaque > user.ValorConta)
                {

                    ConsoleExtension.WriteLineError("Valor de saque não permitido. Valor informado é maior que o seu valor em conta");
                }
                else
                {
                    user.ValorConta = user.ValorConta - valorSaque;
                    _dbContext.Update(user);
                    _dbContext.Commit();
                    ConsoleExtension.WriteLineSucesso("Operação realizada com sucesso.");
                }
            }
            else
            {
                ConsoleExtension.WriteLineError("Usuário não encontrado. Operação não efetuada");
            }

            return user;
        }
    }
}
