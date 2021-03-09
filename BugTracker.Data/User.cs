using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class User
    {
            [Key]
            public int UserId { get; set; }

            [Required]
            public Guid OwnerId { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string ConfirmPassword { get; set; }

            public string grant_type { get; set; }

            public string Token { get; set; }

            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }

            public User() { }

            public User(string username, string password, string email, string confirmPassword)
            {
                Email = email;
                Username = username;
                Password = password;
                ConfirmPassword = confirmPassword;
            }
        public User(string username, string password, string token, string email, string confirmPassword)
            {
                Email = email;
                Username = username;
                Password = password;
                ConfirmPassword = confirmPassword;
                Token = token;
            }
    }
}
