// array of user
let userData = JSON.parse(localStorage.getItem("userData")) ||  [
    { name: 'admin', pass: '1234',email:'admin@gmail.com' },
]

// getting the form and btn from html
let form = document.querySelector("#signUpform");
let btnSignUp = document.querySelector("#btnSignUp");

// adding event listener submit to the form
form.addEventListener("submit",(e)=>{
    e.preventDefault();
    const data = new FormData(e.target);
    const name = data.get("username").trim();
    const email = data.get("email").trim();
    const pass = data.get("password").trim();

    // checking for empty parameter
    if(name==="" || pass==="" || email===""){
        DisplayMessage("username, email or password cannot be empty")
        return;
    }

    // checking for existing user with same username of id
    let userFound = userData.find(user => user.name === name);
    let emailFound = userData.find(user => user.email === email);

    if (userFound) {
        DisplayMessage("Username already exists");
        return;
    }

    if (emailFound) {
        DisplayMessage("Email already exists");
        return;
    }
    
    // inserting new user data into array and then uploading it to local storeage
    userData.push({ name: name, pass: pass,email:email });

    localStorage.setItem("userData",JSON.stringify(userData));

    // displaying message and then redirecting user to login
    DisplayMessage("Registered Successfully Please login")
    btnSignUp.setAttribute("disabled", "true");
    setTimeout(() => {
        btnSignUp.setAttribute("disabled", "false");
        window.location.href="Login.html";
    }, 1000);
})