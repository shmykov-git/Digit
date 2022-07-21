namespace WebApi.Api;

public enum ErrorCode
{
    None = 0,

    InvalidEmail = 1,
    InvalidPassword = 2,
    PasswordsAreNotEquals = 3,
    NotAgreed = 4,

    RegionIsNotEntered = 5,
}