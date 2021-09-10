using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class UserProfileDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}