using Domain.Interfaces.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceFuncao : IServiceFuncao
    {
        private readonly IFuncao _IFuncao;

        public ServiceFuncao(IFuncao IFuncao)
        {
            _IFuncao = IFuncao;
        }
    }
}
