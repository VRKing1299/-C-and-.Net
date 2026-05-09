import { api, GetAllUsers } from "./common.js";
import { User } from "./models.js";

$("#SignUp-Form").on("submit", async (e) => {
    e.preventDefault();
    $("#SignUpBtn").prop("disabled", true);

    let formData = e.target as HTMLFormElement;
    let data = new FormData(formData);

    const name = (data.get("name") as string).trim();
    const email = (data.get("email") as string).trim();
    const pass = (data.get("password") as string).trim();
    const role = (data.get("role") as string).trim();

    let users: User[] = await GetAllUsers();

    let user: User | undefined = users.find(
        (user) => user.Email.toLowerCase() == email.toLowerCase(),
    );

    if (user != undefined) {
        alert("User with This Email or Username already exist");
        $("#SignUpBtn").prop("disabled", false);
        return;
    }

    let newUser: User = {
        UserName: name,
        Email: email,
        UserPassword: pass,
        UserRole: role,
    };

    $.ajax({
        url: api.Users,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(newUser),

        success: (response) => {
            // console.log(response)
            alert(response);
            setTimeout(() => {
                // $("#btnSignUp").prop("disabled", false);
                window.location.href = "../html/login.html";
            }, 1000);
        },

        error: (response) => {
            alert("error creating user");
            $("#SignUpBtn").prop("disabled", true);
        },
    });
});
