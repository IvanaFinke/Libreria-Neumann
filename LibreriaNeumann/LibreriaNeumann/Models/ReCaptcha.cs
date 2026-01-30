using System.Text.Json;

namespace LibreriaNeumann.Models
{
    public class ReCaptcha
    {

        private readonly HttpClient _httpClient;
        private readonly string _secret;

        public ReCaptcha(HttpClient httpClient,IConfiguration config)
        {
            _httpClient = httpClient;
            _secret = config["ReCaptcha:SecretKey"];
        }


        public async Task<bool> Validate(string token)
        {
            var response = await _httpClient.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={_secret}&response={token}", null);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ReCaptchaResponse>(json);

            return result.success;
        }
    }

    public class ReCaptchaResponse
    {
        public bool success { get; set; }
    }
}
