public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    // Add other properties as needed
    public int? code { get; set; }
    public string? status { get; set; }
    public string? message { get; set; }
    public dynamic? data { get; set; }
}