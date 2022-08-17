namespace IAMExample;

public interface IUser
{
    List<IAccount> Accounts { get; }
    int Balance { get; }
    int Id { get; init; }
    string Name { get; init; }
    string Password { get; init; }

    void AddAccount(IAccount account);
    int AddCredit(int credit);
    bool DeleteAccount(IAccount account);
}