using IAMExample;
using NSubstitute;

namespace LearningNSubstituteTests;

public class IdentityProviderTests
{
    private readonly IdentityProvider _idP;
    private readonly IUsersRepository _usersRepositoryMock = Substitute.For<IUsersRepository>();
    private readonly IAccessManager _accessManagerMock = Substitute.For<IAccessManager>();
    private readonly ILoggingService _loggerMock = Substitute.For<ILoggingService>();

    public IdentityProviderTests()
    {
        _idP = new IdentityProvider(_usersRepositoryMock, _accessManagerMock, _loggerMock);
    }

    [Fact]
    public void GetIdentity_WithValidAccessTokenAndExistentUserId_ReturnsValidUser()
    {
        // Arrange
        int userId = 1;
        string accessToken = "AccesoOtorgado";
        User user = new() { Id = userId };
        _accessManagerMock.ValidateAccessToken(accessToken).Returns(true);
        _usersRepositoryMock.Get(userId).Returns(user);

        // Act
        var identidad = _idP.GetIdentity(userId, accessToken);

        // Assert
        Assert.Equal(userId, identidad.Id);
        Assert.IsAssignableFrom<IUser>(identidad);
    }

    [Fact]
    public void GetIdentity_WithInvalidAccessToken_ReturnsNull()
    {
        // Arrange
        var userId = 1;
        var accessToken = "InvalidToken";
        _accessManagerMock.ValidateAccessToken(Arg.Any<string>()).Returns(false);

        // Act
        var identidad = _idP.GetIdentity(userId, accessToken);

        // Assert
        Assert.Null(identidad);
    }

    [Fact]
    public void GetIdentity_WithValidAccessTokenAndInexistentUserId_ReturnsNull()
    {
        // Arrange
        int userId = 1;
        string accessToken = "AccesoOtorgado";
        _accessManagerMock.ValidateAccessToken(accessToken).Returns(true);
        _usersRepositoryMock.Get(Arg.Any<int>()).Returns((IUser?)null);

        // Act
        var identidad = _idP.GetIdentity(userId, accessToken);

        // Assert
        Assert.Null(identidad);
    }

    [Fact]
    public void GetIdentity_WithInvalidAccessToken_LogsAccessError()
    {
        // Arrange
        int userId = 1;
        string accessToken = "AccesoInvalido";
        _accessManagerMock.ValidateAccessToken(Arg.Any<string>()).Returns(false);

        // Act
        _ = _idP.GetIdentity(userId, accessToken);

        // Assert
        _loggerMock.Received(1).LogInformation("Invalid AccessToken");
        _loggerMock.DidNotReceive().LogInformation("Valid AccessToken");
        _loggerMock.Received(1).LogInformation(Arg.Any<string>());
    }
}
