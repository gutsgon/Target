
using Microsoft.AspNetCore.Mvc;
using Target.Helpers;
using Target.Rest.Dto;
using Target.Service;

namespace Target.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _service.Login(loginDto.Username, loginDto.Password);
            if (token == null) { return Unauthorized(new { message = "Invalid credentials" }); }
            return Ok(ApiResponseHelper.Response(token, "Login realizado com sucesso", 200));
            
            
        }
    }
}