/**
 
Vladimir Raevsky
GeekBrains Homework Task2

 
 */

using System;
using System.Text;
using System.Text.RegularExpressions;


namespace HW5_Task2
{
    class Message
    {
        /// <summary>
        /// Private mesthod which helps to change all punctuation on spaces. We need it to separate words.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string[] FormatString(string message)
        {
            string text = "";

            char[] arr = message.ToCharArray(0, message.Length);  //new array of chars to contain our string

            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsPunctuation(arr[i]))  //change the punctuation on space sign to identify words
                {
                    arr[i] = ' ';
                }
                text += arr[i];
            }
            string[] words = text.Split(new char[] { ' ' }); //new array of strings where all words separated by space symbol

            return words;
        }

        /// <summary>
        /// Show all words which letters are less than n (TASK 2 letter a)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="number"></param>
        public static void ShowContent(string message, int number)
        {
            Regex myReg = new Regex(@"\s+");  // find all spaces
            string[] words = FormatString(message);
            Console.WriteLine("Here is the list of words, which length is less or equal to your number: ");
            foreach (string s in words)
            {
                if (s.Length <= number && s != null && !myReg.IsMatch(s)) // show only needed result
                {
                    Console.WriteLine(s);
                }
            }
        }


        /// <summary>
        /// Find the symbol at the end of the word and delete it if true
        /// </summary>
        /// <param name="message"></param>
        /// <param name="number"></param>
        public static void RemoveWord(string message, char s)
        {
            Console.WriteLine("Your char is {0}", s);
            string text = "";
            string[] words = FormatString(message);
            char lastChar = ' ';

            for (int i = 0; i < words.Length; i++)  // made two cycles to parse array of strings and after parse the string, char by char 
            {
                for (int k = 0; k < words[i].Length; k++)
                {
                    lastChar = words[i][words[i].Length - 1];
                }
                if (lastChar != s)
                    text += words[i] + " ";
            }
            Console.WriteLine("All words with your symbol at the end are deleted now.\nYour result text is: " + text);
        }
        /// <summary>
        /// Method helps to find the longiest word in the string
        /// </summary>
        /// <param name="message"></param>
        public static void FindLong(string message)
        {
            string[] words = FormatString(message);
            int wordLenMax = 0;
            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                if(wordLenMax < words[i].Length)
                { 
                    wordLenMax = words[i].Length;
                    result = words[i];
                }
            }
            Console.WriteLine("The longiest word is: {0}", result);
        }
    }


    class Task2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251); //RUS Encoding 
            while (true)
            {
                try
                {
                    //TASK 2 A
                    Console.WriteLine("Enter your string : ");
                    string message = Console.ReadLine();
                    Console.WriteLine("Enter the number of letters you want to see in a word: ");
                    int number = int.Parse(Console.ReadLine());
                    Message.ShowContent(message, number);

                    //TASK 2 B
                    Console.WriteLine("Please enter new string: ");
                    string message2 = Console.ReadLine();
                    Console.WriteLine("Enter the symbol: ");
                    char symbol = char.Parse(Console.ReadLine());
                    Message.RemoveWord(message2, symbol);

                    //TASK 2 C
                    Console.WriteLine("Enter your message to find the longiest word on it: ");
                    string message3 = Console.ReadLine();
                    Message.FindLong(message3);

                    break;
                }
                catch
                {
                    Console.WriteLine("Wrong value!");
                }
            }
            Console.ReadKey();
        }
    }
}
