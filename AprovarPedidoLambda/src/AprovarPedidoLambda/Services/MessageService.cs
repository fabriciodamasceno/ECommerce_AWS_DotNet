using Amazon.SQS;
using Amazon.SQS.Model;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace AprovarPedidoLambda.Services
{
    public class MessageService : IMessageService
    {
        private readonly IAmazonSQS sqsCliente;

        public MessageService(IAmazonSQS sqsCliente)
        {
            this.sqsCliente = sqsCliente;
        }
        public async Task SendMessage(Pedido pedido)
        {
            var request = new SendMessageRequest
            {
                MessageBody = JsonSerializer.Serialize(pedido),
                QueueUrl = "https://sqs.sa-east-1.amazonaws.com/619425175946/pedido-pago-sqs"
            };

            await this.sqsCliente.SendMessageAsync(request);
        }
    }
}
