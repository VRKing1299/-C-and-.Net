//array of products
let productsData = [
    {id:1, name:"Mazda MX-5 Miata", category:"Hot Wheels", price:150, image:"./assets/products/Mazda MX-5 Miata.jfif"},
    {id:2, name:"Lamborghini Huracan", category:"Hot Wheels", price:180, image:"./assets/products/Lamborghini Huracan.jfif"},
    {id:3, name:"Bugatti Chiron", category:"Hot Wheels", price:200, image:"./assets/products/Bugatti Chiron.jfif"},
    {id:4, name:"Ford Mustang GT", category:"Hot Wheels", price:160, image:"./assets/products/Ford Mustang GT.jfif"},
    {id:5, name:"Nissan Skyline R34", category:"Hot Wheels", price:220, image:"./assets/products/Nissan Skyline R34.jfif"},

    {id:6, name:"RC Drift Car", category:"RC", price:1200, image:"./assets/products/RC Drift Car.jfif"},
    {id:7, name:"RC Monster Truck", category:"RC", price:1500, image:"./assets/products/RC Monster Truck.jfif"},
    {id:8, name:"RC Helicopter", category:"RC", price:1800, image:"./assets/products/RC Helicopter.jfif"},
    {id:9, name:"RC Racing Bike", category:"RC", price:1300, image:"./assets/products/RC Racing Bike.jfif"},
    {id:10, name:"RC Offroad Jeep", category:"RC", price:1700, image:"./assets/products/RC Offroad Jeep.jfif"},

    {id:11, name:"Teddy Bear Large", category:"Soft Toys", price:500, image:"./assets/products/Teddy Bear Large.jfif"},
    {id:12, name:"Cute Panda Plush", category:"Soft Toys", price:450, image:"./assets/products/Cute Panda Plush.jfif"},
    {id:13, name:"Horse Soft Toy", category:"Soft Toys", price:600, image:"./assets/products/Horse Soft Toy.jfif"},
    {id:14, name:"Baby Elephant Plush", category:"Soft Toys", price:550, image:"./assets/products/Baby Elephant Plush.jfif"},
    {id:15, name:"Soft Toy Dog", category:"Soft Toys", price:400, image:"./assets/products/Soft Toy Dog.jfif"},

    {id:16, name:"Iron Man Figure", category:"Action Figures", price:800, image:"./assets/products/Iron Man Figure.jfif"},
    {id:17, name:"Spider-Man Figure", category:"Action Figures", price:750, image:"./assets/products/Spider-Man Figure.jfif"},
    {id:18, name:"Batman Figure", category:"Action Figures", price:850, image:"./assets/products/Batman Figure.jfif"},
    {id:19, name:"Naruto Figure", category:"Action Figures", price:900, image:"./assets/products/Naruto Figure.jfif"},
    {id:20, name:"Dragon Ball Goku Figure", category:"Action Figures", price:950, image:"./assets/products/Dragon Ball Goku Figure.jfif"}
];

if(!localStorage.getItem("productsData")){
    localStorage.setItem("productsData", JSON.stringify(productsData));
}

//array of cart


function DisplayProducts(products){
    let productsContainer = document.getElementById("productContainer");
    productsContainer.innerHTML="";
    //displaying the products 
    products.forEach(prod=>{
        productsContainer.innerHTML+=
        `<div class="product-card" >
            <div class="image-Container">
                <img src="${prod.image}">
                <span class="category">${prod.category}</span>
            </div>
            
            <h3>${prod.name}</h3>
            <p>₹${prod.price}</p>
            <button  onclick="AddToCart(${prod.id})"> 🛒 Add to Cart</button>
        </div>`
    })
}
DisplayProducts(productsData);

//functions that adds product to the cart based on id 
function AddToCart(id){
    let cart=JSON.parse(localStorage.getItem("cart")) || [];
    let ind=cart.findIndex(prod=>prod.prodId==id);
    if(ind== -1){
        cart.push({prodId:id,prodQuant:1});
    }else{
        cart[ind].prodQuant++;
    }

    localStorage.setItem("cart", JSON.stringify(cart));
    // console.log(cart);
    // location.reload();
}


//sorting using category
let categoryFilter=document.querySelector("#categoryFilter");

let categories = ["all", ...new Set(productsData.map(p => p.category))];

categories.forEach((cat)=>{
    categoryFilter.innerHTML+=
    `<option value="${cat}">${cat}</option>`;
})

categoryFilter.addEventListener("change",(e)=>{
    let filter = e.target.value;
    if(filter=== 'all'){
        DisplayProducts(productsData)
    }else{
        let filteredProduct = productsData.filter((prod)=>prod.category===filter);
        DisplayProducts(filteredProduct);
    }
})