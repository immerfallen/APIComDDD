﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
