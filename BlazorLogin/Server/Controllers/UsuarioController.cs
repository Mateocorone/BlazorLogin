using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorLogin.Shared;

namespace BlazorLogin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();

            if (login.Correo == "admin@admin.com" && login.Clave == "admin123")
            {
                sesionDTO.Nombre = "admin";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";   
            }
            else if (login.Correo == "empleado@empleado.com" && login.Clave == "empleado123")
            {
                sesionDTO.Nombre = "empleado";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Empleado";
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Usuario o contraseña incorrecta" });
            }
            return StatusCode(StatusCodes.Status200OK, sesionDTO);
        }
    }
}

    