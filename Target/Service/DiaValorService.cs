
using Target.Data;
using Target.Models;

namespace Target.Service
{
    public class DiaValorService : IDiaValorService
{
    private readonly AppDbContext _context;

    public DiaValorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DiaValor?> ObterPorIdAsync(int id)
    {
        return await _context.DiaValor.FindAsync(id);
    }

    public async Task<DiaValor> CriarAsync(DiaValor diaValor)
    {
        // Exemplo de regra de negócio
        if (diaValor.Valor < 0)
            throw new ArgumentException("Valor não pode ser negativo.");

        _context.DiaValor.Add(diaValor);
        await _context.SaveChangesAsync();
        return diaValor;
    }
}

}