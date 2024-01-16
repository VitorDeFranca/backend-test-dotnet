using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;
using TesteFCamara.Domain.Interfaces;
using TesteFCamara.Persistence.Contexts;
using TesteFCamara.Persistence.Repositories.Shared;

namespace TesteFCamara.Persistence.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(DataContext context) : base(context) { }
        public async Task<List<Veiculo>> GetAllVeiculosAsync(int estabelecimentoId)
        {
            IQueryable<Veiculo> query = _context.Veiculos.Where(v => v.EstabelecimentoId == estabelecimentoId);

            return await query.AsNoTracking().OrderBy(v => v.Id).ToListAsync();
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int estabelecimentoId, int id)
        {
            IQueryable<Veiculo> query = _context.Veiculos.Where(v => v.EstabelecimentoId == estabelecimentoId 
                                                                    && v.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
