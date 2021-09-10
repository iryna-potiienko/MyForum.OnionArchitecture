using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Model.Model
{
    public class UserProfile: IdentityUser
    {
        public UserProfile()
        {
            Subjects = new List<Subject>();
            Messages = new List<Message>();
        }
        
        public string Role { get; set; }
        
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}