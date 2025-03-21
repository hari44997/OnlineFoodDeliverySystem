namespace OnlineFoodDeliverySystem.Repository
{
    public interface IAuthentication
    {
        string Authenticate(string email, string password);
    }
}