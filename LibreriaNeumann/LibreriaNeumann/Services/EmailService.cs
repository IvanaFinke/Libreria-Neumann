using LibreriaNeumann.Models;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace LibreriaNeumann.Services
{
    public class EmailService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public EmailService(HttpClient http, IConfiguration config) //recibe una petision http y su clave
        {
           _http = http;
            _apiKey = config["Resend:ApiToken"]!;
        }

        public async Task<bool> EnviarResetPassword(string emailDestino, string link)
        {
            //nuevo objeto con los datos para la API Resend
            var body = new
            {
                from = "Libreria Neumann <onboarding@resend.dev>",
                to = new[] { emailDestino },
                subject = "Reseteo de contraseña",
                html = $"""
                <h2>¿Olvidaste tu contraseña?</h2>
                <p>Hace click en el siguiente enlace para resetear tu contraseña:</p>
                <a href="{link}">Resetear contraseña</a>
                <p>Este enlace expirará en 1 hora.</p>
                <p>Si no solicitaste un reseteo de contraseña, ignora este correo.</p>
                """
            };

            //nueva peticion http con el metodo post para enviar los datos a la API de Resend de la url
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.resend.com/emails");

            //setea la autorizacion con el token de la api para saber que usuario esta haciendo la petision y el contenido de la petision en formato json
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            //convertimos el objeto body a json para enviarlo en la peticion ya que las APIs HTTP suelen recibir datos en formato JSON
            request.Content = new StringContent(
                JsonSerializer.Serialize(body), //string serializado del objeto body
                Encoding.UTF8, //codifica caracteres especiales
                "application/json" //tipo de medio para usar el contenido de la peticion
                );

            var response = await _http.SendAsync(request); //enviamos peticion y guardamos la respuesta en response
            return response.IsSuccessStatusCode; //devuelve true si el codigo respuesta esta entre 200-299
        }

        public async Task<bool> EnviarConsulta(string mail, string consulta)
        {
            //nuevo objeto para el cuerpo de la consulta
            var mailsistema = "onboarding@resend.dev";

            var body = new
            {
                from = $"{mail} <onboarding@resend.dev>", //aca deberia de ser el mail del dominio de la empresa, pero buenoxd 
                to = new[] {mailsistema},
                subject = "Consulta del usuario",
                html = $"""<p>{consulta}</p>""",
            };
            //preparar request
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.resend.com/emails");

            //asignar autenticacion de apikey
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            //transformar a texto
            request.Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json");

            var response = await _http.SendAsync(request);
            return response.IsSuccessStatusCode;

        }
       
    }
}
