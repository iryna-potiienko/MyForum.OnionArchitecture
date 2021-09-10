using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class SubjectDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
     
        [Required]
        public string QuestionText { get; set; }
        
        public DateTime CreatedAt { get; set; }
        [Required]
        public int ChapterId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}