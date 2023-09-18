﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Email é um campo obrigatório para Login")]
        [EmailAddress(ErrorMessage ="Email informado inválido")]
        [StringLength(100, ErrorMessage ="Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
