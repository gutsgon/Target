
using AutoMapper;
using Target.Data;
using Target.Dto;
using Target.Models;
using Microsoft.EntityFrameworkCore;
using Target.Exceptions;

namespace Target.Service
{
    public class DiaValorService : IDiaValorService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public DiaValorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiaValorModel> GetByIdAsync(int id)
        {
                if(id <= 0) { throw new BusinessException($"Id inválido: {id}"); }
                var diavalor = await _context.DiaValores.FindAsync(id);
                if (diavalor == null){ throw new BusinessException($"Objeto com id {id} não encontrado."); }
                return diavalor;
        }

        public async Task<List<DiaValorModel>> GetByDiaAsync(int dia)
        {
                if (dia <= 0 || dia > 31){ throw new BusinessException($"Dia com valor inválido: {dia} "); }
                var diaValores = await _context.DiaValores.Where(d => d.Dia == dia).ToListAsync() ?? throw new NotFoundException($"Objeto com dia {dia} não encontrado."); ;
                if (diaValores == null || diaValores.Count == 0){ throw new BusinessException($"Objeto com dia {dia} não encontrado"); }
                return diaValores;
        }

        public async Task<List<DiaValorModel>> GetAllAsync()
        {
                var diaValores = await _context.DiaValores.ToListAsync();
                if (diaValores == null || diaValores.Count == 0){ throw new BusinessException("Nenhum dado encontrado."); }
                return diaValores;
        }

        public async Task<List<DiaValorModel>> GetByValorAsync(decimal valor)
        {
                if(valor < 0){ throw new BusinessException($"Valor inválido: {valor}"); }
                var diaValores = await _context.DiaValores.Where(d => d.Valor == valor).ToListAsync() ?? throw new NotFoundException($"Objeto com valor {valor} não encontrado."); ;
                if (diaValores == null || diaValores.Count == 0){ throw new BusinessException($"Objeto com valor {valor} não encontrado"); }
                return diaValores;
        }

        public async Task<DiaValorModel> CreateAsync(DiaValorDto diaValorDto)
        {
                // Negar valores negativos
                if (diaValorDto == null){ throw new BusinessException("Preencha os campos"); }
                if (diaValorDto.Dia <= 0 || diaValorDto.Dia > 31){ throw new BusinessException($"Dia inválido : {diaValorDto.Dia}"); }
                if (diaValorDto.Valor < 0){ throw new BusinessException($"Valor inválido: {diaValorDto.Valor}"); }
                var diaValor = _mapper.Map<DiaValorModel>(diaValorDto);
                try
                {
                    _context.Add(diaValor);
                    await _context.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    throw new BusinessException($"Erro ao salvar objeto no banco de dados");
                }
                return diaValor;
        }
        
        public async Task<List<DiaValorModel>> CreateFormAsync(List<DiaValorDto> diaValorDto)
        {
                // Negar valores negativos
                if (diaValorDto == null){ throw new BusinessException("Preencha os campos"); }
                if (diaValorDto.Any(d => d.Dia <= 0 || d.Dia > 31)){ throw new BusinessException($"Dia inválido : {diaValorDto.Any(d => d.Dia <=0 || d.Dia > 31)}"); }
                if (diaValorDto.Any(d => d.Valor < 0)){ throw new BusinessException($"Valor inválido: {diaValorDto.Any(d => d.Valor < 0)}"); }
                var diaValorFiltrado = new List<DiaValorDto>();
            try
            {
                //Contar casas decimais
                foreach (var obj in diaValorDto)
                {
                    int filtroDeCasas = 4;
                    int casas = BitConverter.GetBytes(decimal.GetBits(obj.Valor)[3])[2];
                    if (casas == filtroDeCasas && obj.Valor != 0)
                    {
                        diaValorFiltrado.Add(obj);
                    }
                }
                var diaValor = _mapper.Map<List<DiaValorModel>>(diaValorFiltrado);
                return diaValor;
            }
            catch (System.Exception)
            {
                throw new BusinessException($"Erro ao salvar objeto no banco de dados");
            }
        }

