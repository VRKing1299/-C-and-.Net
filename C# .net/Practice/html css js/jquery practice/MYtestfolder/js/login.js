$("#loginForm").on("submit", async (e) => {
    e.preventDefault();
    $("#btnLogin").prop("disabled", true);
    const data = new FormData(e.target);
    const email = data.get("email").trim();
    const pass = data.get("password").trim();

    try {
        let userdData = await fetchUsersData();
        console.log(userdData);
        let user = userdData.find(
            (u) => u.Email == email && u.Password == pass,
        );
        if (!user) {
            alert("Please Enter Correct Email or password");
            $("#btnLogin").prop("disabled", false);
            return;
        }

        localStorage.setItem("User", JSON.stringify(user));
        alert("Login Successful");
    } catch (ex) {
        console.log(ex);
        $("#btnLogin").prop("disabled", false);
    }

    // let usersData = fetch(usersApi);
    // usersData
    //     .then((res) => res.json())
    //     .then((res) => {
    //         console.log(res);
    //         let user = res.find((u) => u.Email == email && u.Password == pass);

    //         if (!user) {
    //             alert("Please Enter Correct Email or password");
    //             $("#btnLogin").prop("disabled", false);
    //             return;
    //         }

    //         localStorage.setItem("User", JSON.stringify(user));
    //         alert("Login Successful");
    //         // window.location.href = "Index.html";
    //     })
    //     .catch((err) => {
    //         console.log(err);
    //     });
});

async function fetchUsersData() {
    return await $.ajax({
        url: usersApi,
        method: "GET",
        // dataType: "json", // ensures auto parsing
    });
    // return JSON.parse(res);
    // manually parse
    // console.log(res);

    // return typeof res === "string" ? JSON.parse(res) : res;
}
