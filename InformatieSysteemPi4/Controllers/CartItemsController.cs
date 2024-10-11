using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InformatieSysteemPi4.Database;
using InformatieSysteemPi4.Models;
using InformatieSysteemPi4.Models.Extensions;

public class CartController : Controller
{
    private readonly FrietzaakDbContext _context;

    public CartController(FrietzaakDbContext context)
    {
        _context = context;
    }

    // GET: /Cart
    public IActionResult Index()
    {
        var cart = GetCart();
        return View(cart); // Zorg ervoor dat je een view hebt voor het weergeven van het winkelwagentje
    }

    [HttpPost]
    public IActionResult AddToCart([FromBody] AddToCartRequest request)
    {
        // Haal het product op van de database
        var product = _context.Products.Find(request.ProductID);

        if (product == null)
        {
            return NotFound();
        }

        // Haal de huidige winkelwagentje op
        var cart = GetCart();

        // Voeg het product toe aan het winkelwagentje
        cart.AddItem(product, request.Quantity);

        // Sla de winkelwagentje op in de sessie
        HttpContext.Session.SetObjectAsJson("Cart", cart);

        // Voeg de items toe aan de CartItems-tabel
        foreach (var item in cart.Items)
        {
            var cartItem = new CartItem
            {
                ProductID = item.ProductID,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };

            _context.CartItems.Add(cartItem);
        }

        // Sla de wijzigingen op in de database
        _context.SaveChanges();

        return Ok();
    }

    private Cart GetCart()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
        return cart;
    }
}