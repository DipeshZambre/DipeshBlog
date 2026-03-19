using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="The Category Name is required")]
        [MaxLength(100,ErrorMessage ="Category Name cannot exceed 200 Characters")]
        public string Name { get; set; }


        public string? Description { get; set; }


        public ICollection<Post>? Posts { get; set; }
    }
}
