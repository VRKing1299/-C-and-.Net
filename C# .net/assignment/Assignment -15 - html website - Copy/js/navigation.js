let headder = document.querySelector("header");
let loggedIN = localStorage.getItem("logedIn")||false;
// checking if user is logged in or not
if(!loggedIN){
    headder.innerHTML=`<nav>
        <div class="OpenNavigation">
            <i class="fa-solid fa-bars"></i>
        </div>
        <div class="logo">
            Toy Zone
        </div>
        <ul id="navigationList">
            <li><a href="index.html">Home</a></li>
            <li >
                <a href="Products.html"> Products </a>
            </li>
            <li><a href="aboutUs.html">about us</a></li>
            <li><a href="contactUs.html"> Contact us</a></li>
            <li class="floatRight"><a href="Login.html">Log In</a></li>
            <li class="floatRight">
                <a href="Login.html">
                    <img src="assets/shopping-cart-svgrepo-com.svg" alt="My Icon">
                    <div class="cart-Items-Indicator"></div>
                </a>
            </li>
        </ul>
    </nav>`;
}else{
    headder.innerHTML=`
    <nav>
        <div class="OpenNavigation">
            <i class="fa-solid fa-bars"></i>
        </div>
        <div class="logo">
            Toy Zone
        </div>
        <ul id="navigationList">
            <li><a href="index.html">Home</a></li>
            <li >
                <a href="Products.html"> Products </a>
            </li>
            <li><a href="aboutUs.html">about us</a></li>
            <li><a href="contactUs.html"> Contact us</a></li>
            <li class="floatRight" id="logOut"><a>Log Out</a></li>
            <li class="floatRight">
                <a href="Cart.html">
                    <img src="assets/shopping-cart-svgrepo-com.svg" alt="My Icon">
                    <div class="cart-Items-Indicator"></div>
                </a>
            </li>
        </ul>
    </nav>`;

}

// selecting the cart Items Indicator from html document
let cartItemsIndicator = document.querySelector(".cart-Items-Indicator");
//  getting the cart array from local storage in not present the empty array
let cart = JSON.parse(localStorage.getItem("cart")) || [];

// calculate total quantity of the products in the cart
let totalItems = cart.reduce((sum, item) => sum + item.prodQuant, 0);

if(totalItems > 0){
    cartItemsIndicator.classList.remove("cart-Items-Indicator-display");
    cartItemsIndicator.innerHTML = totalItems;
} else {
    cartItemsIndicator.classList.add("cart-Items-Indicator-display");
}

//opening and closing the navigation
let OpenNavigation= document.querySelector(".OpenNavigation");
let navigationList = document.querySelector("#navigationList");
OpenNavigation.addEventListener("click",()=>{
    navigationList.classList.toggle("showNavigation");
})

//code to log out
let logOut = document.querySelector("#logOut");
logOut.addEventListener("click",(e)=>{
    localStorage.removeItem("logedIn");
    window.location.href="index.html";
})