﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public string Contrasena { get; set; }

    }
}