using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}