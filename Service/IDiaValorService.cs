using Target.Dto;
using Microsoft.AspNetCore.Mvc;
using Target.Models;

namespace Target.Service
{
    public interface IDiaValorService
    {
        Task<DiaValorModel> GetByIdAsync(int id);
        Task<List<DiaValorModel>> GetAllAsync();
        Task<List<DiaValorModel>> GetByDiaAsync(int dia);
        Task<List<DiaValorModel>> GetByValorAsync(decimal valor);
        Task<DiaValorModel> CreateAsync(DiaValorDto diaValorDto);
        Task<List<DiaValorModel>> CreateFormAsync(List<DiaValorDto> diaValorDto);
        Task<List<DiaValorModel>> CreateFormXMLAsync(DiaValorXMLDto diaValorDto);
        Task<DiaValorModel> UpdateAsync(DiaValorModel diaValorModel);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> DeleteByDiaAsync(int dia);
        Task<bool> DeleteByValorAsync(decimal valor);
    }
}