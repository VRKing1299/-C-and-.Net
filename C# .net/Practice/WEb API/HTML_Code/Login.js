function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

// Register new user
function register() {
    const fullName = document.getElementById('fullName').value;
    const emailAddress = document.getElementById('emailAddress').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;

    // Validate fields
    if (fullName === '' || emailAddress === '' || password === '' || confirmPassword === '') {
        alert('Please fill out all fields.');
        return;
    }

    // Validate email
    if (!validateEmail(emailAddress)) {
        alert('Please enter a valid email address.');
        return;
    }

    // Check password matches confirmPassword
    if (password !== confirmPassword) {
        alert('Passwords do not match.');
        return;
    }
    $.ajax({
        type: "POST",
        url: "http://localhost:60939/api/UserDetail",
        contentType: "application/x-www-form-urlencoded",
        data: `UserName=${fullName}&UserPassword=${password}&UserEmail=${emailAddress}&UserConfirmPassword=${confirmPassword}&TypeId=2`,
        success: (res) => {
            alert("Registration Successful");
            location.href = "./Login.html";
        },
        error: (err) => {
            console.error("Registration error:", err); // Log error to console for debugging
            alert('An error occurred during registration. Please try again.');
        }
    });
    

  
}


//Login Function
function ChkLogin() {
    alert("in");
    // Retrieve values from the form fields
    let username = $('#UserName').val().trim();
    let password = $('#UserPassword').val().trim();

    // Validate fields
    if (username === "" || password === "") {
        alert('Please fill out both username and password.');
        return;
    }

    // Make an AJAX request to get user details by email
    $.ajax({
        type: "GET",
        url: `http://localhost:60939/api/UserDetail/GetUserByUserName?Username=${username}`,
        success: (res) => {

            
            if (res) {
                // Check if the password matches
                if (password === res.UserPassword) {
                    // Check user type and redirect accordingly
                    if (res.TypeId === 1) { // Assuming TypeId 1 is Admin
                        alert("Login Successful as Admin");
                        sessionStorage.setItem("userEmail", username);
                        sessionStorage.setItem("userid", res.UserID);
                        alert("Admin Login "+username);
                        location.href = "./AdminHome.html";
                    } else if (res.TypeId === 2) { // Assuming TypeId 2 is regular user
                        alert("Login Successful");
                        sessionStorage.setItem("userEmail", username);
                        
                        sessionStorage.setItem("userid", res.UserID);
                        location.href = "./index.html";
                    } else {
                        alert('Unexpected user type.');
                    }
                } else {
                    alert('Invalid password.');
                    $('#UserName').val('');
                    $('#UserPassword').val('');
                }
            } else {
                alert('User not found.');
                $('#UserName').val('');
                $('#UserPassword').val('');
            }
        }, 
        error: (err) => {
            console.error("Error during login:", err);
            alert('An error occurred while logging in. Please try again.');
        }
    });
}
