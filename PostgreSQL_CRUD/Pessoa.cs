﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_CRUD
{
    class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }

        public string email { get; set; }

        public int idade { get; set; }
    }
}
