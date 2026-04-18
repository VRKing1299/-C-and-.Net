//? click event
// $("body").click((e)=>{
//     console.log("clicked on body");
// })

// $("form").click(()=>{
//     console.log("form click");
// })

// $(".btn").click((e)=>{
//     e.preventDefault();
//     console.log("btn clicked");
// })


//?double click
// $("form").dblclick((e)=>{
//     e.preventDefault();
//     console.log("form double clicked");
// })


//?change
$("#name").change((e)=>{
    e.preventDefault();
    console.log($("#name").val())
    $(".dispName").text($("#name").val());
});

$("#phno").change((e)=>{
    e.preventDefault();
    console.log($("#phno").val())
    $(".dispPhno").text($("#phno").val());
});

$("input[name='gender']").change(()=>{
    let sel = $("input[name='gender']:checked").val();
    console.log(sel);
})

// let lang=[];
// $("input[name='lang']").change(()=>{
//     let sel = $("input[name='lang']:checked").val();
//     lang.push(sel);
//     let sel2 = $("input[name='lang']:not(:checked)").val();
//     let ind = lang.indexOf(sel2);
//     if(ind != -1){
//         lang.splice(ind,1);
//     }
//     console.log(lang);

// })

$("input[name='lang']").change(() => {
    let lang = [];

    $("input[name='lang']:checked").each(function () {
        lang.push($(this).val());
    });

    console.log(lang);
    $(".dispLanguages").text(lang.join(", "));
});