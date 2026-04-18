const vegFoods = [
    {
        name: "Veg Baji",
        image: "../WebsiteSwiggy/Images/VegBaji.jpg",
        description: "Crispy, deep-fried vegetable fritters served with chutney.",
        price: 500
    },
    {
        name: "Chilla",
        image: "../WebsiteSwiggy/Images/VegImage/Chilla.jpg",
        description: "A healthy gram flour pancake, served with green chutney.",
        price: 1000
    },
    {
        name: "Dosa",
        image: "../WebsiteSwiggy/Images/VegImage/dosa.jpg",
        description: "South Indian rice pancake ,coconut chutney and sambar.",
        price: 1500
    },
    {
        name: "Khichdi",
        image: "../WebsiteSwiggy/Images/VegImage/Khichdi.jpg",
        description: "A light, comforting one-pot dish made with rice and lentils.",
        price: 2000
    },
    {
        name: "Paratha",
        image: "../WebsiteSwiggy/Images/Paratha.jpg",
        description: "Stuffed Indian flatbread served with butter and pickle.",
        price: 200
    },
    {
        name: "Samosa",
        image: "../WebsiteSwiggy/Images/VegImage/samosa.jpg",
        description: "Crispy pastry filled with spiced potatoes and peas.",
        price: 700
    },
    {
        name: "Veg Thali",
        image: "../WebsiteSwiggy/Images/VegImage/vegthali.jpg",
        description: "A platter with an assortment of vegetarian dishes.",
        price: 300
    },
    {
        name: "Vada",
        image: "../WebsiteSwiggy/Images/VegImage/vada.jpg",
        description: "Deep-fried lentil doughnuts served with chutney.",
        price: 600
    }
];

// Function to display food items
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
                <button class="btn-add" onclick="addToBill(${index})">Add To Cart</button>
            </div>
        </div>
        `;
    });

    container.innerHTML = htmlContent; // Inject HTML dynamically
}

// Function to add item to bill page
function addToBill(index) {
    let selectedFood = vegFoods[index];

    // Retrieve existing bill items from localStorage
    let billItems = JSON.parse(localStorage.getItem("billItems")) || [];

    // Check if item is already in the bill and increase quantity
    let existingItem = billItems.find(item => item.name === selectedFood.name);
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        selectedFood.quantity = 1; // Set initial quantity
        billItems.push(selectedFood);
    }

    // Store updated bill items back to localStorage
    localStorage.setItem("billItems", JSON.stringify(billItems));

    alert(`${selectedFood.name} added to cart!`);
}

// Run the function on page load
document.addEventListener("DOMContentLoaded", displayVegFoods);