var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { api } from "./common.js";
// Show total
$(document).ready(() => {
    let total = localStorage.getItem("total");
    $("#totalAmount").text(`Total Amount: ₹${total}`);
});
// Payment button click
$("#payBtn").on("click", () => __awaiter(void 0, void 0, void 0, function* () {
    let currentUser = JSON.parse(localStorage.getItem("User") || "null");
    if (!currentUser || !currentUser.Id) {
        alert("Session expired. Login again.");
        window.location.href = "../html/login.html";
        return;
    }
    try {
        // 🔥 CALL YOUR CHECKOUT API HERE
        yield $.ajax({
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
    }
    catch (err) {
        console.log(err);
        alert("Something went wrong");
    }
}));
