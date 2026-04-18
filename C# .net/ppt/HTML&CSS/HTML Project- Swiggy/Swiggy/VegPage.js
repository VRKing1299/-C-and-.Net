document.addEventListener("DOMContentLoaded", function () {
    displayVegFoods();
    refreshCartIndicator();
    updateCartCounter();
});
 


function displayVegFoods() {
    let container = document.getElementById("veg-container"); 
    let htmlContent = "";

    vegFoods.forEach((food, index) => {
        htmlContent += `
        <div class="imges">
            <img src="${food.image}" alt="${food.name}" loading="lazy">
            <div class="imgprop">
                <p class="img-description">${food.description}</p>
                <div class="star-container">⭐⭐⭐⭐⭐</div>
                <div><i class="fa-solid fa-indian-rupee-sign"></i> ${food.price}.00</div>
                <button class="btn-add" onclick="addToCart(${index},vegFoods)">Add To Cart</button>
            </div>
        </div>
        `;
    });

    container.innerHTML = htmlContent; // Inject HTML dynamically
}

// =========================================================

