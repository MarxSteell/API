﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Marvel.WebApi.Domains
{
    public class PersonagensDomain
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Lancamento { get; set; }
        public string Descricao { get; set; }
    }
}
