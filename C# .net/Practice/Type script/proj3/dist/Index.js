"use strict";
var index;
(function (index) {
    let typeScriptProg;
    (function (typeScriptProg) {
        class Basicprogram {
            addition(num1, num2) {
                let functionName = "Basicprogramming";
                try {
                    if (this.isValid(num1) && this.isValid(num2)) {
                        let total = num1 + num2;
                        this.displayMessage("Sum of the two numbers is: " + total);
                    }
                    else {
                        this.displayMessage("please enter A valid number");
                    }
                }
                catch (ex) {
                    this.throwError(functionName, ex);
                }
            }
            isValid(inp) {
                let functionName = "isValid";
                let isvalid = false;
                try {
                    if (inp != null &&
                        inp != undefined &&
                        inp != "undefined" &&
                        inp != "null" &&
                        inp != "")
                        isvalid = true;
                }
                catch (ex) {
                    this.throwError(functionName, ex);
                }
                return isvalid;
            }
            throwError(functionName, error) {
                let funcName = "throwError";
                try {
                    let msg = functionName +
                        ", Error : " +
                        (error.message || error.description);
                    this.displayMessage(msg);
                }
                catch (ex) {
                    let message = funcName +
                        ", Error : " +
                        (error.message || error.description);
                }
            }
            displayMessage(message) {
                try {
                    if (this.isValid(message)) {
                        alert(message);
                    }
                }
                catch (ex) {
                    alert(ex.message);
                }
            }
        }
        typeScriptProg.Basicprogram = Basicprogram;
    })(typeScriptProg = index.typeScriptProg || (index.typeScriptProg = {}));
})(index || (index = {}));
const addButton = document.getElementById("Add");
addButton === null || addButton === void 0 ? void 0 : addButton.addEventListener("click", (e) => {
    e.preventDefault();
    let num1 = document.getElementById("num1").value;
    let num2 = document.getElementById("num2").value;
    let program = new index.typeScriptProg.Basicprogram();
    program.addition(parseInt(num1), parseInt(num2)); // ✅ parse to numbers
});
//# sourceMappingURL=Index.js.map