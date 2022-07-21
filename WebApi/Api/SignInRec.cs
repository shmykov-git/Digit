namespace WebApi.Api;

public class SignInRec
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string RepeatedPassword { get; set; }
    public bool IsAgreed { get; set; }
}