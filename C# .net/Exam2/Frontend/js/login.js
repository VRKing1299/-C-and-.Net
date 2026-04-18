$("#loginForm").on("submit",(e)=>{
    e.preventDefault();
    $("#btnLogin").prop("disabled", true);
    const data= new FormData(e.target);
    const email = data.get("email").trim();
    const pass = data.get("password").trim();

    let UsersData= FetchAllUsers();
    if(!UsersData){
        alert("error fetching data");
        $("#btnLogin").prop("disabled", false);
        return;
    }

    let user = UsersData.find((u)=>u.Email==email && u.Password==pass);

    if(!user){
        alert("Please Enter Correct Email or password");
        $("#btnLogin").prop("disabled", false);
        return;
    }

    localStorage.setItem("User",JSON.stringify(user));
    alert("Login Successful");
    window.location.href="Index.html"

})