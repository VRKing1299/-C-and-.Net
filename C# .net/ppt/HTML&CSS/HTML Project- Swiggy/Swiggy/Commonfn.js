function addToCart(index,prodFoods) {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    const product = prodFoods[index];
    const existingProductIndex = cart.findIndex(item => item.id === product.id); // Check if product already exists in cart

    if (existingProductIndex > -1) {
        // Product already exists, increase quantity
        cart[existingProductIndex].quantity += 1;
    } else {
        // Product does not exist, add it to the cart with quantity 1
        const productToAdd = { ...product, quantity: 1 }; // Create a new object with quantity
        cart.push(productToAdd);
    }

    localStorage.setItem("cart", JSON.stringify(cart));
    updateCartCounter();
    refreshCartIndicator();
}

function updateCartCounter() {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    const totalItems = cart.reduce((total, item) => total + (item.quantity || 1), 0); // Calculate total items
    document.querySelector(".fa-cart-plus").setAttribute("data-count", totalItems);
}

function refreshCartIndicator() {
    let cartData = JSON.parse(localStorage.getItem("cart")) || [];
    let cartIcon = document.querySelector(".fa-cart-plus");

    // Remove existing indicator
    let existingBadge = document.querySelector(".cart-badge");
    if (existingBadge) {
        existingBadge.remove();
    }

    // Display count if items exist in cart
    if (cartData.length > 0) {
        let badge = document.createElement("span");
        badge.classList.add("cart-badge");
        badge.textContent = cartData.length;
        cartIcon.parentElement.appendChild(badge);
    }
}