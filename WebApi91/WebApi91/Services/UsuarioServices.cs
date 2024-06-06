using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi91.context;

namespace WebApi91.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDBContext _Context;

        public UsuarioServices(ApplicationDBContext context)
        {
            _Context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _Context.Usuarios.Include(x =>x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);


            }
            catch (Exception ex)
            {
                throw new Exception ("Sucedio un error" + ex.Message);
            }

        }

        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _Context.Usuarios.FirstOrDefaultAsync(x=>x.Pkusuario == id);

                return new Response<Usuario>(res);


            }
            catch (Exception ex) 
            {

                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                   Nombre = request.Nombre,
                   User = request.User,
                   Password = request.Password,
                   Fkrol = request.Fkrol,
                };

                _Context.Usuarios.Add(usuario);
                await _Context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<bool>> EliminarUsuario(int id)
        {
            try
            {
                var usuario = await _Context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<bool>(false, "Usuario no encontrado");
                }

                _Context.Usuarios.Remove(usuario);
                await _Context.SaveChangesAsync();

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse request)
        {
            try
            {
                // Verificacion del usuario 
                var usuario = await _Context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<Usuario>(null, "Usuario no encontrado");
                }

                // Verificacion del rol existente :3
                var rol = await _Context.Roles.FindAsync(request.Fkrol);
                if (rol == null)
                {
                    return new Response<Usuario>(null, "Rol no encontrado");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.Fkrol = request.Fkrol;

                _Context.Usuarios.Update(usuario);
                await _Context.SaveChangesAsync();

                return new Response<Usuario>(usuario);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Sucedió un error: " + ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }


    }
}
