﻿using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Professores
    {
        public Professores()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int IdProfessor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public ICollection<Projetos> Projetos { get; set; }
    }
}
