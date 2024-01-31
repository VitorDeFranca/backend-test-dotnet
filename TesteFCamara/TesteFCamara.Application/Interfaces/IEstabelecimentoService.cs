using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Application.Dtos;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Application.Interfaces
{
    public interface IEstabelecimentoService
    {
        Task<List<Estabelecimento>> GetAllEstabelecimentosAsync(bool includeVeiculos = false);
        Task<Estabelecimento> GetEstabelecimentoByIdAsync(int estabelecimentoId, bool includeVeiculos = true);
        Task<Estabelecimento> AddEstabelecimento(Estabelecimento model);
        Task<Estabelecimento> UpdateEstabelecimento(int estabelecimentoId, Estabelecimento model);
        Task<bool> DeleteEstabelecimento(int estabelecimentoId);


    }
}
