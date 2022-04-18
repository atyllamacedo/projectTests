using Project.Metodista.Domain.DTOs;
using Project.Metodista.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Metodista.Domain.Service
{
    public interface IOperacoesService
    {
        MetodistaDTO ProcessarFuncoes(BancoCommon common, TipoOperacao tipoOperacao);
    }
}
