/* using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [MaxLength(400, ErrorMessage = "The Title cannot exceed 200 characters")]
        public string Title { get; set; }



        [Required(ErrorMessage = "The Content is Required")]
        public string Content { get; set; }



        [Required(ErrorMessage = "The Author is Required")]
        [MaxLength(100, ErrorMessage = "The Name cannot exceed 100 characters")]

        public string Author { get; set; }


        [ValidateNever]
        public string FeatureImagePath { get; set; }



        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Navigation Property

        [ValidateNever]
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set;}
    }
}
*/

using Blog.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "The title is required.")]
    [MaxLength(200, ErrorMessage = "The title cannot exceed 200 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }

    [MaxLength(100, ErrorMessage = "Author's name cannot exceed 100 characters.")]
    public string Author { get; set; }

    [ValidateNever]
    public string FeatureImagePath { get; set; }

    [DataType(DataType.Date)]
    public DateTime PublishedDate { get; set; } = DateTime.Now;

    
    [ForeignKey("Category")]
    [DisplayName("Category")]
    public int CategoryId { get; set; }
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}
