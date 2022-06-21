using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantPersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context=context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(string tema, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
                .Include(e => e.RedesSociais);

            if (includeEventos)
                query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
               .Include(p => p.RedesSociais);

            if (includeEventos)
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            query = query.OrderBy(p => p.Id)
                          .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
               .Include(p => p.RedesSociais);

            if (includeEventos)
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            query = query.OrderBy(p => p.Id)
                          .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
