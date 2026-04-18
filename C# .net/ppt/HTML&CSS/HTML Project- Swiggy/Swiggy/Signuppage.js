 let userdata = JSON.parse(localStorage.getItem("userdata")) || [
    { name: 'admin', pass: '1234',email:'admin@gmail.com' },
    { name: 'sudhanshu', pass: '12345',email:'sid@gmail.com' },
    { name: 'abhi', pass: 'abhi123',email:'abhi@@gmail.com' }
];


let form = document.getElementById("signupForm");
let username,userpass,useremail;
form.addEventListener("submit",function(event){ 

  event.preventDefault();

  username  =  document.getElementById("name").value.trim();
  useremail =  document.getElementById("email").value.trim();
  userpass  =  document.getElementById("password").value.trim();

    if(username === "" || userpass ==="" || useremail ===""){
      alert("Username and password and email cannot be empty!");  
      return;
    }       

    let userExists = userdata.some(user => user.name === username || user.email === useremail);

    if (userExists) {
      alert("Username or Email already exists! Try a different one.");
      return;
    }

    userdata.push({name:username,email:useremail,pass:userpass});
    localStorage.setItem("userdata", JSON.stringify(userdata));
    alert("Sign Up  successfully!");
    window.location.href = "Loginpage.html";
    
})
