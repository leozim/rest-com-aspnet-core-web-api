using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/[Controller]")]
    public class AuthController : MainController
    {
        public AuthController(INotificador notificador) : base(notificador)
        {
        }
    }
}