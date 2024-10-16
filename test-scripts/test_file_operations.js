// Test scenario 1: Basic logging
log("Starting comprehensive test script");
debug("This is a debug message");

// Test scenario 2: Reading a text file
try {
    const fibonacciContent = readFile('JintDebugger/test-scripts/js_example.js');
    log("Successfully read js_example.js:");
    log(fibonacciContent);
} catch (error) {
    debug("Error reading js_example.js: " + error.message);
}

// Test scenario 3: Writing to a file
try {
    writeFile('JintDebugger/test-scripts/test_output.txt', 'This is a test output file.');
    log("Successfully wrote to test_output.txt");
} catch (error) {
    debug("Error writing to test_output.txt: " + error.message);
}

// Test scenario 4: Reading and parsing JSON
try {
    const jsonContent = readFile('JintDebugger/test-scripts/test_data.json');
    const jsonData = JSON.parse(jsonContent);
    log("Successfully read and parsed test_data.json:");
    log("Name: " + jsonData.name);
    log("Age: " + jsonData.age);
    log("Is Active: " + jsonData.isActive);
    log("Hobbies: " + jsonData.hobbies.join(", "));
    log("JSON data:");
    log(JSON.stringify(jsonData, null, 2));
} catch (error) {
    debug("Error reading or parsing test_data.json: " + error.message);
}

// Test scenario 5: Attempting to read a non-existent file
try {
    const nonExistentContent = readFile('JintDebugger/test-scripts/non_existent_file.txt');
    log("This should not be logged");
} catch (error) {
    debug("Expected error reading non-existent file: " + error.message);
}

// Test scenario 6: Deliberate JavaScript error
try {
    const result = nonExistentFunction();
    log("This should not be logged");
} catch (error) {
    debug("Caught deliberate JavaScript error: " + error.message);
}

// Test scenario 7: Math operations
const a = 5;
const b = 3;
log(`Math operations: ${a} + ${b} = ${a + b}, ${a} * ${b} = ${a * b}`);

// Test scenario 8: String operations
const str1 = "Hello";
const str2 = "World";
log(`String concatenation: ${str1} ${str2}`);
log(`Uppercase: ${(str1 + " " + str2).toUpperCase()}`);

log("Comprehensive test script completed");
