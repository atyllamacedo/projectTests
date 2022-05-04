using Microsoft.Extensions.DependencyInjection;
using Project.Metodista.Application.Service;
using Project.Metodista.Domain.Repository;
using Project.Metodista.Domain.Service;
using Project.Metodista.Operacoes.Repository;
using Instancia = Project.Metodista.Menu;

namespace Project.Metodista
{
    class Program
    {
        private static IOperacoesService _iOperacoesService;
        static void Main(string[] args)
        {
            ConfigureService(out _iOperacoesService);

            var menu = new Instancia.Menu(_iOperacoesService);
            menu.Initial();
        }
        private static void ConfigureService(out IOperacoesService operacoesService)
        {
            var servico = new ServiceCollection();
            servico.AddTransient(typeof(IBaseRespository), typeof(BaseRepository));
            servico.AddTransient(typeof(IOperacoesService), typeof(OperacoesService));

            var serviceProvider = servico.BuildServiceProvider();
            operacoesService = serviceProvider.GetService<IOperacoesService>();
        }
    }
}

