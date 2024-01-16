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
    public class EstabelecimentoRepository : BaseRepository<Estabelecimento>, IEstabelecimentoRepository
    {

        public EstabelecimentoRepository(DataContext context) : base(context) { }

        public async Task<List<Estabelecimento>> GetAllEstabelecimentosAsync(bool includeVeiculos = false)
        {
            IQueryable<Estabelecimento> query = _context.Estabelecimentos;

            if (includeVeiculos)
                query = query.Include(e => e.Veiculos);

            return await query.AsNoTracking().OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<Estabelecimento> GetEstabelecimentoByIdAsync(int id, bool includeVeiculos = false)
        {
            IQueryable<Estabelecimento> query = _context.Estabelecimentos.Where(e => e.Id == id);

            if (includeVeiculos)
                query = query.Include(e => e.Veiculos);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
