$(document).ready(function () {
    const apiUrl = "http://localhost:60939/api/Product/ProductCategory?categoryId=3";

    // Retrieve UserID from sessionStorage
    // var userID = sessionStorage.getItem('userid');
    // if (!userID) {
    //     alert('User not logged in or UserID not found in sessionStorage');
    //     // Navigate to a new page
    //     window.location.href = './Login.html';
    //     return; // Exit if UserID is not set
    // }

    function displayEyeliner() {
        $.ajax({
            type: "GET",
            url: apiUrl,
            success: function (response) {
                $('#cardHello').empty();

                response.forEach(function (item) {
                    const { ProdID, ProdName, ProdDsc, ProdPrice, ProdImg } = item;
                    const cardHtml = `
                        <section>
                            <div class="container">
                                <div class="card" id="tote">
                                    <div class="card-inner" style="--clr:#fff;">
                                        <div class="box">
                                            <div class="imgBox">
                                                <img src="${ProdImg}" alt="${ProdName}">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="content">
                                        <h3>${ProdName}</h3>
                                        <p>${ProdDsc}</p>
                                        <h4>$&nbsp;${ProdPrice}</h4>
                                        <button class="btnAddToCart" data-id="${ProdID}" data-name="${ProdName}" data-description="${ProdDsc}" data-price="${ProdPrice}" data-img="${ProdImg}">Add to Cart</button>
                                    </div>
                                </div>
                            </div>
                        </section>
                    `;
                    $('#cardHello').append(cardHtml);
                });
                
                // Attach event handler for "Add to Cart" buttons
                $('.btnAddToCart').on('click', function () {
                    const item = {
                        id: $(this).data('id'),
                        name: $(this).data('name'),
                        description: $(this).data('description'),
                        price: $(this).data('price'),
                        img: $(this).data('img')
                    };

                    addToCart(item);
                });
            },
            error: function (err) {
                alert('Error fetching product data');
                console.log(err);
            }
        });
    }

    function addToCart(item) {
        const productId = item.id;
        var userID = sessionStorage.getItem('userid');
    if (!userID) {
        alert('User not logged in ');
        // Navigate to a new page
        window.location.href = './Login.html';
        return; // Exit if UserID is not set
    }

        $.ajax({
            type: "GET",
            url: `http://localhost:60939/api/Cart/Search/${productId}`,
            success: function (response) {
                if (response.length === 0) {
                    // Add new entry if item is not in the cart
                    $.ajax({
                        type: "POST",
                        url: "http://localhost:60939/api/Cart/Add",
                        data: JSON.stringify({
                            ProdID: productId,
                            CartQty: 1,
                            Price: item.price,
                            UserID: userID // Use UserID from sessionStorage
                        }),
                        contentType: "application/json",
                        success: function () {
                            alert('Item added to Cart!');
                        },
                        error: function (err) {
                            alert('Error adding item to Cart');
                            console.log(err);
                        }
                    });
                } else {
                    // Update quantity if item already exists
                    const cartItem = response[0];
                    const updatedItem = {
                        CartID: cartItem.CartID,
                        UserID: userID, // Use UserID from sessionStorage
                        ProdID: productId,
                        CartQty: cartItem.CartQty + 1,
                        Price: cartItem.Price
                    };
                    updateCart(updatedItem);
                }
            },
            error: function (err) {
                console.log('Error fetching cart data');
                console.log(err);
            }
        });
    }

    function updateCart(cartItem) {
        $.ajax({
            type: "PUT",
            url: "http://localhost:60939/api/Cart/Update",
            data: JSON.stringify(cartItem),
            contentType: "application/json",
            success: function () {
                alert('Item quantity updated in Cart!');
            },
            error: function (err) {
                console.log('Error updating cart item');
                console.log(err);
            }
        });
    }

    displayEyeliner();
});
