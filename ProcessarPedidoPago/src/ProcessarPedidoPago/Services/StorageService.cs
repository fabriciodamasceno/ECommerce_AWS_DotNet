﻿using Amazon.S3;
using Amazon.S3.Model;
using ECommerceLambda.Domain.Models;
using System.Text;
using System.Text.Json;

namespace ProcessarPedidoPago.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 client;

        public StorageService(IAmazonS3 client)
        {
            this.client = client;
        }
        public async Task SalvarNotaFiscal(NotaFiscal notaFiscal)
        {
            var prefixo = $"{notaFiscal.DocumentoCliente}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";
            var key = $"{prefixo}/{Guid.NewGuid()}.json";

            var putObjectRequest = new PutObjectRequest
            {
                BucketName = "nf-emitidas-bucket",
                Key = key,
                ContentType = "application/json",
                InputStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(notaFiscal)))
            };

            await client.PutObjectAsync(putObjectRequest);   
        }
    }
}
