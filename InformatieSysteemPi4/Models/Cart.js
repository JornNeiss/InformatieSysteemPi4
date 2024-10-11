function addToCart(productId, quantity)
{
    $.ajax({
        type: "POST",
        url: "/Cart/AddToCart", // Zorg ervoor dat de URL correct is
        contentType: "application/json",
        data: JSON.stringify({ ProductID: productId, Quantity: quantity }),
        success: function (response) {
            // Success callback
            console.log("Product toegevoegd aan winkelwagentje:", response);
        },
        error: function (error) {
            // Error callback
            console.error("Fout bij het toevoegen aan het winkelwagentje:", error);
        }
    });
}