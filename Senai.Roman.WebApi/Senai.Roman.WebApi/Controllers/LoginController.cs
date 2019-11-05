using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Interfaces;
using Senai.Roman.WebApi.Repositories;
using Senai.Roman.WebApi.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Senai.Roman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository LoginRepository { get; set; }

        public LoginController()
        {
            LoginRepository = new LoginRepository();
        }
        [HttpPost]
        public IActionResult login(LoginViewModel login)
        {
            try
            {
                Professores usuarioBuscado = LoginRepository.BuscarPorEmailESenha(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "email ou senha inválidos." });

                 var claims = new[]
                {
                     new Claim("Permissao", usuarioBuscado.Tipo),
                     new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdProfessor.ToString()),
                     new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                 };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Roman.WebApi",
                    audience: "Roman.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "erro ao cadastrar." });
            }
        }
    }
}



