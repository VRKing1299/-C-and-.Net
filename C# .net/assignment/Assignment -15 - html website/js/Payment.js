let total = localStorage.getItem("total");

let totalDisplay = document.querySelector(".totalPayment");

totalDisplay.innerHTML="Total ₹"+total;

let btnPay=document.querySelector("#btnpay")
btnPay.addEventListener("click",()=>{
    localStorage.removeItem("cart");
    localStorage.removeItem("total");
    window.location.href="index.html";
})