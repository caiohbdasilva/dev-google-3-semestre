using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly EventContext _context;
        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }


        public Task Atualizar(Guid IdTipoUsuario, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<TipoUsuario> BuscarPorId(Guid IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Guid IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoUsuario>> Listar()
        {
            return await _context.TipoUsuario.AsNoTracking().ToListAsync();
        }
    }
}
