using Microsoft.AspNetCore.Mvc;

namespace InformatieSysteemPi4.Models
{
    public class AddToCartRequest
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
