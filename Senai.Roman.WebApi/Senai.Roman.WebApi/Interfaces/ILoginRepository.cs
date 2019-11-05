using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Interfaces
{
    interface ILoginRepository
    {
        Professores BuscarPorEmailESenha(LoginViewModel login);

    }
}
