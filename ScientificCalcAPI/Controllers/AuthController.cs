using Microsoft.AspNetCore.Mvc;
using ScientificCalcApi.Application.Applications;
using ScientificCalcApi.Application.Services;

namespace ScientificCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        private readonly LoginApplication _loginApplication;
        private readonly TokenService _tokenService;

        //implementando ainda
    }
}
