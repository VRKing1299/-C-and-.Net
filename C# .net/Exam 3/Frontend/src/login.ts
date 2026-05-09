import { GetAllUsers } from "./common.js";
import { User } from "./models.js";

$("#login-Form").on("submit", async (e) => {
    e.preventDefault();

    let formData = e.target as HTMLFormElement;
    let data = new FormData(formData);

    const email = (data.get("email") as string).trim();
    const pass = (data.get("password") as string).trim();

    let users: User[] = await GetAllUsers();

    console.log("ALl Users : " + users);
    let user: User | undefined = users.find(
        (u: User) => u.UserPassword == pass && u.Email == email,
    );

    if (user) {
        alert("Login successful");
        localStorage.setItem("User", JSON.stringify(user));
        window.location.href = "../html/Index.html";
    } else {
        alert("Invalid username or password");
        $("#loginBtn").prop("disabled", false);
    }
});
