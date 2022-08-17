namespace IAMExample;

public class User : IUser
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Password { get; init; }
    public List<IAccount> Accounts { get; private set; } = new();
    public int Balance { get; private set; } = 0;

    public void AddAccount(IAccount account) => Accounts.Add(account);
    public bool DeleteAccount(IAccount account) => Accounts.Remove(account);

    public int AddCredit(int credit) => Balance += credit;


    public object FakeMethodThatThrowsArgumentNullException(object? arg) => arg ?? throw new ArgumentNullException(nameof(arg), "Argumento nulo");
}
