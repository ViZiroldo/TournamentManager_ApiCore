using Domain.Interfaces.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceTorneio : IServiceTorneio
    {
        private readonly ITorneio _ITorneio;

        public ServiceTorneio(ITorneio ITorneio)
        {
            _ITorneio = ITorneio;
        }
    }
}
