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
    public class PlayerController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IPlayer _IPlayer;

        public PlayerController(IMapper IMapper, IPlayer IPlayer)
        {
            _IMapper = IMapper;
            _IPlayer = IPlayer;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Add")]
        public async Task<List<Notifies>> Add(PlayerViewModel player)
        {
            //player.UserId = await RetornarIdUsuarioLogado();
            var playerMap = _IMapper.Map<Player>(player);
            await _IPlayer.Add(playerMap);
            return playerMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Update")]
        public async Task<List<Notifies>> Update(PlayerViewModel player)
        {
            var playerMap = _IMapper.Map<Player>(player);
            await _IPlayer.Update(playerMap);
            return playerMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Delete")]
        public async Task<List<Notifies>> Delete(PlayerViewModel player)
        {
            var playerMap = _IMapper.Map<Player>(player);
            await _IPlayer.Delete(playerMap);
            return playerMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("GetEntityById/{id:int}")]
        public async Task<PlayerViewModel> GetEntityById(int id)
        {
            var player = await _IPlayer.GetEntityById(id);
            var playerMap = _IMapper.Map<PlayerViewModel>(player);
            return playerMap;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("List")]
        public async Task<List<PlayerViewModel>> List()
        {
            var player = await _IPlayer.List();
            var playerMap = _IMapper.Map<List<PlayerViewModel>>(player);
            return playerMap;
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