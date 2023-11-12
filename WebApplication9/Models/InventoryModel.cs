using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class InventoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "The field must be at least 100 characters long.")]
        public string Name { get; set; }
        public int? CategoryId { get; set; } //foreignKey
        public CategoryModel? Category { get; } 
    }
}
