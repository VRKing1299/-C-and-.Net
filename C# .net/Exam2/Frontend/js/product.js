

//*function to diaplay fetched product
function DisplayProduct(data){
    let html=""
    data.forEach(p=>{
        html += `
        <div class="product-card">
            <img src="${p.ImageUrl}" alt="${p.ProdName}">
            <p class="catLabel">${p.CategoryName}</p>
            <h3>${p.ProdName}</h3>
            <p>₹${p.Price}</p>
            <button onclick="AddToCart(${p.ProdId})">Add to Cart</button>
        </div>
        `;
    })
    $(".product-container").html(html)
}

//fetching and displaying the category
$.ajax({
    url:categoryApi,
    type:"GET",

    success:(response)=>{
        if(!response){
            alert("error fetching category data");
            return;
        }
        
        let html=`<option value="all">--Select Category--</option>`
        response.forEach((item)=>{
            html+=`<option value="${item.CategoryId}">${item.CategoryName}</option>`
        })
        $("#category").html(html);
    },

    error: (err) => {
        console.log(err);
    }
})

//default product display
let productsData=FetchAllProducts();
DisplayProduct(productsData)

//filtering and displaying the products based on category
$("#category").on("change",(e)=>{
    let catId= e.target.value;
    let productsData=FetchAllProducts();
    if("all"==catId){
        DisplayProduct(productsData);
    }else{
        let filteredData = productsData.filter((item)=> item.CategoryId==catId);
        DisplayProduct(filteredData)
    }
})

//function to Add Product to Cart
function AddToCart(pid){
    let user = JSON.parse(localStorage.getItem("User"));
    if(!user){
        alert("Please login first");
        return;
    }
    let cart = GetCartItems();


    //fetching product to check quantity
    let prod= GetProduct(pid);
    if(!prod){
        alert("Error fetching product");
        return;
    }
    if(prod.StockQuantity<1){
        alert("Not enough stock available!");
        return;
    }

    // check if product already exists in cart
    let item = cart.find(c => c.ProdId == pid);

    if(item){
        // update quantity
        let updatedItem = {
            CartItemId: item.CartItemId,
            Quantity: item.Quantity + 1
        };

        if(prod.StockQuantity<updatedItem.Quantity){
            alert("Not enough stock available");
            return;
        }

        $.ajax({
            url: cartApi,
            type: "PUT",
            contentType: "application/json",
            data: JSON.stringify(updatedItem),
            success: (res) => {
                console.log(res)
                alert(resp);
            },
            error: (err) => {
                console.log(err);
            }
        });

    } else {
        // add new item
        let newItem = {
            UserId: user.UserId,
            ProdId: pid
        };

        $.ajax({
            url: cartApi,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(newItem),
            success: (res) => {
                alert(res);
            },
            error: (err) => {
                console.log(err);
            }
        });
    }
}