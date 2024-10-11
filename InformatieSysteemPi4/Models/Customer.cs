namespace InformatieSysteemPi4.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }          
        public string Name { get; set; }             
        public string Email { get; set; }           
        public string PhoneNumber { get; set; }    
        public int? LoyaltyPoints { get; set; }

        public ICollection<Order> Orders { get; set; }  // Correcte naam
        public ICollection<PreviousOrder> PreviousOrders { get; set; }  // Correcte naam
    }
}

