var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { api, GetAllUsers } from "./common.js";
$("#SignUp-Form").on("submit", (e) => __awaiter(void 0, void 0, void 0, function* () {
    e.preventDefault();
    $("#SignUpBtn").prop("disabled", true);
    let formData = e.target;
    let data = new FormData(formData);
    const name = data.get("name").trim();
    const email = data.get("email").trim();
    const pass = data.get("password").trim();
    const role = data.get("role").trim();
    let users = yield GetAllUsers();
    let user = users.find((user) => user.Email.toLowerCase() == email.toLowerCase());
    if (user != undefined) {
        alert("User with This Email or Username already exist");
        $("#SignUpBtn").prop("disabled", false);
        return;
    }
    let newUser = {
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
}));
