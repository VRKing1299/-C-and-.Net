

function LoadProductsDropdown() {
    let products = FetchAllProducts();
    let html = "<option value=''>Select Product</option>";

    products.forEach(p => {
        html += `<option value="${p.ProdId}">${p.ProdName}</option>`;
    });

    $("#ddlProdId").html(html);
}

function LoadCategories() {
    $.ajax({
        url: categoryApi,
        type: "GET",
        success: function (res) {
            let html = "<option value=''>Select Category</option>";

            res.forEach(c => {
                html += `<option value="${c.CategoryId}">${c.CategoryName}</option>`;
            });

            $("#ddlCategory").html(html);
        },

        error:(resp)=>{
            console.log(resp);
        }
    });
}

LoadProductsDropdown();
LoadCategories();

//reset the form
function ResetForm() {
    $("#txtProductName").val("");
    $("#txtPrice").val("");
    $("#txtStockQuantity").val("");
    $("#ddlCategory").val("");
    $("#fileImage").val("");
    $("#fileImage").removeAttr("data-source");
    $("#btnUpdate").prop("disabled", true);
    $("#ddlProdId").val("")
}

//disable the form
function DisableForm() {
    $("#txtProductName").prop("disabled", true);
    $("#txtPrice").prop("disabled", true);
    $("#txtStockQuantity").prop("disabled", true);
    $("#ddlCategory").prop("disabled", true);
    $("#fileImage").prop("disabled", true);

    $("#btnAddProduct").prop("disabled", true);
    $("#btnUpdate").prop("disabled", true);
}

//enabling the form
function EnableForm() {
    $("#txtProductName").prop("disabled", false);
    $("#txtPrice").prop("disabled", false);
    $("#txtStockQuantity").prop("disabled", false);
    $("#ddlCategory").prop("disabled", false);
    $("#fileImage").prop("disabled", false);
    $("#btnAddProduct").prop("disabled", false);
    $("#btnDelete").prop("disabled", false);

    // update stays controlled manually
}

//*getting image path
function GetImagePath() {
    let fileInput = document.getElementById("fileImage");

    if (fileInput.files.length === 0) {
        return null;
    }

    let fileName = fileInput.files[0].name;
    $("#fileImage").attr("data-source", fileName);
    return "./Assets/Products/" + fileName;
}

//for validating inputs
function ValidateProduct(product) {
    if (!product) {
        alert("Invalid product data");
        return false;
    }

    if (product.ProdName == null || product.ProdName.trim() === "") {
        alert("Product name is required");
        return false;
    }

    if (product.Price == null || isNaN(product.Price) || product.Price <= 0 ) {
        alert("Valid price is required");
        return false;
    }

    // Category validation
    if (!product.CategoryId) {
        alert("Please select a category");
        return false;
    }

    // Stock validation
    if (product.StockQuantity == null || isNaN(product.StockQuantity) || product.StockQuantity < 0) {
        alert("Valid stock quantity is required");
        return false;
    }

    // Image validation
    if (!product.ImageUrl || product.ImageUrl.trim() === "") {
        alert("Product image is required");
        return false;
    }

    return true;
}

//=====================================================
//!displaying product on form change
$("#ddlProdId").on("change",()=>{
    let prodId = $("#ddlProdId").val();

    if (!prodId) {
        $("#btnAddProduct").prop("disabled", false);
        ResetForm();
        EnableForm();
        return;
    }

    //fetching product data
    let product = GetProduct(prodId);

    $("#txtProductName").val(product.ProdName);
    $("#txtPrice").val(product.Price);
    $("#txtStockQuantity").val(product.StockQuantity);
    $("#ddlCategory").val(product.CategoryId);
    let imgName = product.ImageUrl.split("/").pop();
    $("#fileImage").attr("data-source", imgName);

    $("#btnUpdate").prop("disabled", true);
    $("#btnAddProduct").prop("disabled", true);

    DisableForm();
})
//=====================================================
//! button enables the form to add new data
$("#btnAdd").click(()=>{
    ResetForm()
    EnableForm();
    $("#btnUpdate").prop("disabled", true);
    $("#btnAddProduct").prop("disabled", false);
})
//=====================================================
//!function to add the product
$("#btnAddProduct").click( ()=> {

    let imgPath = GetImagePath();

    let product = {
        ProdName: $("#txtProductName").val(),
        Price: parseInt($("#txtPrice").val()),
        ImageUrl: imgPath,
        StockQuantity: parseInt($("#txtStockQuantity").val()),
        CategoryId: parseInt($("#ddlCategory").val())
    };

    if(!ValidateProduct(product)){
        return
    }

    $.ajax({
        url: productsApi,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(product),
        success: function (res) {
            alert(res);
            LoadProductsDropdown();
            ResetForm();
        },

        error:(resp)=>{
            console.log(resp);
        }
    });
});
//=====================================================
//!enabling the for for editing
$("#btnEdit").click( ()=> {
    let prodId = $("#ddlProdId").val();
    if (!prodId) {
        alert("Please Select A Product")
        return;
    }
    EnableForm();
    $("#btnAddProduct").prop("disabled", true);
    $("#btnUpdate").prop("disabled", false);
});
//=====================================================
//!button to update the product
$("#btnUpdate").click(()=> {
    let prodId = $("#ddlProdId").val();
    let fileInput = document.getElementById("fileImage");
    let imgName;

    if (fileInput.files.length > 0) {
        imgName = fileInput.files[0].name;
    } else {
        imgName = $("#fileImage").attr("data-source");
    }

    let product = {
        ProdId: prodId,
        ProdName: $("#txtProductName").val(),
        Price: parseInt($("#txtPrice").val()),
        ImageUrl: "./Assets/Products/" + imgName,
        StockQuantity: parseInt($("#txtStockQuantity").val()),
        CategoryId: parseInt($("#ddlCategory").val())
    };
    // console.log(prodId);
    //validation
    if(!ValidateProduct(product)){
        return
    }

    $.ajax({
        url: productsApi,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(product),
        success: function (res) {
            alert(res);
            LoadProductsDropdown();
            ResetForm();
            $("#btnUpdate").prop("disabled", true);
        },

        error:(resp)=>{
            console.log(resp);
        }
    });
});
//=====================================================
//!function to delete the product
$("#btnDelete").click(()=> {

    let prodId = $("#ddlProdId").val();

    if (!prodId) {
        alert("Select Product");
        return;
    }

    $.ajax({
        url: `${productsApi}?id=${prodId}`,
        type: "DELETE",
        success: function (res) {
            alert(res);
            LoadProductsDropdown();
            ResetForm();
        },

        error:(resp)=>{
            console.log(resp);
        }
    });
});