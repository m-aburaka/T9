using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T9
{
    public static class T9Converter
    {
        private static readonly char[][] Map = {
            new[] {' '},
            new char[0],
            new[] {'a', 'b', 'c'},
            new[] {'d', 'e', 'f'},
            new[] {'g', 'h', 'i'},
            new[] {'j', 'k', 'l'},
            new[] {'m', 'n', 'o'},
            new[] {'p', 'q', 'r', 's'},
            new[] {'t', 'u', 'v'},
            new[] {'w', 'x', 'y', 'z'},
        };

        /// <summary>
        /// Converts string of character to string of keys which user have to press on the keyboard
        /// </summary>
        public static string ToKeys(string input)
        {
            if (input.Length < 1 || input.Length > 1000)
                throw new ArgumentException("Input length should be between 1 and 1000");

            if (!Regex.IsMatch(input, "^[a-z ]*$"))
                throw new ArgumentException("Only lower-case characters of latin alphabet and space are allowed");

            var output = string.Empty;
            foreach (var c in input)
            {
                // find the key and character position in that key
                var keyIndex = Array.FindIndex(Map, a => a.Any(character => character == c));
                var characterIndex = Array.FindIndex(Map[keyIndex], letter => letter == c);
                // repeat character N times, where N is it's position
                for (int i = 0; i < characterIndex + 1; i++)
                    output += keyIndex;
                output += " ";
            }
            return output.TrimEnd();
        }
    }
}