using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Data.Base
{
    public class BaseApi : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseApi"/>.
        /// </summary>
        /// <param name="httpClient">La instancia de IHttpClientFactory utilizada para las solicitudes HTTP.</param>
        public BaseApi(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Realiza una solicitud POST a un controlador API especificado.
        /// </summary>
        /// <param name="controllerName">El nombre del controlador API al que se dirige.</param>
        /// <param name="model">El cuerpo de la solicitud POST.</param>
        /// <param name="token">Token de autenticación opcional para la solicitud (por defecto es "").</param>
        /// <returns>Devuelve un IActionResult basado en el éxito o fallo de la solicitud.</returns>
        public async Task<IActionResult> PostToApi(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }

                var response = await client.PostAsJsonAsync(controllerName, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        /// <summary>
        /// Realiza una solicitud PUT a un controlador API especificado.
        /// </summary>
        /// <param name="controllerName">El nombre del controlador API al que se dirige.</param>
        /// <param name="model">El cuerpo de la solicitud PUT.</param>
        /// <param name="token">Token de autenticación opcional para la solicitud (por defecto es "").</param>
        /// <returns>Devuelve un IActionResult basado en el éxito o fallo de la solicitud.</returns>
        public async Task<IActionResult> PutToApi(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }

                var response = await client.PutAsJsonAsync(controllerName, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}