function asynctime(){
    console.log("1");
    console.log("2");
    console.log("3");
    setTimeout(()=>{
        console.log("time out");
    },5000)
    console.log("4");
    console.log("5");
    console.log("6");
}

function anotherFunc(){
    console.log("this is another function than time out")
}

asynctime()
anotherFunc()