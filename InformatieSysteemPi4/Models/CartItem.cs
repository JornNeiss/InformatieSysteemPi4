namespace InformatieSysteemPi4.Models
{
    public class CartItem
    {
        
        
            public int CartItemID { get; set; } // Voeg een primaire sleutel toe
            public int ProductID { get; set; } // Dit blijft de foreign key

            // Navigatie-eigenschap
            public virtual Product Product { get; set; }

            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        
    }
}
