using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        //feito injeção do serviço direto no parâmetro 
        public async Task<object> Login([FromBody] LoginDTO login, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(login == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await service.FindByLogin(login);
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
