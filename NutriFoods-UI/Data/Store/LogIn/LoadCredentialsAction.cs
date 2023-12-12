namespace NutriFoods_UI.Data.Store.LogIn;

public class LoadCredentialsAction(string email, string password)
{
    public string Email { get; } = email;
    public string Password { get; } = password;
}