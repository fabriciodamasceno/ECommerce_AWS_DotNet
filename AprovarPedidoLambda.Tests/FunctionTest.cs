using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.TestUtilities;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace AprovarPedidoLambda.Tests
{
    public class FunctionTest
    {       

        [Fact]
        public async void Deve_salvar_um_pedido_com_sucesso()
        {
            var pedido = new Pedido
            {
                Cliente = new Cliente 
                {
                    Nome = "Fabrício",
                    Documento = "12345678901",
                    Email = "fabricio@damasceno.dev",
                    Endereco = new Endereco 
                    {
                        Cidade = "São Gonçalo",
                        Estado = "RJ",
                        Logradouro = "Rua ABC",
                        Numero = 123,
                        Complemento = "Sobrado"
                    },
                },
                PedidoId = Guid.NewGuid(),
                StatusPedido = StatusPedidoEnum.AGUARDANDO_PAGAMENTO,
                ItensPedido = new List<ItemPedido> 
                { 
                    new ItemPedido 
                    {
                        ProdutoId = 1,
                        Quantidade = 2,
                        ValorUnitario = 100,
                    } 
                }

            };

            var input = new SQSEvent
            {
                Records = new List<SQSEvent.SQSMessage>
                {
                    new SQSEvent.SQSMessage
                    {
                        Body = JsonSerializer.Serialize(pedido)
                    }
                }
            };

            var context = new TestLambdaContext()
            {
                Logger = new TestLambdaLogger()
            };

            var function = new Function();
            await function.FunctionHandler(input, context);

            //assert
        }
    }
}