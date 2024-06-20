using ApiRestful.Infra;
using ApiRestful.Models;
using ApiRestful.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestful.Controllers
{
    [ApiController]
    [Route("api/produto/auth")]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public IActionResult Auth(string login, string senha)
        {
                      
            if (login == "admin" && senha == "admin")
            {
                var token = TokenService.GenerateToken();
                return Ok(token);
            }
            else
            {
                return BadRequest("Usuário ou Senha incorretos!");
            }
                
        }
    }
}
