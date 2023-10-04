using alkemyUmsaFront.ViewModel;
using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace alkemyUmsaFront.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public UsuariosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [Authorize]
        public IActionResult Usuarios()
        {
            return View();
        }
        public async Task<IActionResult> UsuariosAddParcial([FromBody] UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            if (usuario != null)
            {
                usuariosViewModel = usuario;
            }

            return PartialView("~/Views/Usuarios/Parcial/UsuariosAddParcial.cshtml", usuariosViewModel);
        }
        public IActionResult GuardarUsuario(UsuarioDto usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PostToApi("Usuarios/Register", usuario, token);
            return View("~/Views/Usuarios/Usuarios.cshtml");
        }
    }
}
