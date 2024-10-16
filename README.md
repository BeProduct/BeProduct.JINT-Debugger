# BeProduct JINT Debugger

JINT Debugger is an application designed to facilitate debugging of BeProduct Workflow JavaScript code. It enables JavaScript execution, provides debugging capabilities, manages JavaScript file operations, and assists in handling and analyzing JavaScript errors.

## Project Structure

The project is structured as follows:

- `JintDebugger/`: Main project directory
  - `Program.cs`: Entry point of the application
  - `JintDebugger.csproj`: Project file containing configuration and dependencies
  - `bin/`: Contains compiled binaries
  - `obj/`: Contains intermediate build files
  - `test-scripts/`: Directory containing JavaScript test files
    - `error_test.js`
    - `js_example.js`
    - `test_data.json`
    - `test_file_operations.js`
    - `test_output.txt`

## Dependencies

The project depends on the following libraries:

- Jint: JavaScript interpreter for .NET
- Acornima: Likely used for JavaScript parsing or analysis

## Features

While the exact features are not apparent from the file structure alone, based on the project name and dependencies, JintDebugger likely offers the following capabilities:

1. Running JavaScript code within a .NET environment
2. Debugging JavaScript code
3. File operations related to JavaScript files
4. Handling and analyzing JavaScript errors

## Getting Started

There are two ways to run JintDebugger:

### Using dotnet run

1. Ensure you have .NET 8.0 SDK installed on your system.
2. Clone this repository.
3. Navigate to the JintDebugger directory.
4. Run the application using `dotnet run`.

### Using the executable

1. Navigate to the directory containing the executable:

2. Run the executable with a test script:
   ```
   dotnet run --project JintDebugger.csproj -- test-scripts\test_file_operations.js  
   ```
   or
   ```
   cd bin\Debug\net8.0
   ```
   ```
   .\JintDebugger.exe ..\..\..\test-scripts\test_file_operations.js
   ```

Note: The above command assumes you're running from the executable's directory and uses a relative path to the test script. Adjust the path if necessary.

## Test Scripts

The `test-scripts/` directory contains various JavaScript files that can be used to test the functionality of JintDebugger:

- `error_test.js`: Likely contains JavaScript code to test error handling
- `js_example.js`: An example JavaScript file
- `test_file_operations.js`: Tests file operation capabilities
- `test_data.json`: JSON data file, possibly used in tests

## Contributing

To contribute to this project, please follow these steps:

1. Fork the repository
2. Create a new branch for your feature
3. Commit your changes
4. Push to your branch
5. Create a new Pull Request

## License

[Include license information here]

## Contact

For any questions or concerns, please contact BeProduct at support@beproduct.com.


