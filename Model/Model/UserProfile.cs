using System.Collections.Generic;

namespace MyForum.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            Subjects = new List<Subject>();
            Messages = new List<Message>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}