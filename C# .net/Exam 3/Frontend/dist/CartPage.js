var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { api, GetAllCartItems, GetAllCourses } from "./common.js";
// function to load the cart
function LoadCart() {
    return __awaiter(this, void 0, void 0, function* () {
        let currentUser = JSON.parse(localStorage.getItem("User") || "null");
        if (!currentUser || !currentUser.Id) {
            alert("Please Login First");
            window.location.href = "../html/login.html";
            return;
        }
        let cartItems = yield GetAllCartItems(currentUser.Id);
        let courses = yield GetAllCourses();
        console.log(cartItems);
        let html = "";
        let total = 0;
        if (cartItems.length === 0) {
            $("#cartItems").html(`<div class="empty">Your cart is empty 🛒</div>`);
            $("#cartTotal").html("");
            return;
        }
        cartItems.forEach((cartItem) => {
            let course = courses.find((c) => c.Id === cartItem.CourseId);
            if (!course)
                return; // safety
            total += course.Price;
            html += `
        <div class="course-card">

            <div class="course-thumb">
                <img src="${course.ImgLink}" />
            </div>

            <div class="course-body">
                <h4>${course.Title}</h4>
                <p>${course.Description}</p>

                <div class="course-footer">
                    <span class="price">₹${course.Price}</span>
                    <button class="btn-enroll remove-btn" data-id="${cartItem.Id}">
                        Remove
                    </button>
                </div>
            </div>

        </div>
        `;
        });
        localStorage.setItem("total", JSON.stringify(total));
        $("#cartItems").html(html);
        $("#cartTotal").html(`Total: ₹${total}`);
    });
}
LoadCart();
$("#cartItems").on("click", ".remove-btn", function () {
    return __awaiter(this, void 0, void 0, function* () {
        const cartId = Number($(this).data("id"));
        if (!cartId) {
            alert("Invalid item");
            return;
        }
        // Optional confirmation
        if (!confirm("Remove this item from cart?"))
            return;
        try {
            yield $.ajax({
                url: `${api.Cart}/${cartId}`,
                type: "DELETE",
                success: function () {
                    alert("Item removed successfully");
                },
                error: function () {
                    alert("Error removing item");
                },
            });
            LoadCart();
        }
        catch (err) {
            console.log(err);
            alert("Something went wrong");
        }
    });
});
$("#checkoutBtn").on("click", () => __awaiter(void 0, void 0, void 0, function* () {
    let currentUser = JSON.parse(localStorage.getItem("User") || "null");
    if (!currentUser || !currentUser.Id) {
        alert("Please login first");
        window.location.href = "../html/login.html";
        return;
    }
    let cartItems = yield GetAllCartItems(currentUser.Id);
    if (cartItems == null || cartItems.length == 0) {
        alert("Please add one item in cart");
    }
    // Save total (optional, already doing it)
    let total = localStorage.getItem("total");
    // Navigate to payment page
    window.location.href = "../html/payment.html";
}));
