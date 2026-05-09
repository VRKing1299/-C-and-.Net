namespace index {
    export namespace typeScriptProg {
        export class Basicprogram {
            addition(num1: number, num2: number): void {
                let functionName: string = "Basicprogramming";
                try {
                    if (this.isValid(num1) && this.isValid(num2)) {
                        let total = num1 + num2;
                        this.displayMessage(
                            "Sum of the two numbers is: " + total,
                        );
                    } else {
                        this.displayMessage("please enter A valid number");
                    }
                } catch (ex: any) {
                    this.throwError(functionName, ex);
                }
            }

            isValid(inp: any): boolean {
                let functionName = "isValid";
                let isvalid = false;
                try {
                    if (
                        inp != null &&
                        inp != undefined &&
                        inp != "undefined" &&
                        inp != "null" &&
                        inp != ""
                    )
                        isvalid = true;
                } catch (ex: any) {
                    this.throwError(functionName, ex);
                }
                return isvalid;
            }

            throwError(functionName: string, error: any) {
                let funcName = "throwError";

                try {
                    let msg: string =
                        functionName +
                        ", Error : " +
                        (error.message || error.description);
                    this.displayMessage(msg);
                } catch (ex: any) {
                    let message: string =
                        funcName +
                        ", Error : " +
                        (error.message || error.description);
                }
            }

            displayMessage(message: string) {
                try {
                    if (this.isValid(message)) {
                        alert(message);
                    }
                } catch (ex: any) {
                    alert(ex.message);
                }
            }
        }
    }
}

const addButton = document.getElementById("Add");
addButton?.addEventListener("click", (e) => {
    e.preventDefault();
    let num1 = (<HTMLInputElement>document.getElementById("num1")).value;
    let num2 = (<HTMLInputElement>document.getElementById("num2")).value;
    let program = new index.typeScriptProg.Basicprogram();
    program.addition(parseInt(num1), parseInt(num2)); // ✅ parse to numbers
});
