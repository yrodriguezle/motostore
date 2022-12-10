using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Motostore.Models;
using Motostore.Repositories;
using Motostore.Services;
using System.Net;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Motostore.Controllers
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public TokenModel()
        {
            Token = string.Empty;
            RefreshToken = string.Empty;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IRepository _repository;
        public AuthenticationController(IAuthenticationService authService, IRepository repository)
        {
            _authService = authService;
            _repository = repository;
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TokenModel refreshTokenModel)
        {
            try
            {
                ClaimsPrincipal principal = _authService.GetPrincipalFromExpiredToken(refreshTokenModel.Token);
                string username = principal.Identity.Name;

                User user = await _repository.User.GetByUsername(username);

                if (user is null || user.RememberToken == null || !user.RememberToken.Equals(refreshTokenModel.RefreshToken))
                {
                    return Unauthorized(new { message = "Si è verificato un errore caricando l'utente!" });
                }
                return new ObjectResult(new
                {
                    token = _authService.GenerateAccessToken(principal.Claims),
                    refreshToken = user.RememberToken,
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
