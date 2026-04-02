// this is user data array list with each object repreenting user
let userData = [
    { name: 'admin', pass: '1234',email:'admin@gmail.com' },
]

//variable for submit button and form
let btnSubmit = document.querySelector("#btnLogin")
let form = document.querySelector("#loginform");

//event lister for form when form is submitted
form.addEventListener("submit",(e)=>{
    e.preventDefault();
    const data = new FormData(e.target);
    const name = data.get("username").trim();
    const pass = data.get("password").trim();
    //when fields are empty , return nothing to exit the function
    if(name==="" || pass===""){
        DisplayMessage("username password cannot be empty")
        return;
    }

    //finding the user
    let userFound= userData.find(user=> user.name===name && user.pass===pass);

    //if user found then login successful and redirect at home else not successful
    if(userFound){
        DisplayMessage("Login successful");
        btnSubmit.setAttribute("disabled", "true");
        localStorage.setItem("logedIn",JSON.stringify(true));
        setTimeout(() => {
            window.location.href = "index.html";
        }, 1000);
    }
    else {
        DisplayMessage("Invalid username or password");
    }
})