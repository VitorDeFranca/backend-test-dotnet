using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;
using TesteFCamara.Domain.Interfaces.Shared;

namespace TesteFCamara.Domain.Interfaces
{
    public interface IEstabelecimentoRepository : IBaseRepository<Estabelecimento>
    {
        Task<List<Estabelecimento>> GetAllEstabelecimentosAsync(bool includeVeiculos);
        Task<Estabelecimento> GetEstabelecimentoByIdAsync(int id, bool includeVeiculos);
    }
}
