namespace InformatieSysteemPi4.Models
{
    public class Discount
    {
        public int DiscountID { get; set; }         
        public int ProductID { get; set; }           
        public decimal DiscountPercentage { get; set; } 
        public DateTime StartDate { get; set; }      
        public DateTime EndDate { get; set; }        

        public Product Product { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
