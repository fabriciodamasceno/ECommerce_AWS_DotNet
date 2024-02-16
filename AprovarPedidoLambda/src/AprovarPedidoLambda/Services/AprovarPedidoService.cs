using AprovarPedidoLambda.Repositories;
using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Services
{
    public class AprovarPedidoService : IAprovarPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public AprovarPedidoService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            //repositorio
            //messageService
        }

        public async Task AprovarPedido(Pedido pedido)
        {
            await this.pedidoRepository.SalvarPedido(pedido);
        }
    }
}
