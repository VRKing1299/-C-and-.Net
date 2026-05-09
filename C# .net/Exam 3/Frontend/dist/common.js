var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
export let api = {
    Users: "http://localhost:61082/api/User",
    Courses: "http://localhost:61082/api/Course",
    Category: "http://localhost:61082/api/Category",
    Cart: "http://localhost:61082/api/Cart",
    Enrollment: "http://localhost:61082/api/Enrollment?userId=",
};
export function GetAllUsers() {
    return __awaiter(this, void 0, void 0, function* () {
        let data = yield $.ajax({
            url: api.Users,
            type: "GET",
            error: (e) => {
                console.log(e);
                alert(e);
            },
        });
        return data;
    });
}
export function GetAllCourses() {
    return __awaiter(this, void 0, void 0, function* () {
        let data = yield $.ajax({
            url: api.Courses,
            type: "Get",
            error: (e) => {
                console.log(e);
                alert(e);
            },
        });
        return data;
    });
}
export function GetAllCategories() {
    return __awaiter(this, void 0, void 0, function* () {
        let data = yield $.ajax({
            url: api.Category,
            type: "Get",
            error: (e) => {
                console.log(e);
                alert(e);
            },
        });
        return data;
    });
}
export function GetAllCartItems(UserId) {
    return __awaiter(this, void 0, void 0, function* () {
        let data = yield $.ajax({
            url: `${api.Cart}?userid=${UserId}`,
            type: "Get",
            error: (e) => {
                console.log(e);
                alert(e);
            },
        });
        return data;
    });
}
export function GetEnrollmentByUser(userId) {
    return __awaiter(this, void 0, void 0, function* () {
        let data = yield $.ajax({
            url: `${api.Enrollment}${userId}`,
            type: "GET",
            error: (e) => {
                console.log(e);
                alert("Error fetching enrollments");
            },
        });
        return data;
    });
}