        public async Task<List<DiaValorModel>> CreateFormXMLAsync(DiaValorXMLDto diaValorDto)
        {
            // Negar valores negativos
                if (diaValorDto == null) { throw new BusinessException("Preencha os campos"); }
                if (diaValorDto.DiaValores.Any(d => d.Dia <= 0 || d.Dia > 31)){ throw new BusinessException($"Dia inválido : {diaValorDto.DiaValores.Any(d => d.Dia <= 0 || d.Dia > 31)}"); }
                if (diaValorDto.DiaValores.Any(d => d.Valor < 0)){ throw new BusinessException($"Valor inválido: {diaValorDto.DiaValores.Any(d => d.Valor < 0)}"); }
                var diaValorFiltrado = new DiaValorXMLDto();
            try
            {
                foreach (var obj in diaValorDto.DiaValores)
                {
                    int filtroDeCasas = 4;
                    int casas = BitConverter.GetBytes(decimal.GetBits(obj.Valor)[3])[2];
                    if (casas == filtroDeCasas && obj.Valor != 0)
                    {
                        diaValorFiltrado.DiaValores.Add(obj);
                    }
                }
                var diaValor = _mapper.Map<List<DiaValorModel>>(diaValorFiltrado.DiaValores);
                return diaValor;
            }
            catch (System.Exception)
            {
                throw new BusinessException($"Erro ao salvar objeto no banco de dados");
            }
        } 


        public async Task<DiaValorModel> UpdateAsync(DiaValorModel diaValor)
        {
            if (diaValor == null) { throw new BusinessException("Preencha um dos campos"); }
            if (diaValor.Id <= 0) { throw new BusinessException($"ID inválido: {diaValor.Id}"); }
            if (diaValor.Dia <= 0 || diaValor.Dia > 31) { throw new BusinessException($"Dia inválido: {diaValor.Dia}"); }
            if (diaValor.Valor < 0) { throw new BusinessException($"Valor inválido: {diaValor.Valor}"); }
            try
            {
                await _context.DiaValores.FindAsync(diaValor.Id);
                _context.Update(diaValor);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw new NotFoundException($"Objeto não encontrado/salvo no banco de dados");
            }
            return diaValor;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
                if(id <= 0){ throw new BusinessException($"Id inválido: {id}"); }
                    var diaValor = await _context.DiaValores.FindAsync(id);
                    if (diaValor == null)
                    {
                        throw new NotFoundException($"Objeto com id {id} não encontrado.");
                    }
                _context.DiaValores.Remove(diaValor);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    throw new BusinessException($"Erro ao deletar objeto no banco de dados");
                }
                return true;
        }

        public async Task<bool> DeleteByDiaAsync(int dia)
        {
                if(dia <= 0 || dia > 31){ throw new BusinessException($"Dia com valor inválido: {dia}"); }
                    var diaValor = await _context.DiaValores.Where(d => d.Dia == dia).ToListAsync();
                    if (diaValor == null || diaValor.Count == 0)
                    {
                        throw new NotFoundException($"Objeto com dia {dia} não encontrado.");
                    }
                _context.DiaValores.RemoveRange(diaValor);
                try
                {
                    await _context.SaveChangesAsync(); 
                }
                catch (System.Exception)
                {
                    throw new BusinessException($"Erro ao deletar objeto no banco de dados");
                }   
                return true;
        }
        
        public async Task<bool> DeleteByValorAsync(decimal valor)
        {
                if(valor < 0){ throw new BusinessException("Valor inválido"); }
                var diaValor = await _context.DiaValores.Where(d => d.Valor == valor).ToListAsync();
                if (diaValor == null || diaValor.Count == 0)
                {
                    throw new NotFoundException($"Objeto com valor {valor} não encontrado.");
                }
                _context.DiaValores.RemoveRange(diaValor);
                try
                {
                    await _context.SaveChangesAsync();   
                }
                catch (System.Exception)
                {   
                    throw new BusinessException($"Erro ao deletar objeto no banco de dados");
                }
                return true;
        }

    }
}