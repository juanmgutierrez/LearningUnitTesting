using IAMExample;
using Moq;

namespace LearningMoqTests;

public class IdentityProviderTests
{
    private readonly IdentityProvider _idP;
    private readonly Mock<IUsersRepository> _usersRepositoryMock = new();
    private readonly Mock<IAccessManager> _accessManagerMock = new();
    private readonly Mock<ILoggingService> _loggerMock = new();

    public IdentityProviderTests()
    {
        _idP = new IdentityProvider(_usersRepositoryMock.Object, _accessManagerMock.Object, _loggerMock.Object);
    }

    [Fact]
    public void GetIdentity_WithValidAccessTokenAndExistentUserId_ReturnsValidUser()
    {
        // Arrange
        int userId = 1;
        string accessToken = "AccesoOtorgado";
        User user = new() { Id = userId };
        _accessManagerMock.Setup(x => x.ValidateAccessToken(accessToken)).Returns(true);
        _usersRepositoryMock.Setup(x => x.Get(userId)).Returns(user);

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
        _accessManagerMock.Setup(x => x.ValidateAccessToken(It.IsAny<string>())).Returns(false);

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
        _accessManagerMock.Setup(x => x.ValidateAccessToken(accessToken)).Returns(true);
        _usersRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(() => null);

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
        _accessManagerMock.Setup(x => x.ValidateAccessToken(It.IsAny<string>())).Returns(false);

        // Act
        _ = _idP.GetIdentity(userId, accessToken);

        // Assert
        _loggerMock.Verify(x => x.LogInformation("Invalid AccessToken"), Times.Once);
        _loggerMock.Verify(x => x.LogInformation("Valid AccessToken"), Times.Never);
        _loggerMock.Verify(x => x.LogInformation(It.IsAny<string>()));
        _loggerMock.Verify(x => x.LogInformation(It.Is<string>(x => x.StartsWith("Invalid"))));
    }
}
