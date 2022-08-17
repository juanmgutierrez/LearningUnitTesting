namespace IAMExample;

public interface IUsersRepository
{
    bool AddUser(IUser user);
    bool DeleteUser(IUser user);
    IUser? Get(int id);
    bool IsRightPassword(string name, string password);
}