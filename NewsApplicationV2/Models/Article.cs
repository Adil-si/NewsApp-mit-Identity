using Microsoft.AspNetCore.Identity;

namespace NewsApplicationV2.Models
{
    public class Article
    {
        public int id { get; set; }
        public required string Headline { get; set; }

        public required string Content { get; set; } 


        public DateTime CreatedAt { get; set; }

        public required string CreatedById { get; set; }

        public AppUser? CreatedBy { get; set; }

        


    }
}
