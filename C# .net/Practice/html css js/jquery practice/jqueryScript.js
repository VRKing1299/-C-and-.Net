//? after and before
// $("#div1").after("<div id='#new'> new element after div1 element</div>");
// $("#div1").before("<div id='#new'>new element before div1 element</div>");
// $("#div1").before("#p1") //! does not work


//?  insert after and insert before
// $("#p1").insertAfter("#div1"); 
// $("<div id='#new'>new element after div1 element</div>").insertAfter("#div1");//! can insert a whole new element after the current element
// $("#p2").insertBefore("#div1");


//?   append  and appendto
// $("#div1").append("<span> this is appended span tag</span>");//!appends a new tag in the existing element
// $("span").appendTo("#div1"); //!appends exiting tag to another element


//?   prepend  and prependto
// $("#div1").prepend("<span> this is appended span tag</span>");//!prepends a new tag in the existing element at top
// $("span").prependTo("#div1"); //!prepends exiting tag to another element at the top


//? text and html
// let txt = $("#div1").text()//!gets the text without html
// console.log(txt);

// let txtWithHtml = $("#div1").html()//!gets the text with html
// console.log(txtWithHtml);

// $("#div1").text("hellow world")//! updates inner text of the element

// $("#div1").html("<div id'new'> this is new div</div>")//! updates inner html of the element


//? remove and empty
// $("#div1").empty();
// $("p").empty();//!removes content of element tag stays

// $("#div1").remove();
// $("p").remove();//!removes the whole selected tag


//? wrap and wrap all
// $("p").wrap("<div class='new'></div>"); //!gives div for each p element
// $("p").wrapAll("<div class='new'></div>"); //! wraps every p element in one single div

//? replace with
// $("p").replaceWith("div")
// $("p").replaceWith("<div class='new'> new div</div>")


//? keypress
$("body").keypress(function(e){
    console.log("Keypress : "+ e.key)
})
