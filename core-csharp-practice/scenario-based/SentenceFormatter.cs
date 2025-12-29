using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text; // System.Text is used for StringBuilder
using System.Threading.Tasks;

// This program takes a poorly formatted paragraph and corrects it by:
// removing extra spaces
// ensuring exactly one space after punctuation(. ? !),
// and capitalizing the first letter of every sentence.

namespace BridgeLabzTraining.csharp_extras
{
    internal class SentenceFormatter
    {
        static string FormatParagraph(string inputText)
        {
            // If input is null, there is nothing to format
            if (inputText == null)
            {
                return "";
            }

            int textLength = inputText.Length;

            // Character array used to build the final formatted result
            // Size is kept larger to safely handle added spaces
            char[] formattedChars = new char[textLength * 2];
            int resultIndex = 0;

            // This flag tells us whether the next letter should start a new sentence
            bool startOfSentence = true;

            // This flag helps us avoid adding multiple spaces in a row
            bool previousWasSpace = true;

            // Process the input text character by character
            for (int i = 0; i < textLength; i++)
            {
                char currentChar = inputText[i];

                // Handle spaces: allow only a single space at a time
                if (currentChar == ' ')
                {
                    if (!previousWasSpace)
                    {
                        formattedChars[resultIndex++] = ' ';
                        previousWasSpace = true;
                    }
                    continue;
                }

                // Current character is not a space anymore
                previousWasSpace = false;

                // Capitalize the first letter of a sentence manually (ASCII logic)
                if (startOfSentence && currentChar >= 'a' && currentChar <= 'z')
                {
                    currentChar = (char)(currentChar - 32); // convert to uppercase
                    startOfSentence = false;
                }
                else if (startOfSentence && currentChar >= 'A' && currentChar <= 'Z')
                {
                    startOfSentence = false;
                }

                // Add the character to result
                formattedChars[resultIndex++] = currentChar;

                // Check for sentence-ending punctuation
                if (currentChar == '.' || currentChar == '!' || currentChar == '?')
                {
                    // The next letter should start a new sentence
                    startOfSentence = true;

                    // Ensure exactly one space after punctuation
                    if (i + 1 < textLength && inputText[i + 1] != ' ')
                    {
                        formattedChars[resultIndex++] = ' ';
                        previousWasSpace = true;
                    }
                }
            }

            // Remove trailing space if it exists
            if (resultIndex > 0 && formattedChars[resultIndex - 1] == ' ')
            {
                resultIndex--;
            }

            // Create final character array with exact size
            char[] finalText = new char[resultIndex];
            for (int i = 0; i < resultIndex; i++)
            {
                finalText[i] = formattedChars[i];
            }

            // Convert character array to string and return
            return new string(finalText);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a paragraph to format:");
            string userInput = Console.ReadLine()!;

            string formattedOutput = FormatParagraph(userInput);

            Console.WriteLine("\nFormatted Paragraph:");
            Console.WriteLine(formattedOutput);
        }
    }
}
