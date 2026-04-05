// this is used to display a pop up message  
let message = document.querySelector(".message");

function DisplayMessage(mess){
    message.innerHTML=mess;
    message.classList.add("show")

    setTimeout(()=>{
        message.classList.remove("show");
    },1000)
}
