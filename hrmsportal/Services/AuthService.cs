using System.Net.Http.Json;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://fii.exchange-data.co.in/edihrapi/v0.01/api/Authenticate/Login";

    public AuthService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        var loginRequest = new LoginRequest
        {
            Username = username,
            Password = password
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, loginRequest);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return res;
        }
        catch (HttpRequestException e)
        {
            // Handle exception (e.g., network issues)
            return new LoginResponse { code = 400, message = e.Message , status = "Error" };
        }
    }
}