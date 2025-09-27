using System.ComponentModel.DataAnnotations;

namespace Lesson2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        
        public string Description { get; set; }
        
        [Range(0, 10000)]
        public decimal Price { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}