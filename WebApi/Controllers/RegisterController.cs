using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<SignInRsp>> Post([FromBody] SignInRec signIn)
    {
        if (!IsValidEmail(signIn.Email))
            return BadRequest(new SignInRsp()
            {
                ErrorCode = ErrorCode.InvalidEmail, 
                Error = "Invalid email"
            });

        if (!IsValidPassword(signIn.Password))
            return BadRequest(new SignInRsp()
            {
                ErrorCode = ErrorCode.InvalidPassword,
                Error = "Incorrect password. Password should contain one at least one digit and one upper case letter"
            });

        if (signIn.Password != signIn.RepeatedPassword)
            return BadRequest(new SignInRsp()
            {
                ErrorCode = ErrorCode.PasswordsAreNotEquals,
                Error = "Incorrect password. Passwords are not equal"
            });

        if (!signIn.IsAgreed)
            return BadRequest(new SignInRsp()
            {
                ErrorCode = ErrorCode.NotAgreed,
                Error = "Agree to continue"
            });

        return Ok(default!);
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var m = new MailAddress(email);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private bool IsValidPassword(string password)
    {
        return new Regex(@"(?=.*\d)(?=.*[A-Z])").IsMatch(password);
    }
}