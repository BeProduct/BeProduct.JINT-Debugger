// This is a test file with intentional errors

// Error 1: Undefined variable
//log(undefinedVariable);

// Error 2: Syntax error
if (true) {
    log("This is fine");
} else {
    log("This is also fine")
}

// Error 3: Type error
let number = 5;
number.toUpperCase();

// This line won't be reached due to the errors above
console.log("End of script");
