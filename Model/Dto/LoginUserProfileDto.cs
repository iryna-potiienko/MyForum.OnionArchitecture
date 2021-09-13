using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class LoginUserProfileDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}