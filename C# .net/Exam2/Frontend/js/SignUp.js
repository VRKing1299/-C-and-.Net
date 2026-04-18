$("#signUpForm").on("submit",(e)=>{
    e.preventDefault();
    $("#btnSignUp").prop("disabled", true);
    const data= new FormData(e.target);
    const userName = data.get("userName").trim();
    const email = data.get("email").trim();
    const phno =data.get("phoneNo").trim();
    const pass = data.get("password").trim();

    //validating phno
    if(!phno.split("").every(c=>c>=0 && c<=9)){
        alert("please enter valid phone number");
        return;
    }

    //fetching users data
    let UsersData= FetchAllUsers();
    if(!UsersData){
        alert("error fetching data");
        $("#btnSignUp").prop("disabled", false);
        return;
    }

    //finding existing user
    let user = UsersData.find((u)=>u.Email.toLowerCase()==email.toLowerCase() || u.UserName.toLowerCase()==userName.toLowerCase());

    // if user with same name exist
    if(user){
        alert("An account with this email or username already exists. Please log in instead.");
        $("#btnSignUp").prop("disabled", false);
        return;
    }

    //else creating new user
    let obj = {
        UserName: userName,
        Email: email,
        PhoneNo: phno,
        Password: pass,
        isAdmin: false
    }

    $.ajax({
        url:usersApi,
        type:"POST",
        contentType:"application/json",
        data:JSON.stringify(obj),

        success:(response)=>{
            alert(response);
            if(response.includes("error")){
                $("#btnSignUp").prop("disabled", false);
                return;
            }
            window.location.href="LogIn.html";
        },

        error:(response)=>{
            alert(response)
            console.log(response);
            $("#btnSignUp").prop("disabled", false);
        }
    })
})