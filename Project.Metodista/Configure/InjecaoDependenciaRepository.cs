using Microsoft.Extensions.DependencyInjection;
using Project.Metodista.Application.Service;
using Project.Metodista.Domain.Repository;
using Project.Metodista.Domain.Service;
using Project.Metodista.Operacoes.Repository;

namespace Project.Metodista.Configure
{
    public class InjecaoDependenciaRepository
    {
        public static void Service(out IOperacoesService operacoesService)
        {
            var servico = new ServiceCollection();

            servico.AddTransient(typeof(IBaseRespository), typeof(BaseRepository));
            servico.AddTransient(typeof(IOperacoesService), typeof(OperacoesService));

            var serviceProvider = servico.BuildServiceProvider();
            operacoesService = serviceProvider.GetService<IOperacoesService>();
        }
    }
}
