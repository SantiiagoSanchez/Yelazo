using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<UsuarioYelazo> userManager;
        private readonly SignInManager<UsuarioYelazo> signInManager;
        private readonly IConfiguration configuration;

        public UsuarioController(UserManager<UsuarioYelazo> userManager,
                                SignInManager<UsuarioYelazo> signInManager,
                                    IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserTokenDTO>> CrearUsuario([FromBody] UserInfoDTO dto)
        {
            var usuario = new UsuarioYelazo
            {
                UserName = dto.Email,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Zona = dto.Zona,
                Estado = true
            };

            var resultado = await userManager.CreateAsync(usuario, dto.Password);

            if (resultado.Succeeded)
            {
                return await ConstruirToken(usuario);
            }
            else
            {
                return BadRequest(resultado.Errors.First());
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] UserLoginDTO dto)
        {
            var resultado = await signInManager.PasswordSignInAsync(dto.Email,
                                                                    dto.Password,
                                                                    isPersistent: false,
                                                                    lockoutOnFailure: false);
            if (resultado.Succeeded)
            {
                var usuario = await userManager.FindByEmailAsync(dto.Email);
                if (usuario == null) 
                {
                    return BadRequest("Usuario no encontrado");
                }
                return await ConstruirToken(usuario);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        private async Task<UserTokenDTO> ConstruirToken(UsuarioYelazo userInfo)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userInfo.Email),
                new Claim(ClaimTypes.Name, userInfo.Nombre),
                new Claim(ClaimTypes.StreetAddress, userInfo.Direccion),
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id)
            };

            var usuario = await userManager.FindByEmailAsync(userInfo.Email);

            var roles = await userManager.GetRolesAsync(usuario!);
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]!));

            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMonths(1);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiracion,
                signingCredentials: credenciales
                );
            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditarUsuarioDTO>> GetUsuarioPorId(string id)
        {
            var usuario = await userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }
            var dto = new EditarUsuarioDTO
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Direccion = usuario.Direccion
            };
            return dto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarUsuario(string id, [FromBody] EditarUsuarioDTO dto)
        {
            var usuario = await userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Telefono = dto.Telefono;
            usuario.Direccion = dto.Direccion;
            var resultado = await userManager.UpdateAsync(usuario);
            if (resultado.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(resultado.Errors.First());
            }
        }
    }
}
