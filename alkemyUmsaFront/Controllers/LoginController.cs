using alkemyUmsaFront.ViewModel;
using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;

namespace alkemyUmsaFront.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory httpClient) {

            _httpClient = httpClient;
        }    
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Ingresar(LoginDto dto)
        {
            var baseApi = new BaseApi(_httpClient);
            var token = await baseApi.PostToApi("Login", dto);
            var resultadoLogin = token as OkObjectResult;
            if (resultadoLogin != null){
                var entireResponse = JsonConvert.DeserializeObject<ResponseWrapper>(resultadoLogin.Value.ToString());
                var resultadoObjeto = entireResponse?.data;

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                Claim claimNombre = new(ClaimTypes.Name, resultadoObjeto.Nombre);
                Claim claimRole = new(ClaimTypes.Role, "administrador");
                Claim claimEmail = new(ClaimTypes.Email, resultadoObjeto.Email);

                identity.AddClaim(claimNombre);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimEmail);

                var claimPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(1),
                });

                HttpContext.Session.SetString("Token", resultadoObjeto.Token);

                var homeViewModel = new HomeViewModel();
                homeViewModel.Nombre = resultadoObjeto.Nombre;
                homeViewModel.Token = resultadoObjeto.Token;

                return View("~/Views/Home/Index.cshtml", homeViewModel);
            }
            return BadRequest();
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("https://localhost:7241");
        }
    }

}
