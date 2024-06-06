using Domain.Entities;

namespace WebApi91.Services
{
    public interface IAutoresService
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor a);

        public Task<Response<Autor>> Editar(Autor a, int PkAutor);


        public Task<Response<Autor>> Eliminar( int PkAutor);

    }
}
