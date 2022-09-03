using FluentAssertions;
using IAMExample;
using Moq;

namespace LearningFluentAssertion;

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
        User user = new() { Id = userId, Name = "Juan M" };
        _accessManagerMock.Setup(x => x.ValidateAccessToken(accessToken)).Returns(true);
        _usersRepositoryMock.Setup(x => x.Get(userId)).Returns(user);

        // Act
        var identidad = _idP.GetIdentity(userId, accessToken);


        // Assert

        //Assert.Equal(userId, identidad.Id);
        identidad.Id.Should().Be(userId);
        identidad.Name.Should().StartWith("Juan");

        //Assert.IsAssignableFrom<IUser>(identidad);
        identidad.Should().BeAssignableTo<IUser>();
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

        //Assert.Null(identidad);
        identidad.Should().BeNull();
    }
}
