using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;
using TesteFCamara.Domain.Interfaces.Shared;

namespace TesteFCamara.Domain.Interfaces
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task<List<Veiculo>> GetAllVeiculosAsync(int estabelecimentoId);
        Task<Veiculo> GetVeiculoByIdAsync(int estabelecimentoId, int id);
    }
}
