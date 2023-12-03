using System.ComponentModel.DataAnnotations;

namespace Blog_App_Simple.Models
{
    public class category
    {
        [Key]
        public int categoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
