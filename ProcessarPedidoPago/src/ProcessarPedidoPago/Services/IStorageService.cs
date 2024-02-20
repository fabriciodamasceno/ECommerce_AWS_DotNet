using ECommerceLambda.Domain.Models;

namespace ProcessarPedidoPago.Services
{
    public interface IStorageService
    {
        Task SalvarNotaFiscal(NotaFiscal notaFiscal);
    }
}
