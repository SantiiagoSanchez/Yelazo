using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public UsuarioController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager,
                                    IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserTokenDTO>> CrearUsuario([FromBody] UserInfoDTO dto)
    }
}
