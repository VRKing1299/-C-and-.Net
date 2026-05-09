function PlaceOrder() {
    let cart = GetCartItems();
    let user = JSON.parse(localStorage.getItem("User"));
    let total = JSON.parse(localStorage.getItem("total"));
    //validating if product quantity is enough or not
    let isValid = true;
    for (let item of cart) {
        let prod = GetProduct(item.ProdId);

        if (prod.StockQuantity < item.Quantity) {
            alert(
                `Only ${prod.StockQuantity} units of ${prod.ProdName} are available for now`,
            );
            isValid = false;
            break;
        }
    }

    if (!isValid) return;

    //creating object to send it to server
    let orderItems = cart.map((item) => {
        return {
            ProdId: item.ProdId,
            Quantity: item.Quantity,
            PriceAtPurchase: item.Price,
        };
    });

    let order = {
        UserId: user.UserId,
        TotalAmount: total,
        OrderItems: orderItems,
    };

    $.ajax({
        url: orderApi,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(order),

        success: (response) => {
            localStorage.removeItem("total");
            if (0 == response) {
                alert("failed to place order");
            } else {
                localStorage.setItem("orderId", response);
                window.location.href = "MYOrders.html";
            }
        },

        error: (err) => {
            console.log(err);
        },
    });
}

let total = JSON.parse(localStorage.getItem("total"));
$(".total").text(`Total: ₹${total}`);

$("#paymentForm").on("submit", (e) => {
    e.preventDefault();
    PlaceOrder();
});
