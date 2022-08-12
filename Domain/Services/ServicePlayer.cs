using Domain.Interfaces.Interfaces;
using Domain.Interfaces.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicePlayer : IServicePlayer
    {
        private readonly IPlayer _IPlayer;

        public ServicePlayer(IPlayer IPlayer)
        {
            _IPlayer = IPlayer;
        }
    }
}
