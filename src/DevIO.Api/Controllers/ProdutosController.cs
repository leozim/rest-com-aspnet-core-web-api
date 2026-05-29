using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : MainController
    {
        public ProdutosController(INotificador notificador) : base(notificador)
        {
        }
        //upload arquivo 7:02 minutos video private bool UploadArquivo
        // parei em 25 minutos
    }
}