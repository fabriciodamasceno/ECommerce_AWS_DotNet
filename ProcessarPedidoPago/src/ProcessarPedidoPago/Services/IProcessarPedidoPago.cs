using ECommerceLambda.Domain.Models;

namespace ProcessarPedidoPago.Services
{
    public interface IProcessarPedidoPago
    {
        Task Processar(Pedido pedido);
    }
}
