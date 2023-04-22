using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}

