'use strict'
let date= new Date();
console.log(date); //Thu Apr 02 2026 17:32:21 GMT+0530 (India Standard Time)
console.log(date);

console.log("=======================================================");
let date2 =  new Date("2025-04-03"); //Thu Apr 03 2025 05:30:00 GMT+0530 (India Standard Time)  // From string
let date3 =  new Date(2025, 3, 3); //Thu Apr 03 2025 00:00:00 GMT+0530 (India Standard Time)   // Year, Month (0-based), Day
let date4 =  new Date(0);// Thu Jan 01 1970 05:30:00 GMT+0530 (India Standard Time) not imp   // Epoch time
console.log(date2);
console.log(date3);
console.log(date4);

console.log("")
console.log("=======================================================");

let d = new Date();
console.log(d.toLocaleDateString());
console.log(d.toLocaleTimeString());

console.log("")
console.log("=======================================================");
console.log(d.getTime());
console.log(d.getDay());
console.log(d.getDate());
console.log(d.getMonth());
console.log(d.getFullYear());
console.log(d.getHours());
console.log(d.getSeconds());
console.log(d.getMilliseconds());

console.log("")
console.log("=======================================================");
console.log(d.setFullYear(2030));
console.log(d.setMonth(0)); // January
console.log(d.setDate(15));

console.log("")
console.log("=======================================================");
console.log(d.toLocaleDateString());
console.log(d.toLocaleTimeString());
// console.log(d.getTime());
// console.log(d.getDay());
// console.log(d.getDate());
// console.log(d.getMonth());
// console.log(d.getFullYear());
// console.log(d.getHours());
// console.log(d.getSeconds());
// console.log(d.getMilliseconds());
// console.log(1<2<3);
// console.log(3>2>1);