﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Security
{
    public class SignInConfigurations
    {
        public SigningCredentials SigningCredentials { get; set; }
        public SecurityKey Key { get; set; }
        public SignInConfigurations()
        {
            using(var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256);
        }
        
    }
}
