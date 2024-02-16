using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Services
{
    public interface IAprovarPedidoService
    {
        Task AprovarPedido(Pedido pedido);
    }
}
