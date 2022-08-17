namespace IAMExample;

public class AccessManager : IAccessManager
{
    private readonly IUsersRepository _usersRepository;

    public AccessManager(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public string GetAccessToken(string username, string password) => _usersRepository.IsRightPassword(username, password) ? "AccesoOtorgado" : null;

    public bool ValidateAccessToken(string accessToken) => accessToken == "AccesoOtorgado";
}
