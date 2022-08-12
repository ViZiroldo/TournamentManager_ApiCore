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

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(PlayerViewModel player)
        {
            player.UserId = await RetornarIdUsuarioLogado();
            var playerMap = _IMapper.Map<Player>(player);
            await _IPlayer.Add(playerMap);
            return playerMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(PlayerViewModel player)
        {
            var playerMap = _IMapper.Map<Player>(player);
            await _IPlayer.Update(playerMap);
            return playerMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(PlayerViewModel player)
        {
            var playerMap = _IMapper.Map<Player>(player);
            await _IPlayer.Delete(playerMap);
            return playerMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<PlayerViewModel> GetEntityById(Player player)
        {
            player = await _IPlayer.GetEntityById(player.Id);
            var playerMap = _IMapper.Map<PlayerViewModel>(player);
            return playerMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
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