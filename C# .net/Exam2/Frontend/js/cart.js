function DisplayCartItems(data) {
    let html = "";
    let total = 0;

    if (!data || data.length === 0) {
        html = "<h3>Your cart is empty</h3>";
        $(".cart-container").html(html);
        $("#totalAmount").text("Total: ₹0");
        return;
    }

    data.forEach((item) => {
        let totalPrice = item.Price * item.Quantity;
        total += item.TotalPrice;

        html += `
        <div class="product-card">
            <img src="${item.ImageUrl}" alt="${item.ProdName}">
            
            <h3>${item.ProdName}</h3>
            <p>Price: ₹${item.Price}</p>
            <p>Quantity: ${item.Quantity}</p>
            <p>Total: ₹${totalPrice}</p>

            <button onclick="IncreaseQty(${item.CartItemId}, ${item.Quantity}, ${item.ProdId})">+</button>
            <button onclick="DecreaseQty(${item.CartItemId}, ${item.Quantity})">-</button>
        </div>
        `;
    });

    $(".cart-container").html(html);
    $("#totalAmount").text("Total: ₹" + total);
    localStorage.setItem("total", JSON.stringify(total));
}

DisplayCartItems(GetCartItems());

//*function to incerese the quantity
function IncreaseQty(cartId, quantity, prodId) {
    let updatedItem = {
        CartItemId: cartId,
        Quantity: quantity + 1,
    };

    //fetching product to check quantity
    let prod = GetProduct(prodId);
    if (!prod) {
        alert("Error fetching product");
        return;
    }
    if (prod.StockQuantity < updatedItem.Quantity) {
        alert("Not enough stock available!");
        return;
    }

    $.ajax({
        url: cartApi,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(updatedItem),
        success: (res) => {
            console.log(res);
            DisplayCartItems(GetCartItems());
        },
        error: (err) => {
            console.log(err);
        },
    });
}

//function to decrease the quantity
function DecreaseQty(cartId, quantity) {
    let updatedItem = {
        CartItemId: cartId,
        Quantity: quantity - 1,
    };

    if (updatedItem.Quantity == 0) {
        $.ajax({
            url: `${cartApi}?cartItemId=${cartId}`,
            type: "DELETE",

            success: (res) => {
                console.log(res);
                DisplayCartItems(GetCartItems());
            },
            error: (err) => {
                console.log(err);
            },
        });
    } else {
        $.ajax({
            url: cartApi,
            type: "PUT",
            contentType: "application/json",
            data: JSON.stringify(updatedItem),
            success: (res) => {
                console.log(res);
                DisplayCartItems(GetCartItems());
            },
            error: (err) => {
                console.log(err);
            },
        });
    }
}

$(".pay").on("click", () => {
    let cart = GetCartItems();
    if (cart.length <= 0) {
        alert("please atLeast add one product to cart");
        return;
    } else {
        window.location.href = "Pay.html";
    }
});
