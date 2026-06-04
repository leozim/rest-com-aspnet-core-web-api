namespace DevIO.Api.Extensions
{
    public class AppSettings
    {
        // chave de criptografia
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        // minha api
        public string Emissor { get; set; }
        // localhost/...
        public string Audiencia { get; set; }
    }
}