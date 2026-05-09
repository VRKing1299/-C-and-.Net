var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { api, GetAllCartItems, GetAllCategories, GetAllCourses, } from "./common.js";
//FUNCTION TO DISPLAY THE COURSES
function DisplayCourses() {
    return __awaiter(this, void 0, void 0, function* () {
        let course = yield GetAllCourses();
        let html = "";
        let catValue = Number($("#categoryFilter").val());
        let filteredCourse;
        if (catValue == 0 || catValue == undefined) {
            filteredCourse = course;
        }
        else {
            filteredCourse = course.filter((c) => c.CategoryId == catValue);
        }
        console.log(catValue);
        console.log(filteredCourse);
        filteredCourse.forEach((c) => {
            html += `
        <div class="course-card">
            <img src="${c.ImgLink || ""}" />
            <h3>${c.Title}</h3>
            <p>${c.Description}</p>
            <p class="price">₹${c.Price}</p>
            <button class="add-to-cart" data-id="${c.Id}">Add to Cart</button>
        </div>
        `;
        });
        $("#courseContainer").html(html);
    });
}
//Function to display category drop down
function DisplayCategoryDdl() {
    return __awaiter(this, void 0, void 0, function* () {
        let category = yield GetAllCategories();
        let html = `<option value="0">All Categories</option>`;
        category.forEach((c) => {
            html += `<option value="${c.Id}">${c.Name}</option>`;
        });
        $("#categoryFilter").html(html);
    });
}
$(document).ready(() => {
    DisplayCategoryDdl();
    DisplayCourses();
});
$("#categoryFilter").on("change", (e) => {
    DisplayCourses();
});
$("#courseContainer").on("click", ".add-to-cart", function () {
    const courseId = Number($(this).data("id"));
    AddToCart(courseId);
});
//FUNCTION To Add the Course To Cart
function AddToCart(courseId) {
    return __awaiter(this, void 0, void 0, function* () {
        let currentUser = JSON.parse(localStorage.getItem("User") || "null");
        if (!currentUser.Id) {
            alert("Please Login First");
            window.location.href = "../html/login.html";
            return;
        }
        let CartItems = yield GetAllCartItems(currentUser.Id);
        let item = CartItems.find((i) => i.CourseId == courseId);
        if (item) {
            alert("Course is already Added To Cart");
            return;
        }
        $.ajax({
            url: `${api.Cart}/Add`,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({
                UserId: currentUser.Id,
                CourseId: courseId,
            }),
            success: function (res) {
                alert("Course Added To Cart");
            },
            error: function () {
                alert("Error adding to cart");
            },
        });
    });
}
