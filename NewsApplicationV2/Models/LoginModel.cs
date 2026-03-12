namespace NewsApplicationV2.Models
{
    public class LoginModel
    {
      
        
            public required string Username { get; set; }
            public required string Password { get; set; }
            public string? ReturnUrl { get; set; } = "/";
        }
}
