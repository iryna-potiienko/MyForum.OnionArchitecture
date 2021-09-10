using System;
using System.ComponentModel.DataAnnotations;

//using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Message
    {
        public int Id { get; set; }
        
        [Required]
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string UserName { get; set; }
        [Required]
        public int SubjectId { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }
        public virtual Subject Subject { get; set; }
    }
}