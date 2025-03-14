namespace OnlineFoodDeliverySystem.Repository
{
    public interface IAuthentication
    {
        string Authenticate(string Email, string password);
    }
}
