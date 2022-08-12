using Domain.Interfaces.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceTime : IServiceTime
    {
        private readonly ITime _ITime;

        public ServiceTime(ITime ITime)
        {
            _ITime = ITime;
        }
    }
}
