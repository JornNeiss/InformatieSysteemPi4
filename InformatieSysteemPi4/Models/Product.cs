using System.ComponentModel.DataAnnotations.Schema;

namespace InformatieSysteemPi4.Models
{
    public class Product
    {
        public int ProductID { get; set; }           
        public string ?Name { get; set; }             
        public string ?ImageURL { get; set; }         
        public bool IsOnSale { get; set; }                 
        public string ?Category { get; set; }        
        public bool IsAvailable { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Hiermee wordt de precisie en schaal ingesteld
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        public ICollection<OrderDetail> ?OrderDetails { get; set; } 
    }
}

