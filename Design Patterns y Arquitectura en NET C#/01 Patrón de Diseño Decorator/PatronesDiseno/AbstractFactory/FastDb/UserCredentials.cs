namespace AbstractFactory.FastDb
{
    public class UserCredentials : Credentials
    {
        public string? UserName { get; }
        public string? Password { get; }

        public UserCredentials(string? userName, string? password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
