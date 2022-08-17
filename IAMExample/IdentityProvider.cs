namespace IAMExample;

public class IdentityProvider : IIdentityProvider
{
    private readonly IUsersRepository _usersRepository;
    private readonly IAccessManager _accessManager;
    private readonly ILoggingService _logger;

    public IdentityProvider(IUsersRepository usersRepository, IAccessManager accessManager, ILoggingService logger)
    {
        _usersRepository = usersRepository;
        _accessManager = accessManager;
        _logger = logger;
    }

    public IUser? GetIdentity(int id, string accessToken)
    {
        if (_accessManager.ValidateAccessToken(accessToken))
        {
            return _usersRepository.Get(id);
        }

        _logger.LogInformation($"Invalid AccessToken");
        return null;
    }
}
