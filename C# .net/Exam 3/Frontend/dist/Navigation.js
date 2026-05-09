function Navbar() {
    let currentUser = JSON.parse(localStorage.getItem("User") || "null");
    let style = `
    <style>
            a {
                text-decoration: none;
                color: inherit;
            }
        /* ===== NAVBAR ===== */
            .navbar {
                background: white;
                padding: 16px 40px;
                display: flex;
                justify-content: space-between;
                align-items: center;
                border-bottom: 2px solid #ede8ff;
            }

            .logo {
                font-size: 24px;
                font-weight: bold;
                color: #5a0ffa;
                margin:0,10px;
            }

            .nav-links {
                display: flex;
                gap: 24px;
            }

            .nav-links a {
                padding: 0 10px;
                height: 36px;
                border-radius: 5px;
                color: #555;
                font-weight: 500;
                font-size: 15px;
                display: flex;
                justify-content: center;
                align-items: center;
                transition: all 0.3s;
            }

            .nav-links a:hover {
                background-color: #5a0ffa;
                color: white;
                transform: scale(1.1);
            }

            .nav-links .btn-login {
                background: #5a0ffa;
                color: white;
                padding: 8px 20px;
                border-radius: 8px;
            }

            .nav-links .btn-login:hover {
                background: #4400d0;
            }

            /* ===== RESPONSIVE ===== */
            @media (max-width: 700px) {
                .navbar {
                    padding: 14px 20px;
                    flex-direction: column;
                    gap: 12px;
                }
                .nav-links {
                    gap: 14px;
                }
                .hero h1 {
                    font-size: 28px;
                }
            }
    </style>`;
    let nav;
    if (!currentUser) {
        nav = `<a href="../html/login.html">MY Courses</a>
        <a href="../html/login.html">Cart</a>
        <a href="../html/login.html" class="btn-login">Login</a>`;
    }
    else {
        nav = `<a href="../html/MYCourses.html">MY Courses</a>
        <a href="../html/cart.html">Cart</a>
        <a href="#" id="logOut" class="btn-login">Log Out</a>`;
    }
    let html = `
    <nav class="navbar">
            <div class="logo">Learnly</div>
            <div class="nav-links">
                <a href="../html/Index.html">Home</a>
                <a href="../html/Courses.html">Courses</a>
                <a href="#">About</a>
                ${nav}       
            </div>
        </nav>`;
    $("head").append(style);
    $("body").prepend(html);
}
Navbar();
$("#logOut").on("click", (e) => {
    localStorage.removeItem("User");
    window.location.href = "../html/Index.html";
});
export {};
