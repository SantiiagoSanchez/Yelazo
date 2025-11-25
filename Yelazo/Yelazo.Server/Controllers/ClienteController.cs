using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly UserManager<UsuarioYelazo> userManager;
        private readonly SignInManager<UsuarioYelazo> signInManager;
        private readonly IConfiguration configuration;
        private readonly IClienteRepositorio repositorio;

        public ClienteController(UserManager<UsuarioYelazo> userManager,
                                 SignInManager<UsuarioYelazo> signInManager,
                                 IConfiguration configuration,
                                 IClienteRepositorio repositorio)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.repositorio = repositorio;
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

            if (!resultado.Succeeded)
            {
                return BadRequest(resultado.Errors.First());
            }
            
            var rolAsignar = "cliente";

            var resultadoRol = await userManager.AddToRoleAsync(usuario, rolAsignar);

            if (!resultadoRol.Succeeded)
            {
                await userManager.DeleteAsync(usuario);
                return BadRequest(resultadoRol.Errors.First());
            }

            return Ok();
        }

        [HttpGet()]
        public async Task<ActionResult<List<UserListadoDTO>>> GetClientes()
        {
            // Trae todos los usuarios que tengan el rol "Cliente"
            var usuarios = await userManager.GetUsersInRoleAsync("Cliente");

            var lista = usuarios.Select(usuario => new UserListadoDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Zona = usuario.Zona,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Estado = usuario.Estado
            }).ToList();

            return lista;
        }

        [HttpGet("historial/{id}")]
        public async Task<ActionResult> GetHistorialPedidos(string id)
        {
            var pedido = await repositorio.ObtenerHistorialPorId(id);
            return Ok(pedido);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EditarClienteDTO>> GetClientePorId(string id)
        {
            var usuario = await userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var detalle = new EditarClienteDTO
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                Zona = usuario.Zona,
                Estado = usuario.Estado
            };
            return detalle;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditarCliente(string id, EditarClienteDTO dto)
        {
            var usuario = await userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Direccion = dto.Direccion;
            usuario.Telefono = dto.Telefono;
            usuario.Zona = dto.Zona;
            usuario.Estado = dto.Estado;
            var resultado = await userManager.UpdateAsync(usuario);
            if (!resultado.Succeeded)
            {
                return BadRequest(resultado.Errors.First());
            }
            return NoContent();
        }

    }
}
