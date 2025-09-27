using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lesson2.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int BookId { get; set; }
    
    [Range(1, 100)]
    public int Quantity { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public DateTime OrderDate { get; set; } = DateTime.Now;
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    [ForeignKey("BookId")]
    public Book Book { get; set; }
    
    
}