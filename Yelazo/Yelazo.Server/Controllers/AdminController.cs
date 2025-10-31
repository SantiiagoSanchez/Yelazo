﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("usuarios/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly Context context;
        private readonly SignInManager<UsuarioYelazo> signInManager;
        private readonly UserManager<UsuarioYelazo> userManager;

        public AdminController(Context context, SignInManager<UsuarioYelazo> signInManager, UserManager<UsuarioYelazo> userManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserListadoDTO>>> Get()
        {
            var usuarios = userManager.Users.ToList();
            var lista = new List<UserListadoDTO>();

            foreach (var usuario in usuarios)
            {
                var roles = await userManager.GetRolesAsync(usuario); // trae la lista de roles
                lista.Add(new UserListadoDTO
                {
                    Id = usuario.Id,
                    Email = usuario.Email!,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Telefono = usuario.Telefono,
                    Rol = roles.FirstOrDefault() ?? "Sin rol" // tomamos el primer rol
                });
            }

            return lista;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RolDTO>>> GetRoles()
        {
            var roles = context.Roles.AsQueryable();
            var rolesDTO = roles.Select(x => new RolDTO
            {
                Nombre = x.Name!
            }).ToList();
            return rolesDTO;
        }

        [HttpPost("asignar-rol")]
        public async Task<ActionResult> AsignarRol(RolEditarDTO dto)
        {
            var usuario = await signInManager.UserManager.FindByIdAsync(dto.UsuarioId);
            if (usuario == null) { return NotFound("Usuario no encontrado"); }
            await signInManager.UserManager.AddToRoleAsync(usuario, dto.Rol);
            return NoContent();
        }

        [HttpPost("remover-rol")]
        public async Task<ActionResult> RemoverRol(RolEditarDTO dto)
        {
            var usuario = await signInManager.UserManager.FindByIdAsync(dto.UsuarioId);
            if (usuario == null) { return NotFound("Usuario no encontrado"); }
            await signInManager.UserManager.RemoveFromRoleAsync(usuario, dto.Rol);
            return NoContent();
        }
    }
}
