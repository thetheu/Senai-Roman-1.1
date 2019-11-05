﻿using Senai.Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class ProfessoresRepository
    {
        public List<Projetos> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Projetos.ToList();
            }
        }
        
        public void Cadastrar(Projetos projetos)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Add(projetos);
                ctx.SaveChanges();
            }
        }
        

    }
}
