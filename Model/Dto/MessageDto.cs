using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class MessageDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Cannot be empty")]
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public int UserId { get; set; }
        [Required]
        public int SubjectId { get; set; }

        public string UserName { get; set; }
    }
}