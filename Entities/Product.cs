using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementBlazorApp.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public string Id { get; set; } = "";

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [MaxLength(500)]
        public string Description { get; set; } = "";

        [MaxLength(50)]
        public string Category { get; set; } = "";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        [MaxLength(200)]
        public string Image { get; set; } = "";
    }
}
