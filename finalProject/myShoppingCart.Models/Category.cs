using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myShoppingCart.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string categoryName { get; set; }
        [MaxLength(500)]
        [DisplayName("Category Description")]
        public string categoryDesc { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        public DateTime? modifiedAt { get; set; }

        public Category()
        {
            this.createdAt = DateTime.UtcNow;
            
        }
    }
}
