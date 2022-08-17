using FluentAssertions;
using IAMExample;
using System.Collections;

namespace LearningFluentAssertion;

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

        //Assert.Single(user.Accounts);
        user.Accounts.Should().ContainSingle();

        //Assert.Contains(account, user.Accounts);
        user.Accounts.Should().Contain(account);
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

        //Assert.Empty(user.Accounts);
        user.Accounts.Should().BeEmpty();

        //Assert.True(operationResult);
        operationResult.Should().BeTrue();
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

        //Assert.Single(user.Accounts);
        user.Accounts.Should().ContainSingle().Which.Should().Be(account1);

        //Assert.False(operationResult);
        operationResult.Should().BeFalse();
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
        
        //Assert.Equal(expectedFinalBalance, user.Balance);
        user.Balance.Should().Be(expectedFinalBalance);

        //Assert.Equal(expectedFinalBalance, finalBalance);
        finalBalance.Should().Be(expectedFinalBalance);
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

        //var exception = Assert.Throws<ArgumentNullException>(resultFunc);
        //Assert.Equal(expectedExceptionMessage, exception.Message);
        funcResult.Should().Throw<ArgumentNullException>().WithMessage(expectedExceptionMessage);
    }
}
