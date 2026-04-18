document.addEventListener("DOMContentLoaded", function () {
    displayChiFoods();
    updateCartCounter();
});


function displayChiFoods() {
    let container = document.getElementById("chienese-container"); 
    let htmlContent = "";

    chiFoods.forEach((food, index) => {
        htmlContent += `
        <div class="imges">
            <img src="${food.image}" alt="${food.name}" loading="lazy">
            <div class="imgprop">
                <p class="img-description">${food.description}</p>
                <div class="star-container">⭐⭐⭐⭐⭐</div>
                <div><i class="fa-solid fa-indian-rupee-sign"></i> ${food.price}.00</div>
                <button class="btn-add" onclick="addToCart(${index},chiFoods)">Add To Cart</button>
            </div>
        </div>
        `;
    });

    container.innerHTML = htmlContent; // Inject HTML dynamically
}
