document.addEventListener("DOMContentLoaded", function () {
    displayCartItems();
    
    // Redirect to payment page when Buy Now is clicked
    document.getElementById("buy-now").addEventListener("click", function () {
        let cart = JSON.parse(localStorage.getItem("cart")) || [];
        if (cart.length === 0) {
            alert("Your cart is empty! Add some items first.");
            return;
        }
        window.location.href = "paymnt.html"; // Change this to your actual payment page
    });
});

function displayCartItems() {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    let container = document.getElementById("cart-container");
    let htmlContent = "";

    if (cart.length === 0) {
        container.innerHTML = "<h2 style='color:white; text-align:center; margin-left:33%'>OopS !! Your Cart is Empty!</h2>";
        document.getElementById("total-bill").innerText = "₹0.00"; // Reset bill if empty
        return;
    }

    cart.forEach((item, index) => {
        htmlContent += `
        <div class="imges">
         <i class="fa-solid fa-xmark cut-icon" onclick="removeProduct(${index})" style="cursor: pointer; color: red; float: right;"></i>  
            <img src="${item.image}" alt="${item.name}" loading="lazy">
            <div class="imgprop">
                <p class="img-description">${item.description}</p>
                <div><i class="fa-solid fa-indian-rupee-sign"></i> ${item.price * item.quantity}.00</div>
                <div>Quantity: <span id="quantity-${index}">${item.quantity}</span></div>
                <button class="btn-add" onclick="addToCart(${index})">Add</button>
                <button class="btn-add" onclick="removeFromCart(${index})">Rmv</button>
            </div>
        </div>
        `;
    });

    container.innerHTML = htmlContent;
    updateTotalBill(); // Update the total bill
}

function addToCart(index) {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    const product = cart[index];

    if (product) {
        product.quantity += 1;
    }

    localStorage.setItem("cart", JSON.stringify(cart));
    displayCartItems();
    updateCartCounter();
}

function removeFromCart(index) {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    
    if (cart[index].quantity > 1) {
        cart[index].quantity -= 1;
    } else {
        cart.splice(index, 1);
    }

    localStorage.setItem("cart", JSON.stringify(cart));
    displayCartItems();
}


function updateTotalBill() {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    let totalPrice = cart.reduce((sum, item) => sum + item.price * item.quantity, 0);

    document.getElementById("total-bill").innerText = `₹${totalPrice}.00`;
}

function removeProduct(index) {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    cart.splice(index, 1); // Remove the product directly
    localStorage.setItem("cart", JSON.stringify(cart));

    let scart = JSON.parse(localStorage.getItem("shoppingCart")) || [];
    cart.splice(index, 1); // Remove the product directly
    localStorage.setItem("shoppingCart", JSON.stringify(cart));
    displayCartItems();
}