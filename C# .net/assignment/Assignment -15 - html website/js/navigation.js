let headder = document.querySelector("header");
let loggedIN = localStorage.getItem("logedIn")||false;

if(!loggedIN){
    headder.innerHTML=`<nav>
        <ul>
            <li><a href="index.html">Home</a></li>
            <li >
                <a href="Products.html"> Products </a>
            </li>
            <li><a href="aboutUs.html">about us</a></li>
            <li><a href="contactUs.html"> Contact us</a></li>
            <li class="floatRight">
                <a href="Login.html">
                    <img src="assets/shopping-cart-svgrepo-com.svg" alt="My Icon">
                    <div class="cart-Items-Indicator"></div>
                </a>
            </li>
            <li class="floatRight"><a href="Login.html">LogIn</a></li>
        </ul>
    </nav>`;
}else{
    headder.innerHTML=`<nav>
        <ul>
            <li><a href="index.html">Home</a></li>
            <li >
                <a href="Products.html"> Products </a>
            </li>
            <li><a href="aboutUs.html">about us</a></li>
            <li><a href="contactUs.html"> Contact us</a></li>
            <li class="floatRight">
                <a href="Cart.html">
                    <img src="assets/shopping-cart-svgrepo-com.svg" alt="My Icon">
                    <div class="cart-Items-Indicator"></div>
                </a>
            </li>
            <li class="floatRight"><a href="">Account</a></li>
        </ul>
    </nav>`;

}


    // <li class="products">
    //             <a href=""> Products <i class="fa-solid fa-angle-down"></i></a>
    //             <ul class="dropdown">
    //                 <li><a href="">cars</a></li>
    //                 <li><a href="">tracks</a></li>
    //                 <li><a href="">Lego</a></li>
    //             </ul>
    //         </li>
let cartItemsIndicator = document.querySelector(".cart-Items-Indicator");
let cart = JSON.parse(localStorage.getItem("cart")) || [];

// calculate total quantity 
let totalItems = cart.reduce((sum, item) => sum + item.prodQuant, 0);

if(totalItems > 0){
    cartItemsIndicator.classList.remove("cart-Items-Indicator-display");
    cartItemsIndicator.innerHTML = totalItems;
} else {
    cartItemsIndicator.classList.add("cart-Items-Indicator-display");
}