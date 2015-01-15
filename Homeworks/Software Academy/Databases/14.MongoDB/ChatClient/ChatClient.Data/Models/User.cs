namespace ChatClient.Data.Models
{
    public class User
    {
        public User (string name)
        {
            this.Username = name;
        }

        public string Username { get; set; }
    }
}
