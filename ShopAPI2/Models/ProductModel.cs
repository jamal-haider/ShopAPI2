using System.ComponentModel.DataAnnotations;

namespace ShopAPI2.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
