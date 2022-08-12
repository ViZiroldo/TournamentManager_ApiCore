using Domain.Interfaces.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceJogos : IServiceJogos
    {
        private readonly IJogos _IJogos;

        public ServiceJogos(IJogos IJogos)
        {
            _IJogos = IJogos;
        }
    }
}
