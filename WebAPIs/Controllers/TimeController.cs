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
    public class TimeController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly ITime _ITime;

        public TimeController(IMapper IMapper, ITime ITime)
        {
            _IMapper = IMapper;
            _ITime = ITime;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("AddTime")]
        public async Task<List<Notifies>> AddTime(TimeViewModel time)
        {
            //time.UserId = await RetornarIdUsuarioLogado();
            time.DataCadastro = DateTime.Now;
            var timeMap = _IMapper.Map<Time>(time);
            await _ITime.Add(timeMap);
            return timeMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("UpdateTime")]
        public async Task<List<Notifies>> UpdateTime(TimeViewModel time)
        {
            var timeMap = _IMapper.Map<Time>(time);
            await _ITime.Update(timeMap);
            return timeMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("DeleteTime")]
        public async Task<List<Notifies>> DeleteTime(TimeViewModel time)
        {
            var timeMap = _IMapper.Map<Time>(time);
            await _ITime.Delete(timeMap);
            return timeMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("GetTimeById/{id:int}")]
        public async Task<TimeViewModel> GetTimeById(int id)
        {
            var time = await _ITime.GetEntityById(id);
            var timeMap = _IMapper.Map<TimeViewModel>(time);
            return timeMap;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("ListTime")]
        public async Task<List<TimeViewModel>> ListTime()
        {
            var time = await _ITime.List();
            var timeMap = _IMapper.Map<List<TimeViewModel>>(time);
            return timeMap;
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