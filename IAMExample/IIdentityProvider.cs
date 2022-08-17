namespace IAMExample
{
    public interface IIdentityProvider
    {
        IUser? GetIdentity(int id, string accessToken);
    }
}