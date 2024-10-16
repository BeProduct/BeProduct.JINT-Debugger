﻿using System;
using System.IO;
using Jint;
using Jint.Runtime;

class Program
{
    private static StreamWriter? debugWriter;

    static void Main(string[] args)
    {
        string debugFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug.txt");
        debugWriter = new StreamWriter(debugFilePath, false);

        try
        {
            if (args.Length == 0)
            {
                WriteDebug("Please provide a JavaScript file path as an argument.", ConsoleColor.Yellow);
                return;
            }

            string scriptPath = args[0];
            if (!File.Exists(scriptPath))
            {
                WriteDebug($"File not found: {scriptPath}", ConsoleColor.Red);
                return;
            }

            var engine = new Engine(options => options
                .AllowClr()
                .CatchClrExceptions());

            // Add the 'log' function to the JavaScript environment
            engine.SetValue("log", new Action<object>(message => WriteDebug(message?.ToString() ?? "null", ConsoleColor.Green)));

            // Add a 'debug' function for more detailed output
            engine.SetValue("debug", new Action<object>(message => 
            {
                var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                WriteDebug($"[DEBUG] {currentTime}: {message}", ConsoleColor.Cyan);
            }));

            // Add a simple 'readFile' function to replace 'fs.readFileSync'
            engine.SetValue("readFile", new Func<string, string>(filePath => 
            {
                var fullPath = Path.GetFullPath(filePath);
                WriteDebug($"[DEBUG] Reading file: {fullPath}", ConsoleColor.Cyan);
                return File.ReadAllText(filePath);
            }));

            // Add a simple 'writeFile' function to replace 'fs.writeFileSync'
            engine.SetValue("writeFile", new Action<string, string>((filePath, content) => 
            {
                var fullPath = Path.GetFullPath(filePath);
                WriteDebug($"[DEBUG] Writing to file: {fullPath}", ConsoleColor.Cyan);
                File.WriteAllText(filePath, content);
            }));

            string[] scriptLines = File.ReadAllLines(scriptPath);
            string script = string.Join(Environment.NewLine, scriptLines);

            WriteDebug($"[DEBUG] Executing script: {scriptPath}", ConsoleColor.Cyan);
            engine.Execute(script);
            WriteDebug("[DEBUG] Script executed successfully with no errors.", ConsoleColor.Green);
        }
        catch (JavaScriptException ex)
        {
            WriteDebug($"JavaScript error:", ConsoleColor.Red);
            WriteDebug($"Error: {ex.Error}", ConsoleColor.Red);
            WriteDebug($"Message: {ex.Message}", ConsoleColor.Red);
            
            int lineNumber = ex.Location.Start.Line;
            int column = Math.Max(ex.Location.Start.Column, 1); // Ensure column is at least 1
            WriteDebug($"Line: {lineNumber}, Column: {column}", ConsoleColor.Red);
            
            string[] scriptLines = File.ReadAllLines(args[0]);
            if (lineNumber > 0 && lineNumber <= scriptLines.Length)
            {
                string errorLine = scriptLines[lineNumber - 1];
                WriteDebug($"Code: {errorLine}", ConsoleColor.Red);
                WriteDebug($"      {new string(' ', column - 1)}^", ConsoleColor.Red);
            }
        }
        catch (Exception ex)
        {
            WriteDebug($"An error occurred: {ex.Message}", ConsoleColor.Red);
        }
        finally
        {
            debugWriter?.Close();
        }
    }

    private static void WriteDebug(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
        debugWriter?.WriteLine(message);
        debugWriter?.Flush();
    }
}
