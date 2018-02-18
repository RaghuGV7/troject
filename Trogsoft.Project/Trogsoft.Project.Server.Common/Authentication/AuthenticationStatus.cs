namespace Trogsoft.Project.Server.Common.Authentication
{
    public enum AuthenticationStatus
    {
        Success,
        UserNotFound,
        BadPassword,
        PasswordExpired,
        AccountDisabled,
        LockedOut
    }
}