

//===============Validation of Login ========================================================
var btn = document.getElementById("bttn")

btn.addEventListener("click",function (event){
           
  event.preventDefault(); // Prevent form submission

  var username = document.querySelector("input[name='username']").value.trim();
  var password = document.querySelector("input[name='password']").value.trim();

  if(username === "" || password ===""){
    alert("Username and password cannot be empty!");  
    return;
  }

  let userdata = JSON.parse(localStorage.getItem("userdata")) || [];

  let userFound = userdata.find(u1 => u1.name === username && u1.pass == password)
  
    if(userFound){
      alert("Login successful!");
      window.location.href = "HomePage.html";
    }else{
      alert("Invalid username or password!");   
    }
})
//===========================================================================================