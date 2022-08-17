using IAMExample;
using Moq;

namespace LearningMoqTests;

public class AccessManagerTests
{
    private readonly AccessManager _accessManager;
    private readonly Mock<IUsersRepository> _usersRepositoryMock = new();

    public AccessManagerTests()
    {
        _accessManager = new AccessManager(_usersRepositoryMock.Object);
    }

    [Fact]
    public void GetAccessToken_WhenValidNameAndPasswordPassed_ReturnsAccessToken()
    {
        // Arrange
        string username = "Juan";
        string password = "strongPassword123";
        string validTokenString = "AccesoOtorgado";
        _usersRepositoryMock.Setup(x => x.IsRightPassword(username, password)).Returns(true);

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
        _usersRepositoryMock.Setup(x => x.IsRightPassword(username, password)).Returns(false);

        // Act
        var accessToken = _accessManager.GetAccessToken(username, password);

        // Assert
        Assert.Null(accessToken);
    }
}
