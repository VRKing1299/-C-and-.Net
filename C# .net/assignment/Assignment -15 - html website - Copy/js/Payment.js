// getting the total amount to pay from local storeage
let total = localStorage.getItem("total");

// displaying the total amount
let totalDisplay = document.querySelector(".totalPayment");

totalDisplay.innerHTML="Total ₹"+total;

// clearing the cart and redirecting to index(home) page
let btnPay=document.querySelector("#btnpay")
btnPay.addEventListener("click",()=>{
    localStorage.removeItem("cart");
    localStorage.removeItem("total");
    window.location.href="index.html";
})