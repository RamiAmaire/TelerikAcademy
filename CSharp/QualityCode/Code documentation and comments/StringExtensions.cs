namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class provides numerous extensions for the string object.
    /// First there are methods witch convert the given 
    /// string input into something else like integer, boolean
    /// and MD5 hash.
    /// Special converting methods can also make a bulgarian
    /// version of the input. In extension to the bulgarian implementation
    /// there are also methods that convert the input into latin.
    /// The class also includes methods which capitalize the first letter,
    /// get string between indexes, get file's extension and so on..
    /// </summary>
    public static class StringExtensions
    {
        #region The following methods convert the input into something else.
        
        /// <summary>
        /// This method converts string input to MD5 hash function.
        /// (MD5 is used in cryptography and is a powerful way
        ///  to protect your data)
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns the string input in hexadecimal format.
        /// </returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("X"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// This method converts the string input into boolean variable if
        /// the given string contains one of the following key words:
        /// "true", "ok", "yes", "1", "да".
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns boolean variable (true, false).
        /// </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// This method converts the string input into short variable if
        /// it can be parsed, else it throws an exception.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns short value.
        /// </returns>
        public static short ToShort(this string input)
        {
            short shortValue = 0;
            short.TryParse(input, out shortValue);

            return shortValue;
        }

        /// <summary>
        /// This method converts the string input into integer variable if
        /// it can be parsed, else it throws an exception.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns integer value.
        /// </returns>
        public static int ToInteger(this string input)
        {
            int integerValue = 0;
            int.TryParse(input, out integerValue);

            return integerValue;
        }

        /// <summary>
        /// This method converts the string input into long variable if
        /// it can be parsed, else it throws an exception.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns long value.
        /// </returns>
        public static long ToLong(this string input)
        {
            long longValue = 0;
            long.TryParse(input, out longValue);

            return longValue;
        }

        /// <summary>
        /// This method converts the string input into DateTime object if
        /// it can be parsed, else it throws an exception.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns DateTime object.
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue = new DateTime();
            DateTime.TryParse(input, out dateTimeValue);

            return dateTimeValue;
        }

        /// <summary>
        /// This method converts the bulgarian input into latin
        /// in order to be validated correctly. If the input is
        /// null, exception is thrown.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns latin representation of 
        /// the initial input.
        /// </returns>
        public static string ToValidUsername(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null.");
            }

            input = input.ConvertBulgarianToLatinLetters();

            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// This method converts the bulgarian file name input 
        /// into latin in order to be validated correctly. If the
        /// input is null, exception is thrown.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns latin representation of 
        /// the initial file name input.
        /// </returns>
        public static string ToValidLatinFileName(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null.");
            }

            input = input.Replace(" ", "-").ConvertBulgarianToLatinLetters();

            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// This method converts the string input into byte array.
        /// If the input is null, exception is thrown.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns a byte array.
        /// </returns>
        public static byte[] ToByteArray(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null.");
            }

            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(
                input.ToCharArray(),
                0,
                bytesArray,
                0,
                bytesArray.Length);

            return bytesArray;
        }

        /// <summary>
        /// This method converts the bulgarian typed input into it's
        /// latin representation by looping through the bulgarian letters
        /// and replacing each to it's latin equivalent.
        /// If the input is null, exception is thrown.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns latin representation of the input string.
        /// </returns> 
        public static string ConvertBulgarianToLatinLetters(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null.");
            }

            var bulgarianLetters = new[]
                {
                    "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л",
                    "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч",
                    "ш", "щ", "ъ", "ь", "ю", "я"
                };

            var latinRepresentationsOfBGLetters = new[]
                {
                    "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                    "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                    "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                };

            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(
                    bulgarianLetters[i],
                    latinRepresentationsOfBGLetters[i]);

                input = input.Replace(
                    bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBGLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// This method converts the latin typed input into it's
        /// bulgarian representation by looping through the latin letters
        /// and replacing each to it's bulgarian equivalent.
        /// If the input is null, exception is thrown.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns>
        /// The method returns bulgarian representation of the input string.
        /// </returns> 
        public static string ConvertLatinToBulgarianLetters(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null.");
            }

            var latinLetters = new[]
                {
                    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
                    "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
                    "y", "z"
                };

            var bulgarianRepresentationOfLatinLetters = new[]
                {
                    "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                    "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                    "в", "ь", "ъ", "з"
                };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(
                    latinLetters[i],
                    bulgarianRepresentationOfLatinLetters[i]);

                input = input.Replace(
                    latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinLetters[i].ToUpper());
            }

            return input;
        }

        #endregion

        #region The following methods retrun a substring of the input.

        /// <summary>
        /// This method gets the first characters of the string
        /// input, by given integer number. For example from the
        /// input "visual" with chars count 3, the result will be :
        /// "vis".
        /// If the input is null or the chars count number is out 
        /// of range exception is thrown.
        /// </summary>
        /// <param name="input">The input from which to get the chars</param>
        /// <param name="charsCount">The number of chars to return</param>
        /// <returns>
        /// The method returns a substring of the initial input.
        /// </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null");
            }

            if (charsCount < 0 || charsCount >= input.Length)
            {
                throw new ArgumentOutOfRangeException(
                    "Chars count is out of range");
            }

            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// This method gets the file extension of the initial file name.
        /// If the input is null exception is thrown.
        /// </summary>
        /// <param name="fileName">The file name from which to get the extension
        /// </param>
        /// <returns>
        /// The method returns the file extension of the input.
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(
                    "File name cannot be null");
            }

            string[] fileParts = fileName.Split(
                new[] { "." },
                StringSplitOptions.None);

            if (fileParts.Count() == 1 ||
                string.IsNullOrEmpty(fileParts.Last()))
            {
                throw new ArgumentException(
                    "This file has no extension.");
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// This method returns substring of the input with given
        /// start and end strings and start from index. Exception 
        /// is thrown if the input or the start, end strings are null.
        /// Throwing exception is also possible if the start from index
        /// is out of the range of the input.
        /// </summary>
        /// <param name="input">The input from which to get the substring
        /// </param>
        /// <param name="startString">The substring from which to begin</param>
        /// <param name="endString">The substring at the end</param>
        /// <param name="startFrom">The index from where to start</param>
        /// <returns>
        /// The method returns a substring from the input.
        /// </returns>
        public static string GetStringBetween(
            this string input,
            string startString,
            string endString,
            int startFrom = 0)
        {
            // Checking for unexpected special cases.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cannot be null");
            }

            if (!input.Contains(startString))
            {
                throw new ArgumentException(
                    "Input does not contain the given start string.");
            }

            if (!input.Contains(endString))
            {
                throw new ArgumentException(
                    "Input does not contain the given end string.");
            }

            if (startFrom < 0 || startFrom >= input.Length)
            {
                throw new ArgumentOutOfRangeException(
                    "Start from index is out of input's range.");
            }

            int startPosition = input.IndexOf(
                startString,
                startFrom,
                StringComparison.Ordinal) + startString.Length;

            int endPosition = input.IndexOf(
                endString,
                startPosition,
                StringComparison.Ordinal);

            return input.Substring(startPosition, endPosition - startPosition);
        }

        #endregion

        /// <summary>
        /// This method capitalizes the first letter of the input.
        /// If the string is null, exception is thrown
        /// </summary>
        /// <param name="input">The input which first letter will be
        /// capitalized
        /// </param>
        /// <returns>
        /// The method returns string with capitalized first letter.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            // If the input is null, exception is thrown.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cannot be null");
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// This method returns the content type of the given
        /// file extension. If the string is null, exception is thrown
        /// </summary>
        /// <param name="fileExtension">The fileExtension from which we return
        /// content type.
        /// </param>
        /// <returns>
        /// The method returns content type as string.
        /// </returns>
        public static string ToContentType(this string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                throw new ArgumentNullException("File extension cannot be null.");
            }

            var fileExtensionToContentType = new Dictionary<string, string>
                {
                    { "jpg", "image/jpeg" },
                    { "jpeg", "image/jpeg" },
                    { "png", "image/x-png" },
                    {
                        "docx",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                    },
                    { "doc", "application/msword" },
                    { "pdf", "application/pdf" },
                    { "txt", "text/plain" },
                    { "rtf", "application/rtf" }
                };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }
    }
}
