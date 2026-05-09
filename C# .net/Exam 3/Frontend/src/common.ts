import { Cart, Category, Course, Enrollment, User } from "./models.js";

export let api = {
    Users: "http://localhost:61082/api/User",
    Courses: "http://localhost:61082/api/Course",
    Category: "http://localhost:61082/api/Category",
    Cart: "http://localhost:61082/api/Cart",
    Enrollment: "http://localhost:61082/api/Enrollment?userId=",
};

export async function GetAllUsers() {
    let data = await $.ajax({
        url: api.Users,
        type: "GET",

        error: (e) => {
            console.log(e);
            alert(e);
        },
    });

    return data;
}

export async function GetAllCourses() {
    let data: Course[] = await $.ajax({
        url: api.Courses,
        type: "Get",

        error: (e) => {
            console.log(e);
            alert(e);
        },
    });
    return data;
}

export async function GetAllCategories() {
    let data: Category[] = await $.ajax({
        url: api.Category,
        type: "Get",

        error: (e) => {
            console.log(e);
            alert(e);
        },
    });
    return data;
}

export async function GetAllCartItems(UserId: number) {
    let data: Cart[] = await $.ajax({
        url: `${api.Cart}?userid=${UserId}`,
        type: "Get",

        error: (e) => {
            console.log(e);
            alert(e);
        },
    });
    return data;
}

export async function GetEnrollmentByUser(userId: number) {
    let data: Enrollment[] = await $.ajax({
        url: `${api.Enrollment}${userId}`,
        type: "GET",
        error: (e) => {
            console.log(e);
            alert("Error fetching enrollments");
        },
    });

    return data;
}
