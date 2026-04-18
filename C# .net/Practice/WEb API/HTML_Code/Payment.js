var userId = sessionStorage.getItem('userid'); 

$(document).on("click", "#btnPay", (event) => {
    alert("in btnPay");
    let cardno = $("#cardNumber").val();
    alert(cardno);
    let cvv = $("#cvv").val();
let billid;
    // Validations for card and user
    if (cardno !== "" && cvv !== "") {
        if (cardno.length === 16) {
            if (cvv.length === 3) {
                // Insert new record in bill table
                $.ajax({
                    type: "POST",
                    url: "http://localhost:60939/api/Bill",
                    data: JSON.stringify({ "UserID": userId }),
                    contentType: "application/json",
                    success: (response) => {
                        console.log(response);
                        alert("in Bill table");

                        // Get the latest record from the bill table
                        $.ajax({
                            type: "GET",
                            url: `http://localhost:60939/api/Bill/GetByUser/${userId}`,
                            success: (response) => {
                                console.log(response); // Ensure response is what you expect
                                if (response && response.length > 0) {
                                    billid = response[0].BillID; // Adjust based on actual response format
                                    alert(billid);
                                } else {
                                    alert("No bill found for the given user.");
                                }
                                //get the cart details of the particular user
                                $.ajax({
                                    type: "GET",
                                  
                                    url: `http://localhost:60939/api/Cart/GetCartByUserID/${userId}`,
                                    success: (response) => {
                                        console.log(response);
                                        alert("in cart table")
                                        alert("fetch bt userid")
                                        for (let i = 0; i < response.length; i++) {
                                            let cartitem = response[i];
                                            //post cart items in billdetails table
                                            $.ajax({
                                              
                                                type: "POST",
                                                url: "http://localhost:60939/api/BillDetail/Add",
                                                data: 
                                                {
                                                    "BillID": billid,
                                                    "ProdID": cartitem.ProdID,
                                                    "BillQty": cartitem.CartQty,
                                                    "BillAmt": cartitem.Price
                                                },
                                                
                                                success: (response) => {
                                                   
                                                    //update the qty in product table
                                                    $.ajax({
                                                        type: "PUT",
                                                        url: "http://localhost:60939/api/Product/" + cartitem.ProdID,
                                                        data: JSON.stringify({
                                                            ProdID: cartitem.ProdID,
                                                            ProdName: cartitem.ProdName,
                                                            ProdImg: cartitem.ProdImg,
                                                            ProdDsc: cartitem.ProdDsc,
                                                            ProdQty: cartitem.CartQty, // Assuming CartQty is the updated quantity
                                                            ProdPrice: cartitem.ProdPrice,
                                                            categoryId: cartitem.categoryId
                                                        }),
                                                        contentType: "application/json",
                                                        success: (response) => {
                                                            console.log(response);
                                                        },
                                                        error: (err) => {
                                                            console.log(err);
                                                        }
                                                    });
                                                    
                                                }, error: (err) => {
                                                    alert(err)
                                                    console.log(err);
                                                }
                                            })
                                        }
                                        //empty the cart
                                        $.ajax({
                                            type: "DELETE",
                                            url: "http://localhost:60939/api/Cart/GetCartByUserID" + userId,
                                            success: (response) => {
                                                alert("Payment Successful")
                                                location.href = "./index.html";
                                            }, error: (err) => {
                                                alert(err)
                                                console.log(err);
                                            }
                                        })
                                    }, error: (err) => {
                                        alert(err)
                                        console.log(err);
                                    }
                                })
                            }, error: (err) => {
                                alert(err)
                                console.log(err);
                            }
                        })
                    }, error: (err) => {
                        alert(err)
                        console.log(err);
                    }
                })
            }
            else {
                alert("Invalid Cvv");
            }
        }
        else {
            alert("Card Number should be 16 digits You have entered : " + cardno.length + " digits");
        }
    }
    else {
        alert("Please enter values in all fields");
    }
});