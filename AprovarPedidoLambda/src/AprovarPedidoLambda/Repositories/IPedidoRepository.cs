using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Repositories
{
    public interface IPedidoRepository
    {
        Task SalvarPedido(Pedido pedido);
    }
}
