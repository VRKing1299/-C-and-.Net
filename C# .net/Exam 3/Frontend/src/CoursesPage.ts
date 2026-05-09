import {
    api,
    GetAllCartItems,
    GetAllCategories,
    GetAllCourses,
} from "./common.js";
import { Cart, Category, Course, User } from "./models.js";

//FUNCTION TO DISPLAY THE COURSES
async function DisplayCourses() {
    let course: Course[] = await GetAllCourses();

    let html = "";

    let catValue = Number($("#categoryFilter").val());
    let filteredCourse: Course[];
    if (catValue == 0 || catValue == undefined) {
        filteredCourse = course;
    } else {
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
}

//Function to display category drop down
async function DisplayCategoryDdl() {
    let category: Category[] = await GetAllCategories();

    let html = `<option value="0">All Categories</option>`;

    category.forEach((c) => {
        html += `<option value="${c.Id}">${c.Name}</option>`;
    });

    $("#categoryFilter").html(html);
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

async function AddToCart(courseId: number) {
    let currentUser: User = JSON.parse(localStorage.getItem("User") || "null");
    if (!currentUser.Id) {
        alert("Please Login First");
        window.location.href = "../html/login.html";
        return;
    }

    let CartItems: Cart[] = await GetAllCartItems(currentUser.Id);

    let item: Cart | undefined = CartItems.find((i) => i.CourseId == courseId);

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
}
