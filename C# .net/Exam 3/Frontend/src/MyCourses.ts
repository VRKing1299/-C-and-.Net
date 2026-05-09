import { GetAllCourses, GetEnrollmentByUser } from "./common.js";
import { Course, Enrollment, User } from "./models.js";

async function LoadMyCourses() {
    let currentUser: User = JSON.parse(localStorage.getItem("User") || "null");

    if (!currentUser || !currentUser.Id) {
        alert("Please login first");
        window.location.href = "../html/login.html";
        return;
    }

    console.log(currentUser.Id);
    let enrollments: Enrollment[] = await GetEnrollmentByUser(currentUser.Id);
    let courses: Course[] = await GetAllCourses();
    console.log(enrollments);

    let html = "";

    if (enrollments.length === 0) {
        $("#myCourses").html(
            `<div class="empty">No courses purchased yet</div>`,
        );
        return;
    }

    enrollments.forEach((e) => {
        // 🔥 Match course
        let course = courses.find((c) => c.Id === e.CourseId);

        if (!course) return;

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
}

$(document).ready(() => {
    LoadMyCourses();
});
