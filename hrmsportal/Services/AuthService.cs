using System.Net.Http.Json;
using hrmsportal.Utils;
using Microsoft.Extensions.Configuration;

public class AuthService
{
    private readonly HttpClient _httpClient;

    private readonly string LoginApiURL = string.Empty;
    private readonly string RegisterApiURL = string.Empty;

    public AuthService()
    {
        _httpClient = new HttpClient();
        LoginApiURL = HelperClass.GetAPIUrl("Login");
        RegisterApiURL = HelperClass.GetAPIUrl("Register");
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
            var response = await _httpClient.PostAsJsonAsync(LoginApiURL, loginRequest);
            response.EnsureSuccessStatusCode();
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return loginResponse ?? new LoginResponse { Code = 400, Message = "Login Failed", Status = "Error"};
        }
        catch (HttpRequestException e)
        {
            return new LoginResponse { Code = 400, Message = e.Message , Status = "Error"};
        }
    }
    public async Task<RegisterResponse> RegisterAsync(string username,string email, string password, int employeeId, string firstName, string lastName, string gender, int branch = 0)
    {
        var registerRequest = new RegisterRequest
        {
            Username = username,
            Email = email,
            Password = password,
            EmployeeId = employeeId,
            FirstName = firstName,
            LastName = lastName,
            Gender = gender,
            Branch = branch
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync(RegisterApiURL, registerRequest);
            response.EnsureSuccessStatusCode();
            var registerResponse = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            return registerResponse ?? new RegisterResponse { Code = 400, Message = "Register Failed", Status = "Error"};
        }
        catch (HttpRequestException e)
        {
            return new RegisterResponse { Code = 400, Message = e.Message , Status = "Error"};
        }
    }
}