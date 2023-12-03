using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_App_Simple.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Short description")]
        [Column(TypeName = "nvarchar(500)")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "description")]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }


        [Display(Name = "image")]
        [Column(TypeName = "varchar(250)")]
        public string? Image { get; set; }

        [Display(Name = "date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public category? category { get; set; }


    }
}
