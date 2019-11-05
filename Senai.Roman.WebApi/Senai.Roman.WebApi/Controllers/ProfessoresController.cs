using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Repositories;

namespace Senai.Roman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        ProfessoresRepository professoresRepository = new ProfessoresRepository();

        [Authorize(Roles = "Professor(a)")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(professoresRepository.Listar());
        }


        [Authorize(Roles = "Professor(a)")]
        [HttpPost]
        public IActionResult Cadastrar(Projetos projetos)
        {
            professoresRepository.Cadastrar(projetos);
            return Ok();
        }
    }
}