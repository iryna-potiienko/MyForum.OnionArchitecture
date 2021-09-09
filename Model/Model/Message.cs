using System;
using System.ComponentModel.DataAnnotations;

//using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Message
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Cannot be empty")]
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public int UserId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }
        public virtual Subject Subject { get; set; }
    }
}