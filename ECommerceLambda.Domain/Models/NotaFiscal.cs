namespace ECommerceLambda.Domain.Models
{
    public class NotaFiscal
    {
        public string DocumentoCliente { get; set; }
        public string IdNotaFiscal { get; set; }
        public decimal BaseDeCalculo { get; set; }
        public decimal AliquotaTributo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTributo
        {
            get
            {
                return BaseDeCalculo * AliquotaTributo / 100;
            }
            private set
            {
                ValorTributo = value;
            }
        }
    }
}
