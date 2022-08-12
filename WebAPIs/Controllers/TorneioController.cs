using AutoMapper;
using Domain.Interfaces.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using System.Text.Json;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneioController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly ITorneio _ITorneio;

        public TorneioController(IMapper IMapper, ITorneio ITorneio)
        {
            _IMapper = IMapper;
            _ITorneio = ITorneio;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("AddTorneio")]
        public async Task<bool> AddTorneio(TorneioViewModel torneio)
        {
            torneio.DataCadastro = DateTime.Now;
            torneio.DataAlteracao = DateTime.Now;
            torneio.UserId = "8d6e47df-95d3-466b-9b26-71c960ebae62";
            var torneioMap = _IMapper.Map<Torneio>(torneio);
            await _ITorneio.Add(torneioMap);
            return true;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("UpdateTorneio")]
        public async Task<bool> Update(TorneioViewModel torneio)
        {
            //var obj = await _ITorneio.GetEntityById(torneio.Id);
            var torneioMap = _IMapper.Map<Torneio>(torneio);
            await _ITorneio.Update(torneioMap);
            return true;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<TorneioViewModel> GetById(int id)
        {
            var torneio = await _ITorneio.GetEntityById(id);
            var torneioMap = _IMapper.Map<TorneioViewModel>(torneio);
            return torneioMap;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("ListTorneio")]
        public async Task<List<TorneioViewModel>> List()
        {
            var torneio = await _ITorneio.List();
            var torneioMap = _IMapper.Map<List<TorneioViewModel>>(torneio);
            return torneioMap;
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