namespace IAMExample;

public interface IAccessManager
{
    string GetAccessToken(string username, string password);
    bool ValidateAccessToken(string accessToken);
}
