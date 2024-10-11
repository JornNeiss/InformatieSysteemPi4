namespace InformatieSysteemPi4.Models
{
    public class Order
    {
        public int OrderID { get; set; } // Primaire sleutel
        public int CustomerID { get; set; } // Verwijzing naar de klant
        public string OrderNumber { get; set; } // Bestelnummer
        public decimal TotalAmount { get; set; } // Totaalbedrag van de bestelling
        public DateTime OrderDate { get; set; } // Datum van de bestelling
        public string OrderStatus { get; set; } // Status van de bestelling
        public bool IsPaid { get; set; } // Of de bestelling is betaald
        public DateTime? PickUpTime { get; set; } // Optionele ophaaltijd

        // Navigatie-eigenschappen
        public virtual Customer Customer { get; set; } // Navigatie naar klant
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Navigatie naar orderdetails

        public virtual Discount Discount { get; set; } // Navigatie naar korting
        public int? DiscountID { get; set; } // Optionele verwijzing naar korting
    }

}


