using IAMExample;
using System.Collections;

namespace UsersExampleTests;

public class UserTests
{
    [Fact]
    public void AddAccount_WhenAddingOneAccount_AddsAccount()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var account = new Account(1);

        // Act
        user.AddAccount(account);

        // Assert
        Assert.Single(user.Accounts);
        Assert.Contains(account, user.Accounts);
    }

    [Fact]
    public void DeleteAccount_WhenDeletingExistingAccount_DeletesAccountAndReturnsTrue()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var account = new Account(1);
        user.AddAccount(account);

        // Act
        var operationResult = user.DeleteAccount(account);

        // Assert
        Assert.Empty(user.Accounts);
        Assert.True(operationResult);
    }

    [Fact]
    public void DeleteAccount_WhenDeletingNonExistingAccount_DoesntDeleteAndReturnsFalse()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var account1 = new Account(1);
        var account2 = new Account(2);
        user.AddAccount(account1);

        // Act
        var operationResult = user.DeleteAccount(account2);

        // Assert
        Assert.Single(user.Accounts);
        Assert.False(operationResult);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(5)]
    public void AddCredit_WhenAdding_UpdateAndReturnsRightBalance(int credit)
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var initialBalance = user.Balance;
        var expectedFinalBalance = initialBalance + credit;

        // Act
        var finalBalance = user.AddCredit(credit);

        // Assert
        Assert.Equal(expectedFinalBalance, user.Balance);
        Assert.Equal(expectedFinalBalance, finalBalance);
    }

    public static IEnumerable<object[]> TestCredits()
    {
        // This could be obtained from an xls for example
        yield return new object[] { 0 };
        yield return new object[] { -1 };
        yield return new object[] { 5 };
    }

    [Theory]
    [MemberData(nameof(TestCredits))]
    public void MemeberDataVariation__AddCredit_WhenAdding_UpdateAndReturnsRightBalance(int credit)
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var initialBalance = user.Balance;
        var expectedFinalBalance = initialBalance + credit;

        // Act
        var finalBalance = user.AddCredit(credit);

        // Assert
        Assert.Equal(expectedFinalBalance, user.Balance);
        Assert.Equal(expectedFinalBalance, finalBalance);
    }

    public class TestCreditsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0 };
            yield return new object[] { -1 };
            yield return new object[] { 5 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [Theory]
    [ClassData(typeof(TestCreditsData))]
    public void ClassDataVariation__AddCredit_WhenAdding_UpdateAndReturnsRightBalance(int credit)
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var initialBalance = user.Balance;
        var expectedFinalBalance = initialBalance + credit;

        // Act
        var finalBalance = user.AddCredit(credit);

        // Assert
        Assert.Equal(expectedFinalBalance, user.Balance);
        Assert.Equal(expectedFinalBalance, finalBalance);
    }

    [Fact(Skip = "Skip for testing skip")]
    public void WhenSkipAttribute_Skip()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        var account = new Account(1);

        // Act
        user.AddAccount(account);

        // Assert
        Assert.Single(user.Accounts);
    }

    [Fact]
    public void FakeMethodThatThrowsArgumentNullException_WithNullArg_ThrowsArgumentNullException()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Juan" };
        object? arg = null;
        string expectedExceptionMessage = "Argumento nulo (Parameter 'arg')";

        // Act
        Func<object> funcResult = () => user.FakeMethodThatThrowsArgumentNullException(arg);

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(funcResult);
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
}
