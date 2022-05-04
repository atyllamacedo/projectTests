using Microsoft.Extensions.DependencyInjection;
using Project.Metodista.Application.Service;
using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Enum;
using Project.Metodista.Domain.Repository;
using Project.Metodista.Domain.Service;
using Project.Metodista.Operacoes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project.Metodista.Menu
{

    public class Menu
    {
        private readonly string regexValidaSeENumero = @"^[0-9]+$";
        private readonly IOperacoesService _operacoesService;

        public Menu(IOperacoesService operacoesService)
        {
            _operacoesService = operacoesService;
        }

        public void MenuProject()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        #region Metodos Privados
        public void Initial()
        {
            bool showCadastro = true;
            while (showCadastro)
            {
                showCadastro = MainCadastro();
            }
        }

        private bool MainMenu()
        {
            string opcao;
            Console.Clear();
            Console.WriteLine("QUALIDADE DE SOFTWARE E TESTE DE SOFTWARE", Environment.NewLine);
            Console.WriteLine("0) Operação de Saque");
            Console.WriteLine("1) Operacao de Deposito");
            Console.WriteLine("2) Redimento");
            Console.WriteLine("3) Sair");
            Console.Write("\r\nSelecionar opção: ");
            opcao = Console.ReadLine();

            var tipoOperacao = Regex.IsMatch(opcao, regexValidaSeENumero) ? int.Parse(opcao) : 4;

            switch (tipoOperacao)
            {
                case 0:
                    Saque();
                    return true;
                case 1:
                    Deposito();
                    return true;
                case 2:
                    AplicacaoRendimento();
                    return true;
                case 3:
                    return false;
                default:
                    return true;
            }
        }

        private bool MainCadastro()
        {
            string opcao;
            Console.Clear();
            Console.WriteLine("0) Criar cadastro");
            Console.WriteLine("1) Acessar Menu");
            Console.WriteLine("2) Sair");
            Console.Write("\r\nSelecionar opção: ");
            opcao = Console.ReadLine();

            var tipoOperacao = Regex.IsMatch(opcao, regexValidaSeENumero) ? int.Parse(opcao) : 2;

            switch (tipoOperacao)
            {
                case 0:
                    CadastroCliente();
                    return true;
                case 1:
                    MainMenu();
                    return true;
                case 2:
                    return false;
                default:
                    return true;
            }
        }

        private void CadastroCliente()
        {
            string nome;
            string matricula;

            Console.Clear();
            Console.Write("Informe seu nome: ");
            nome = Console.ReadLine();

            Console.Write("Informe sua matricula: ");
            matricula = Console.ReadLine();

            var model = _operacoesService.ProcessarFuncoes(new Domain.DTOs.BancoCommon(matricula, 0, nome, 0), TipoOperacao.Cadastro);

            if (model != null)
            {
                Console.WriteLine("Cadastro relaziado com sucesso!!");
                MainMenu();
            }
            else
            {
                Console.WriteLine("Erro ao cadastratar. Verifique se o usuário já posssui cadastro!!");
            }
        }

        private void Saque()
        {
            Console.Clear();

            string matricula = string.Empty;
            double valor = 0;
            bool valida = false;
            do
            {
                try
                {

                    Console.Write("Informe a matricula: ");
                    matricula = Console.ReadLine();
                    valida = true;

                    Console.Write("Informe o valor para saque: ");
                    valor = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n\n");
                    Console.ResetColor();
                    valida = false;
                }

            } while (!valida);

            _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, valor, string.Empty, 0), TipoOperacao.Saque);
        }

        private void Deposito()
        {
            Console.Clear();

            string matricula = string.Empty;
            double valor = 0;
            bool valida = false;
            do
            {
                try
                {

                    Console.Write("Informe a matricula: ");
                    matricula = Console.ReadLine();
                    valida = true;

                    Console.Write("Informe o valor para deposito: ");
                    valor = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n\n");
                    Console.ResetColor();
                    valida = false;
                }

            } while (!valida);

            _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, valor, string.Empty, 0), TipoOperacao.Deposito);

        }

        private void AplicacaoRendimento()
        {
            Console.Clear();

            string matricula = string.Empty;
            double taxa = 0;
            int meses = 0;
            bool valida = false;
            do
            {
                try
                {

                    Console.Write("Informe a matricula: ");
                    matricula = Console.ReadLine();
                    valida = true;

                    Console.Write("Informe a taxa de juros: ");
                    taxa = double.Parse(Console.ReadLine());

                    Console.Write("Quantidade de meses a ser pago: ");
                    meses = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n\n");
                    Console.ResetColor();
                    valida = false;
                }

            } while (!valida);

            _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, 0, string.Empty, 0, taxa, meses), TipoOperacao.AplicacaoRendimento);
        }

        #endregion
    }
}

