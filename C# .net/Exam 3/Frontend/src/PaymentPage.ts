import { api } from "./common.js";
import { User } from "./models.js";

// Show total
$(document).ready(() => {
    let total = localStorage.getItem("total");
    $("#totalAmount").text(`Total Amount: ₹${total}`);
});

// Payment button click
$("#payBtn").on("click", async () => {
    let currentUser: User = JSON.parse(localStorage.getItem("User") || "null");

    if (!currentUser || !currentUser.Id) {
        alert("Session expired. Login again.");
        window.location.href = "../html/login.html";
        return;
    }

    try {
        // 🔥 CALL YOUR CHECKOUT API HERE
        await $.ajax({
            url: `${api.Enrollment}${currentUser.Id}`, // <-- your API
            type: "POST",
            success: function () {
                alert("Payment Successful 🎉");

                // clear total
                localStorage.removeItem("total");

                // redirect to courses / dashboard
                window.location.href = "../html/courses.html";
            },
            error: function () {
                alert("Payment failed");
            },
        });
    } catch (err) {
        console.log(err);
        alert("Something went wrong");
    }
});
