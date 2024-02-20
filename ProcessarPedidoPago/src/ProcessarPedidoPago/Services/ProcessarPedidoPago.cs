using ECommerceLambda.Domain.Models;

namespace ProcessarPedidoPago.Services
{
    public class ProcessarPedidoPago : IProcessarPedidoPago
    {
        private readonly IStorageService storage;

        public ProcessarPedidoPago(IStorageService storage)
        {
            this.storage = storage;
        }
        public async Task Processar(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal
            {
                DocumentoCliente = pedido.DocumentoCliente,
                IdNotaFiscal = Guid.NewGuid().ToString(),
                BaseDeCalculo = pedido.ValorTotal,
                AliquotaTributo = 20,
                Descricao = $"Nota Fiscal relativa ao pedido {pedido.PedidoId}"
            };

            await this.storage.SalvarNotaFiscal(notaFiscal);
        }
    }
}
