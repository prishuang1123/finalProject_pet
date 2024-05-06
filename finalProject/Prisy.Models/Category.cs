using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prisy.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string categoryName { get; set; }
        [MaxLength(50)]
        [DisplayName("Category Description")]
        public string categoryDesc { get; set; }
        [Required]
        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Category()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
