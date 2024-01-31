using TesteFCamara.Application.Dtos;
using TesteFCamara.Application.Interfaces;
using TesteFCamara.Domain.Entities;
using TesteFCamara.Domain.Interfaces;

namespace TesteFCamara.Application.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public async Task<List<Estabelecimento>> GetAllEstabelecimentosAsync(bool includeVeiculos = false)
        {
            try
            {
                List<Estabelecimento> estabelecimentos = await _estabelecimentoRepository.GetAllEstabelecimentosAsync(includeVeiculos);
                if (estabelecimentos == null) return null;

                /*List<EstabelecimentoDTO> estabelecimentosResponse = null;
                foreach (var estabelecimento in estabelecimentos)
                {
                    var estabelecimentoDTO = EstabelecimentoDTO.ConverterParaResponse(estabelecimento);
                    estabelecimentosResponse?.Add(estabelecimentoDTO);
                }*/

                return estabelecimentos;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Estabelecimento> GetEstabelecimentoByIdAsync(int estabelecimentoId, bool includeVeiculos = true)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimentoId, includeVeiculos);
                if (estabelecimento == null) return null;

                //var estabelecimentoResponse = EstabelecimentoDTO.ConverterParaResponse(estabelecimento);
                
                return estabelecimento;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Estabelecimento> AddEstabelecimento(Estabelecimento model)
        {
            try
            {
                //Estabelecimento estabelecimento = EstabelecimentoDTO.ConverterParaEntidade(model);
                _estabelecimentoRepository.Create(model);

                if (await _estabelecimentoRepository.SaveChangesAsync())
                {
                    var estabelecimentoRetorno = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(model.Id, false);
                    //return EstabelecimentoDTO.ConverterParaResponse(estabelecimentoRetorno);

                    return estabelecimentoRetorno;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Estabelecimento> UpdateEstabelecimento(int estabelecimentoId, Estabelecimento model)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimentoId, false);
                if (estabelecimento == null) return null;

                model.Id = estabelecimento.Id;

                _estabelecimentoRepository.Update(model);

                if (await _estabelecimentoRepository.SaveChangesAsync())
                {
                    var estabelecimentoRetorno = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimento.Id, false);
                    //return EstabelecimentoDTO.ConverterParaResponse(estabelecimentoRetorno);

                    return estabelecimentoRetorno;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> DeleteEstabelecimento(int estabelecimentoId)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimentoId, false);
                if (estabelecimento == null) throw new Exception("Estabelecimento não encontrado para deleção");

                _estabelecimentoRepository.Delete(estabelecimento);
                return await _estabelecimentoRepository.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
