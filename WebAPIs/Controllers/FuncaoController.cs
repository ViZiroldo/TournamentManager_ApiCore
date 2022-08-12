using AutoMapper;
using Domain.Interfaces.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IFuncao _IFuncao;

        public FuncaoController(IMapper IMapper, IFuncao IFuncao)
        {
            _IMapper = IMapper;
            _IFuncao = IFuncao;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(FuncaoViewModel Funcao)
        {
            Funcao.UserId = await RetornarIdUsuarioLogado();
            var funcaoMap = _IMapper.Map<Funcao>(Funcao);
            await _IFuncao.Add(funcaoMap);
            return funcaoMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(FuncaoViewModel Funcao)
        {
            var funcaoMap = _IMapper.Map<Funcao>(Funcao);
            await _IFuncao.Update(funcaoMap);
            return funcaoMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(FuncaoViewModel Funcao)
        {
            var funcaoMap = _IMapper.Map<Funcao>(Funcao);
            await _IFuncao.Delete(funcaoMap);
            return funcaoMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<FuncaoViewModel> GetEntityById(Funcao Funcao)
        {
            Funcao = await _IFuncao.GetEntityById(Funcao.Id);
            var funcaoMap = _IMapper.Map<FuncaoViewModel>(Funcao);
            return funcaoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<FuncaoViewModel>> List()
        {
            var funcao = await _IFuncao.List();
            var funcaoMap = _IMapper.Map<List<FuncaoViewModel>>(funcao);
            return funcaoMap;
        }



        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;

        }


    }
}