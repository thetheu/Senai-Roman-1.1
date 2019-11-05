using Microsoft.EntityFrameworkCore;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Interfaces;
using Senai.Roman.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Professores BuscarPorEmailESenha(LoginViewModel login)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Professores usuario = ctx.Professores.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }
    }
}
