var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { GetAllCourses, GetEnrollmentByUser } from "./common.js";
function LoadMyCourses() {
    return __awaiter(this, void 0, void 0, function* () {
        let currentUser = JSON.parse(localStorage.getItem("User") || "null");
        if (!currentUser || !currentUser.Id) {
            alert("Please login first");
            window.location.href = "../html/login.html";
            return;
        }
        console.log(currentUser.Id);
        let enrollments = yield GetEnrollmentByUser(currentUser.Id);
        let courses = yield GetAllCourses();
        console.log(enrollments);
        let html = "";
        if (enrollments.length === 0) {
            $("#myCourses").html(`<div class="empty">No courses purchased yet</div>`);
            return;
        }
        enrollments.forEach((e) => {
            // 🔥 Match course
            let course = courses.find((c) => c.Id === e.CourseId);
            if (!course)
                return;
            html += `
        <div class="course-card">

            <div class="course-thumb">
                <img src="${course.ImgLink || "https://via.placeholder.com/300"}" />
            </div>

            <div class="course-body">
                <h4>${course.Title}</h4>
                <p>${course.Description}</p>

                <div class="course-footer">
                    <span class="price">₹${course.Price}</span>
                    <button class="btn-enroll">Start Learning</button>
                </div>
            </div>

        </div>
        `;
        });
        $("#myCourses").html(html);
    });
}
$(document).ready(() => {
    LoadMyCourses();
});
