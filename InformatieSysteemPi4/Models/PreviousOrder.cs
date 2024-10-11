namespace InformatieSysteemPi4.Models
{
    public class PreviousOrder
    {
        public int PreviousOrderID { get; set; }     
        public int CustomerID { get; set; }          
        public int OrderID { get; set; }             
        public bool IsRepeatable { get; set; }       

        public Customer Customer { get; set; }      
        public Order Order { get; set; }

        
        
    }
}
