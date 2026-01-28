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
    }
}