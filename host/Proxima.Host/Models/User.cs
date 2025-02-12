namespace Proxima.Host.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        // NOTE: In a real app you would store a hashed password.
        public string Password { get; set; } = null!;
    }
}
