using Domain.Interfaces.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceGrupo : IServiceGrupo
    {
        private readonly IGrupo _IGrupo;

        public ServiceGrupo(IGrupo IGrupo)
        {
            _IGrupo = IGrupo;
        }
    }
}
