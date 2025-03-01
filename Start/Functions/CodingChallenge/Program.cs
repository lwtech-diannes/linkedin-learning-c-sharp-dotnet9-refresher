// C# code​​​​​​‌‌​​‌‌​​‌‌​‌‌‌​​​​​​​​‌​‌ below
using System;
using System.Text;

// Write your answer here, and then test your code.
namespace CodingChallenge
{
    class Program
    {

        // Determine whether a string is a Palindrome
        static bool IsPalindrome(string thestr){
            // Your code goes here.

            // Ignore case by converting to upper
            thestr = thestr.ToUpper();
            StringBuilder sb = new StringBuilder();
            // Check for punctuation and whitespace, if the char is not a punctuation mark or whitespace,
            // add it to the string builder
            foreach (char c in thestr)
            {
                if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                {
                    continue;
                }
                else
                {
                    sb.Append(c);
                }
            }

            // Reverse the contents of the string builder
            String reversed = string.Empty;
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversed += sb[i];
            }

            // Convert to upper to ignore case
            // Compare the to two strings
            // String builder must be converted to a string or it will not work
            // String builder does not override Equals, so it performs a reference
            // equality check instead of comparing contents 
            reversed = reversed.ToUpper();
            if (String.Equals(sb.ToString(), reversed))
            {
                return true;
            }
        
            return false;
        }

        static void Main(string[] args) {
        // This is how your code will be called.
        // You can edit this code to try different testing cases.
        string[] teststrings = { "Hello World!", "Race car!", "Rotor", "More cowbell!", "Madam, I'm Adam." };
        int palcount = 0;
        
        foreach (string str in teststrings) {
    	bool learnerResult = IsPalindrome(str);
	    if (learnerResult)
        palcount++;
        }
        Console.WriteLine(palcount);

        }

    }
}













