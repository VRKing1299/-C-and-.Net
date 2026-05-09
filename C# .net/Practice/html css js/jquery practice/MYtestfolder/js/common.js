//apis
let usersApi="http://localhost:56450/api/User";
let productsApi ="http://localhost:56450/api/Products"
let categoryApi ="http://localhost:56450/api/Category"
let cartApi ="http://localhost:56450/api/Cart";
let orderApi="http://localhost:56450/api/Order"



//*function to check user logged in
// $(document).ready(() => {
let user=JSON.parse(localStorage.getItem("User"));
console.log(user)
if(!user){
    $("header").html(`
        <nav>
            <h2>Family Mart</h2>
            <ul>
                <li><a href="Index.html">Home</a></li>
                <li><a href="Products.html">Products</a></li>
                <li><a href="LogIn.html">Cart</a></li>
                <li class="LogIn"><a href="LogIn.html">LogIn</a></li>
            </ul>
        </nav>
    `);
}else if(user.isAdmin){
    $("header").html(`
        <nav>
            <h2>Family Mart</h2>
            <ul>
                <li><a href="Index.html">Home</a></li>
                <li><a href="Products.html">Products</a></li>
                <li><a href="DisplayOrder.html">view Orders</a></li>
                <li><a href="UserManager.html">view Users</a></li>
                <li><a href="ProductManager.html">Product Manager</a></li>
                <li><a href="Cart.html">Cart</a></li>
                <li class="LogOut"><a href="Index.html">LogOut</a></li>
            </ul>
        </nav>
    `);
}else{
    $("header").html(`
        <nav>
            <h2>Family Mart</h2>
            <ul>
                <li><a href="Index.html">Home</a></li>
                <li><a href="Products.html">Products</a></li>
                <li><a href="Cart.html">Cart</a></li>
                <li class="LogOut"><a href="Index.html">LogOut</a></li>
            </ul>
        </nav>
    `);
}

$(".LogOut").on("click",()=>{
    localStorage.removeItem("User");
    window.location.href="Index.html"
}) 
// });


//*function to fetch all the products
function FetchAllProducts(){
    let data;
    $.ajax({
        url:productsApi,
        type:"GET",
        async:false,

        success:(response)=>{
            data=response;
        },

        error:(err)=>{
            console.log(err);
        }
    })
    return data
}

//* function to fetch users
function FetchAllUsers(){
    let data;
    $.ajax({
        url:usersApi,
        type:"GET",
        async:false,

        success:(response)=>{
            data=response;
        },

        error:(err)=>{
            console.log(err);
        }
    })
    return data
}

//* function to get all the cart items using user id
function GetCartItems(){
    let user = JSON.parse(localStorage.getItem("User"));
    let data;
    $.ajax({
        url:`${cartApi}/${user.UserId}`,
        type:"GET",
        async:false,

        success:(response)=>{
            data=response;
        },

        error:(err)=>{
            console.log(err);
        }
    })
    return data
}

//*function to updat cart item quantity
function GetProduct(prodid){
    let data;
    $.ajax({
        url: `${productsApi}/product/${prodid}`,
        type: "Get",
        async:false,
        
        success: (res) => {
            data=res
        },
        error: (err) => {
            console.log(err);
        }
    });
    return data
}

//*function to display all orders
function DisplayOrders(data){
    let html = "";

    if(!data || data.length === 0){
        $(".bill-container").html("<h3>No Orders Found</h3>");
        return;
    }

    data.forEach(order => {

        let itemsHTML = "";

        order.OrderItems.forEach(item => {
            let total = item.Quantity * item.PriceAtPurchase;

            itemsHTML += `
            <tr>
                <td>${item.ProdName}</td>
                <td>${item.Quantity}</td>
                <td>₹${item.PriceAtPurchase}</td>
                <td>₹${total}</td>
            </tr>
            `;
        });

        html += `
        <div class="bill-card">

            <div class="bill-header">
                <p><strong>Order ID:</strong> ${order.OrderId}</p>
                <p><strong>Date:</strong> ${new Date(order.OrderDate).toDateString()}</p>
            </div>

            <table class="bill-table">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Qty</th>
                        <th>Price</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    ${itemsHTML}
                </tbody>
            </table>

            <div class="bill-total">
                Total Amount: ₹${order.TotalAmount}
            </div>

        </div>
        `;
    });

    $(".bill-container").html(html);
}