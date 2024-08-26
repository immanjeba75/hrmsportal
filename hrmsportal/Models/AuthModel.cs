public class LoginRequest
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}

public class LoginResponse
{
    public int? Code { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
    public LoginData? Data { get; set; }
}

public class LoginData
{
    public string? Token { get; set; }
    public DateTime? Expiration { get; set; }
    public string? UserName { get; set; }
    public string? UserId { get; set; }
    public string? UserEmail { get; set; }
    public string? FullName { get; set; }
    public string? RoleName { get; set; }

    public override string ToString() 
    { 
        return $"Token: {Token},\nExpiration: {Expiration},\nUserName: {UserName},\nUserId: {UserId},\nUserEmail: {UserEmail},\nFullName: {FullName},\nRoleName: {RoleName}";
    }
}

public class RegisterRequest
{
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public int? EmployeeId { get; set; } = 0;
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Gender { get; set; } = "";
    public int Branch { get; set; } = 0;

}

public class RegisterResponse
{
    public int Code { get; set; } = 0;
    public string? Status { get; set; }
    public string? Message { get; set; }
    public string? Data { get; set; } = null;
}