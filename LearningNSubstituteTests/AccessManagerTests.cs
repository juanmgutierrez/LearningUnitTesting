using IAMExample;
using NSubstitute;

namespace LearningNSubstituteTests;

public class AccessManagerTests
{
    private readonly AccessManager _accessManager;
    private readonly IUsersRepository _usersRepositoryMock = Substitute.For<IUsersRepository>();

    public AccessManagerTests()
    {
        _accessManager = new AccessManager(_usersRepositoryMock);
    }

    [Fact]
    public void GetAccessToken_WhenValidNameAndPasswordPassed_ReturnsAccessToken()
    {
        // Arrange
        string username = "Juan";
        string password = "strongPassword123";
        string validTokenString = "AccesoOtorgado";
        _usersRepositoryMock.IsRightPassword(username, password).Returns(true);

        // Act
        var accessToken = _accessManager.GetAccessToken(username, password);

        // Assert
        Assert.Equal(validTokenString, accessToken);
    }

    [Fact]
    public void GetAccessToken_WhenInvalidNameAndPasswordPassed_ReturnsNull()
    {
        // Arrange
        string username = "Juan";
        string password = "strongPassword123";
        _usersRepositoryMock.IsRightPassword(username, password).Returns(false);

        // Act
        var accessToken = _accessManager.GetAccessToken(username, password);

        // Assert
        Assert.Null(accessToken);
    }
}