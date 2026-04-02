//getting the carts data
cart=JSON.parse(localStorage.getItem("cart")) || [];
//gettin the products data 
let productsData= JSON.parse(localStorage.getItem("productsData"))||[];
//creating map of products for fast look up
let productMap= {};
productsData.forEach((prod)=>{
    productMap[prod.id]=prod;
})

//getting product container
let productsContainer=document.getElementById("productContainer");
let html = "";

let total = 0;

//displaying all the items from the product
cart.forEach(cartItem => {
    let product = productMap[cartItem.prodId];

    if(product){
        let itemTotal = product.price * cartItem.prodQuant;
        total += itemTotal;

        html +=
        `
        <div class="product-card">
                <div class="imageContainer">
                    <img src="${product.image}">
                </div>

                <div class="product-info">
                    <h3>${product.name}</h3>
                    <p>Price:₹${product.price}</p>
                    <p>Qty: ${cartItem.prodQuant}</p>
                    <p>Total: ₹${itemTotal}</p>
                </div>

                <div class="cart-actions">
                    <button class="add-btn" onclick="AddToCart(${product.id})">+</button>
                    <button class="remove-btn" onclick="RemoveFromCart(${product.id})">Remove</button>
                </div>
            </div>
        `;
    }
});

//displaying the container with total price
productsContainer.innerHTML += html;
document.getElementById("totalPrice").innerText = total;

//function to add the quantity of item to the cart
function AddToCart(id){

    let index = cart.findIndex(item => item.prodId === id);

    if(index === -1){
        DisplayMessage("error while adding the product");
    } else {
        cart[index].prodQuant++;
    }
    // console.log(cart);

    localStorage.setItem("cart", JSON.stringify(cart));

    location.reload(); // refreshing th page
}

//function to subtract the quantity from the cart and remove the if quantity goes less than one
function RemoveFromCart(id){
    let index = cart.findIndex(item => item.prodId === id);

    if(index === -1){
        DisplayMessage("error while adding the product");
    } else {
        if(cart[index].prodQuant==1){
            cart.splice(index, 1);
        }else{
            cart[index].prodQuant--;
        }
    }

    localStorage.setItem("cart", JSON.stringify(cart));
    location.reload();
}

// code to check out if the total amount in cart is greater than 0;
let btnCheckOut = document.querySelector(".checkout-btn");

btnCheckOut.addEventListener("click",()=>{
    if(total==0){
        DisplayMessage("please add atleast one product to cart")
    }else{
        localStorage.setItem("total",total);
        window.location.href="payment.html"
    }
})