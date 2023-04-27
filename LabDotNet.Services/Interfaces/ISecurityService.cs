namespace LabDotNet.Services.Interfaces
{
    public interface ISecurityService
    {
        string GenerateJwtToken(long userId, string userEmail);
        Guid ValidateJwtToken(string token);
        string Hash(string text);
        string HashSha256(string value);
    }
}