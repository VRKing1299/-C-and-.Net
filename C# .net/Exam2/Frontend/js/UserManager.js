function DisplayUsers(data){
    let html = "";

    if(!data || data.length === 0){
        $("#userTable tbody").html("<tr><td colspan='5'>No Users Found</td></tr>");
        return;
    }

    data.forEach(user => {
        html += `
        <tr>
            <td>${user.UserId}</td>
            <td>${user.UserName}</td>
            <td>${user.Email}</td>
            <td>${user.PhoneNo}</td>
            <td>${user.isAdmin ? "Yes" : "No"}</td>
        </tr>
        `;
    });

    $("#userTable tbody").html(html);
}
DisplayUsers(FetchAllUsers());