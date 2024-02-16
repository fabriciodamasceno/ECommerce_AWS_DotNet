using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Services
{
    public interface IMessageService
    {
        Task SendMessage(Pedido pedido);
    }
}
