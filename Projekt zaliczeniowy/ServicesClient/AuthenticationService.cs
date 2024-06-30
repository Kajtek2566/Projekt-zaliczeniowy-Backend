using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Projekt_zaliczeniowy.ServicesClient
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly JwtService _jwtService;

        public AuthenticationService(HttpClient httpClient, JwtService jwtService)
        {
            _httpClient = httpClient;
            _jwtService = jwtService;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginData = new { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("authentication/login", content);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseData);

            _jwtService.SetToken(tokenResponse.Token);
            return true;
        }

        public void Logout()
        {
            _jwtService.RemoveToken();
        }

        public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(registerDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("authentication/register", content);
            return response.IsSuccessStatusCode;
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
