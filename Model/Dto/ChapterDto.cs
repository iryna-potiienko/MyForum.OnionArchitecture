using System.ComponentModel.DataAnnotations;

namespace Model.Dto
{
    public class ChapterDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}