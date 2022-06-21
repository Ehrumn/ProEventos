using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantPersist
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(string tema, bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}
