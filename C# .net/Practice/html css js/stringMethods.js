let str = "hellow world how are you   ";
console.log("slicing the string  :: "+ str.slice(1,10));
console.log("converting a string into uppercase  ::  "+str.toUpperCase());
console.log("length of the string  ::  "+str.length);
console.log("character at 9th index   :: "+str.charAt(9));
console.log("character code of character at 9th index  ::  "+str.charCodeAt(9));
console.log("using substr  ::  "+str.substr(10,15));
console.log("Index of o is   ::  "+str.indexOf('o'));
console.log("last index of o is  "+str.lastIndexOf('o'));
console.log("replacing world with developer then string is   :::   "
    +str.replace('world',"developer"));
console.log("removing empty space from string from start and end  :: "
    + str.trim());
let str2 ='i am fine what about your'
let str3 = str.concat(str2);
console.log("concating 2 strings into 3rd string  :::   "+str3);
console.log("spliting the 3rd string  ::  "+str3.split(" "));
console.log("");
console.log("================= reverse of a string ============");
console.log("reversing a string ");
console.log(str3.split("").reverse().join(""));
console.log("================= count occurance of character in a string ============");
let occurArray =[];
for(let i=0;i<str.length;i++){
    let indexChar= occurArray.findIndex(obj=>obj.value==str[i])
    if(indexChar== -1){
        occurArray.push({"value":str[i],"count":1});
    }else{
        occurArray[indexChar].count++;
    }
}
for (obj of occurArray){
    console.log(`character : ${obj.value} , count ${obj.count}`)
}

let c=str3.split(" ").map(c=>c.charAt(0).toUpperCase()+c.slice(1)).join(" ");
console.log(c);

let myarr=["hi","how","who","what","when"];

console.log(...myarr);

