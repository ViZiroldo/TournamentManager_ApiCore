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
    public class GrupoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IGrupo _IGrupo;

        public GrupoController(IMapper IMapper, IGrupo IGrupo)
        {
            _IMapper = IMapper;
            _IGrupo = IGrupo;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Add")]
        public async Task<List<Notifies>> Add(GrupoViewModel grupo)
        {
            //grupo.UserId = await RetornarIdUsuarioLogado();
            var grupoMap = _IMapper.Map<Grupo>(grupo);
            await _IGrupo.Add(grupoMap);
            return grupoMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Update")]
        public async Task<List<Notifies>> Update(GrupoViewModel grupo)
        {
            var grupoMap = _IMapper.Map<Grupo>(grupo);
            await _IGrupo.Update(grupoMap);
            return grupoMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost]
        [Route("Delete")]
        public async Task<List<Notifies>> Delete(GrupoViewModel grupo)
        {
            var grupoMap = _IMapper.Map<Grupo>(grupo);
            await _IGrupo.Delete(grupoMap);
            return grupoMap.Notificacoes;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("GetEntityById")]
        public async Task<GrupoViewModel> GetEntityById(Grupo grupo)
        {
            grupo = await _IGrupo.GetEntityById(grupo.Id);
            var grupoMap = _IMapper.Map<GrupoViewModel>(grupo);
            return grupoMap;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        [Route("List")]
        public async Task<List<GrupoViewModel>> List()
        {
            var grupo = await _IGrupo.List();
            var grupoMap = _IMapper.Map<List<GrupoViewModel>>(grupo);
            return grupoMap;
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