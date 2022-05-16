using Project.Metodista.Configure;
using Project.Metodista.Domain.Service;
using Instancia = Project.Metodista.Menu;

namespace Project.Metodista
{
    class Program
    {
        private static IOperacoesService _iOperacoesService;
        static void Main(string[] args)
        {
            InjecaoDependenciaRepository.Service(out _iOperacoesService);

            var menu = new Instancia.Menu(_iOperacoesService);
            menu.Initial();
        }

    }
}

