using System;

// TODO: Functions can provide default values for their parameters
void PrintWithPrefix(string thestr, string prefix = "")
{
    Console.WriteLine($"{prefix} {thestr}");
}

// TODO: Test the default parameters
PrintWithPrefix("Hello There!");
PrintWithPrefix("Hello There!", ">: ");

// TODO: Call with named params
PrintWithPrefix(prefix: "% ", thestr: "Hello There!");
