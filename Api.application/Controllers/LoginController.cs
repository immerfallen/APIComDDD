﻿using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        //feito injeção do serviço direto no parâmetro 
        public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(userEntity == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await service.FindByLogin(userEntity);
                if(result!= null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
;                }
            }
            catch (ArgumentException e)
            {

               return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
