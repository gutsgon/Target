using Target.Models;

namespace Target.Service
{
    public interface IDiaValorService
    {
        Task<DiaValor> ObterPorIdAsync(int id);
        Task<DiaValor> CriarAsync(DiaValor diaValor);
        Task<DiaValor> AtualizarAsync(DiaValor diaValor);

    }
}