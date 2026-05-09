var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { GetAllUsers } from "./common.js";
$("#login-Form").on("submit", (e) => __awaiter(void 0, void 0, void 0, function* () {
    e.preventDefault();
    let formData = e.target;
    let data = new FormData(formData);
    const email = data.get("email").trim();
    const pass = data.get("password").trim();
    let users = yield GetAllUsers();
    console.log("ALl Users : " + users);
    let user = users.find((u) => u.UserPassword == pass && u.Email == email);
    if (user) {
        alert("Login successful");
        localStorage.setItem("User", JSON.stringify(user));
        window.location.href = "../html/Index.html";
    }
    else {
        alert("Invalid username or password");
        $("#loginBtn").prop("disabled", false);
    }
}));
