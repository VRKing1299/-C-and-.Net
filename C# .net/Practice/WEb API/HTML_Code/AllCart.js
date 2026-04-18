$(document).ready(function () {
    // Retrieve userId from sessionStorage
    const userId = sessionStorage.getItem('userid'); // Ensure the key matches how it's stored
    
    if (!userId) {
        alert('User not logged in ');
        window.location.href = './Login.html'; // Redirect to login page
        return; // Exit if userId is not set
    }

    function loadCart() {
       
        $.ajax({
            type: "GET",
            url: `http://localhost:60939/api/Cart/GetCartByUserID/${userId}`,
            success: function (cartItems) {
                console.log(cartItems)
                const CartContainer = $('#cart-container');
                const payNowButton = $('#btnPaynow');
                CartContainer.empty();
                
                if (cartItems.length === 0) {
                    payNowButton.hide();
                    CartContainer.html('<p class="empty-cart-message">Your Cart is empty.</p>');
                    $('#total-container').hide();
                    return;
                } else {
                    payNowButton.show();
                }
                
                let cartHTML = '';
                let pendingRequests = cartItems.length;
                
                cartItems.forEach(item => {
                    $.ajax({
                        type: "GET",
                        url: `http://localhost:60939/api/Product/ProductID/${item.ProdID}`,
                    
                        success: function (product) {
                            console.log(product);
                            
                            const itemPrice = product.ProdPrice;
                            const itemTotal = itemPrice * item.CartQty;

                            cartHTML += `
                                <div class="cart-item2" data-id="${item.CartID}">
                                    <img src="${product.ProdImg}" alt="${product.ProdName}">
                                    <div class="item-details">
                                        <h3>${product.ProdName}</h3>
                                        <p>${product.ProdDsc}</p>
                                     
                                        <div class="quantity-controls">
                                            <button class="btn-decrease" data-id="${item.CartID}">-</button>
                                            <span class="item-quantity">${item.CartQty}</span>
                                            <button class="btn-increase" data-id="${item.CartID}">+</button>
                                            <button class="btn-remove" data-id="${item.CartID}"><i class="fa-solid fa-trash"></i></button>
                                        </div>
                                    </div>
                                    <div class="item-total">
                                     <h4><span id="itemPrice" class="item-price">${itemPrice.toFixed(2)}</span></h4>
                                        <h4>Item Total: $<span class="item-total-price">${itemTotal.toFixed(2)}</span></h4>
                                    </div>
                                </div>
                            `;

                            pendingRequests--;

                            if (pendingRequests === 0) {
                                CartContainer.html(cartHTML);
                                calculateTotal();
                            }
                        },
                        error: function () {
                            console.error('Error fetching product details.');
                            pendingRequests--;
                        }
                    });
                });
            },
            error: function () {
                console.error('Error fetching cart items.');
            }
        });
    }

    function calculateTotal() {

 
        let total = 0;
        console.log(total);
        console.log("Cart container found:", $('#cart-container').length > 0);
    
        // Check if there are cart items
        console.log("Cart items found:", $('.cart-item2').length);
       
        // Iterate over each cart item
        $('#cart-container .cart-item2').each(function () {
            // Debugging output to check the calculation process
            console.log("Calculating total...");
    
            // Extract quantity and price values
            const quantity = parseInt($(this).find('.item-quantity').text().trim(), 10);
             const price = parseFloat($(this).find('.item-price').text().trim().replace('$', ''));
    
            // Debugging output to check extracted values
            console.log(`Quantity: ${quantity}, Price: ${price}`);
    
            // Accumulate total price
            total += (quantity * price);
        });
    
        // Format total amount to two decimal places
        $('#total-price').text(total.toFixed(2));
        $('#total-container').show();
    }
    


    loadCart();

    $('#cart-container').on('click', '.btn-remove', function () {
        const cartId = $(this).data('id');
        $.ajax({
            type: "DELETE",
            url: `http://localhost:60939/api/Cart/Remove?CartID=${cartId}`,
            success: function () {
                loadCart(); // Reload cart after removing item
            },
            error: function () {
                console.error('Error removing item from cart.');
            }
        });
    });

    $('#cart-container').on('click', '.btn-increase, .btn-decrease', function () {
        const cartId = $(this).data('id');
        const $item = $(this).closest('.cart-item2');
        let quantity = parseInt($item.find('.item-quantity').text().trim());

        if ($(this).hasClass('btn-increase')) {
            quantity++;
        } else if ($(this).hasClass('btn-decrease') && quantity > 1) {
            quantity--;
        }

        const updatedItem = {
            CartID: cartId,
            UserID: userId,
            ProdID: $item.data('id'),
            CartQty: quantity,
            Price: parseFloat($item.find('.item-total-price').text().trim().replace('$', ''))
        };

        $.ajax({
            type: "PUT",
            url: "http://localhost:60939/api/Cart/Update",
            data: JSON.stringify(updatedItem),
            contentType: "application/json",
            success: function () {
                loadCart(); // Reload cart after updating quantity
            },
            error: function () {
                console.error('Error updating item quantity.');
            }
        });
    });
    
    $(document).on("click", "#Buy", (event) => {
        location.href = "./Payment.html";
    })
    

});

