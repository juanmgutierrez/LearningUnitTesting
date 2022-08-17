namespace IAMExample;

public class UsersRepository : IUsersRepository
{
    private readonly List<IUser> _users = new();

    public bool AddUser(IUser user)
    {
        if (user.Id <= 0 || string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Password))
            return false;

        if (_users.Any(u => u.Id == user.Id))
            return false;

        if (_users.Any(u => u.Name == user.Name))
            return false;

        _users.Add(user);
        return true;
    }

    public bool DeleteUser(IUser user) => _users.Remove(user);
    public IUser? Get(int id) => _users.Any(u => u.Id == id) ? _users.Single(u => u.Id == id) : null;
    public bool IsRightPassword(string name, string password) => _users.Any(u => u.Name == name && u.Password == password);
}
