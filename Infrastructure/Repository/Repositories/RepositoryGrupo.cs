using Domain.Interfaces.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public  class RepositoryGrupo : RepositoryGenerics<Grupo>, IGrupo
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGrupo()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    

    }
}
