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
    public class JogosController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IJogos _IJogos;

        public JogosController(IMapper IMapper, IJogos IJogos)
        {
            _IMapper = IMapper;
            _IJogos = IJogos;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Add")]
        public async Task<List<Notifies>> Add(JogosViewModel jogos)
        {
            //jogos.UserId = await RetornarIdUsuarioLogado();
            var jogosMap = _IMapper.Map<Jogos>(jogos);
            await _IJogos.Add(jogosMap);
            return jogosMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Update")]
        public async Task<List<Notifies>> Update(JogosViewModel jogos)
        {
            var jogosMap = _IMapper.Map<Jogos>(jogos);
            await _IJogos.Update(jogosMap);
            return jogosMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Delete")]
        public async Task<List<Notifies>> Delete(JogosViewModel jogos)
        {
            var jogosMap = _IMapper.Map<Jogos>(jogos);
            await _IJogos.Delete(jogosMap);
            return jogosMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("GetEntityById")]
        public async Task<JogosViewModel> GetEntityById(Jogos jogos)
        {
            jogos = await _IJogos.GetEntityById(jogos.Id);
            var jogosMap = _IMapper.Map<JogosViewModel>(jogos);
            return jogosMap;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("List")]
        public async Task<List<JogosViewModel>> List()
        {
            var jogos = await _IJogos.List();
            var jogosMap = _IMapper.Map<List<JogosViewModel>>(jogos);
            return jogosMap;
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