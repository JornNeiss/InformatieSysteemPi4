
namespace InformatieSysteemPi4.Models
{

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            // Controleer of het product al in het winkelwagentje zit
            var existingItem = Items.FirstOrDefault(i => i.ProductID == product.ProductID);
            if (existingItem != null)
            {
                // Verhoog de hoeveelheid als het product al in het winkelwagentje zit
                existingItem.Quantity += quantity;
            }
            else
            {
                // Voeg een nieuw item toe als het product nog niet in het winkelwagentje zit
                var newItem = new CartItem
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                };
                Items.Add(newItem);
            }
        }
    }
}





