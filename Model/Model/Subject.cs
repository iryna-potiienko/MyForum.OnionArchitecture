using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.Model;

//using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Subject
    {
        public Subject()
        {
            Messages = new List<Message>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Display(Name = "Text of your question")]
        [Required]
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public int ChapterId { get; set; }
        public int UserId { get; set; }
        
        public virtual Chapter Chapter { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}