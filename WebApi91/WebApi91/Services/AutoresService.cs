using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.context;

namespace WebApi91.Services
{
    public class AutoresService : IAutoresService
    {
        private readonly ApplicationDBContext _Context;
        private object commandType;

        public AutoresService(ApplicationDBContext context)
        {
            _Context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _Context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);

                response = result.ToList();

                return new Response<List<Autor>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :c");
            }

        }
        public async Task<Response<Autor>> Crear(Autor a)
        {
            try
            {
                Autor result = new Autor();
                result = (await _Context.Database.GetDbConnection().QueryAsync<Autor>("SpCrearAutor", new { a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :c");


            }

        }
        public async Task<Response<Autor>> Editar (Autor a, int PkAutor)
        {
            try
            {
                Autor result = new Autor();
                result = (await _Context.Database.GetDbConnection().QueryAsync<Autor>("SpActulizarAutor", new { PkAutor, a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :c");


            }

        }
        public async Task<Response<Autor>> Eliminar(int PkAutor)
        {
            try
            {
                Autor result = new Autor();
                result = (await _Context.Database.GetDbConnection().QueryAsync<Autor>("SpEliminarAutor", new { PkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :c");


            }

        }
    }
}
