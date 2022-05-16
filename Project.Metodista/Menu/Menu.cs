using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Enum;
using Project.Metodista.Domain.Service;
using System;
using System.Text.RegularExpressions;


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
            Console.WriteLine("3) Extrato bancário");
            Console.WriteLine("4) Aplicação");
            Console.WriteLine("5) Sair");
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
                    ExtratoBancario();
                    return true;
                case 4:
                    Aplicacao();
                    return true;
                case 5:
                    return true;
                default:
                    return true;
            }
        }

        private void Aplicacao()
        {
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

                    Console.Write("Informe valor para investimento: ");
                    valor = double.Parse(Console.ReadLine());

                    _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, 0, string.Empty, valor, valor, 1), TipoOperacao.Aplicacao);
                }
                catch (Exception)
                {
                    ErrorMessage("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n");
                    valida = false;
                }

            } while (!valida);
        }

        private void ExtratoBancario()
        {
            string matricula = string.Empty;

            bool valida = false;
            do
            {
                try
                {
                    Console.Write("Informe a matricula: ");
                    matricula = Console.ReadLine();

                    var model = _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, 0, string.Empty, 0), TipoOperacao.ObterCliente);

                    Console.WriteLine($"$");
                    Console.WriteLine($"                 EXTRATO BANCÁRIO                 ");
                    Console.WriteLine($"-----------------------------------------------------");
                    Console.WriteLine($"CLIENTE: {model.Nome.Substring(0, 4)}");
                    Console.WriteLine($"APLICAÇÃO: {model.Aplicacao}");
                    Console.WriteLine($"RENDIMENTO: {model.Rendimento}");
                    Console.WriteLine($"-----------------------------------------------------");
                    Console.WriteLine($"DATA: {DateTime.Now.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"-----------------------------------------------------");
                    Console.WriteLine($"SALDO ATUAL: {model.ValorConta}");
                    Console.WriteLine($"-----------------ACESSO DO CLIENTE-------------------");

                    valida = true;
                }
                catch (Exception)
                {
                    ErrorMessage("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n");
                    valida = false;
                }

            } while (!valida);

        }

        private bool MainCadastro()
        {
            string opcao;

            Console.WriteLine("0) Criar cadastro");
            Console.WriteLine("1) Acessar Menu");
            Console.WriteLine("2) Sair");
            Console.WriteLine("\r\nSelecionar opção: ");
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
            bool valida = false;
            do
            {
                try
                {
                    Console.Write("Informe seu nome: ");
                    nome = Console.ReadLine();

                    Console.Write("Informe sua matricula: ");
                    matricula = Console.ReadLine();

                    var model = _operacoesService.ProcessarFuncoes(new Domain.DTOs.BancoCommon(matricula, 0, nome, 0), TipoOperacao.Cadastro);

                    if (model != null)
                    {
                        MainMenu();
                    }
                    valida = true;
                }
                catch (Exception)
                {
                    ErrorMessage("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n");
                    valida = false;
                }
            } while (!valida);
        }

        private void Saque()
        {
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

                    _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, valor, string.Empty, 0), TipoOperacao.Saque);

                }
                catch (Exception)
                {
                    ErrorMessage("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n");
                    valida = false;
                }

            } while (!valida);
        }

        private void Deposito()
        {
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

                    _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, valor, string.Empty, 0), TipoOperacao.Deposito);

                }
                catch (Exception)
                {
                    ErrorMessage("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n");
                    valida = false;
                }

            } while (!valida);          
        }

        private void AplicacaoRendimento()
        {
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

                    _operacoesService.ProcessarFuncoes(new BancoCommon(matricula, 0, string.Empty, 0, taxa, meses), TipoOperacao.AplicacaoRendimento);
                }
                catch (Exception)
                {
                    ErrorMessage("Desculpe não foi possivel continuar com a operação. Informe entrada válida\n");
                    valida = false;
                }

            } while (!valida);
        }

        private void ErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        #endregion
    }
}

