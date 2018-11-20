/**
 
Vladimir Raevsky
GeekBrains Homework Task1

 
 */



using System;
using System.Text;
using System.Text.RegularExpressions;


namespace homework5
{
    class Task1
    {
        /// <summary>
        /// Method is endlessly checking login untill the user will input it correctly
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static StringBuilder Check(StringBuilder message)
        {
            string str = message.ToString();  //convert to string
            char strChar = str[0];  //first letter of the string


            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 'A' || str[i] > 'z' || char.IsDigit(strChar))
                {
                    Console.WriteLine("Incorrect input. Only Latin alphabet! First letter cannot be a digit as well. Please try again: ");
                    message = new StringBuilder(Console.ReadLine());
                    return Check(message);
                }
            }
            if (message.Length < 2 || message.Length > 10)
            {
                Console.WriteLine("Length can be only in this range: [2-10]. Please try again: ");
                message = new StringBuilder(Console.ReadLine());
                return Check(message);
            }
            else
            {
                Console.WriteLine("Returing your string builder...");
                return message;
            }
        }


        /// <summary>
        /// Check the stringbuilder with Regular Expression
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static StringBuilder CheckRegex(StringBuilder message)
        {
            Regex myReg = new Regex(@"^[^0-9]{1}[A-Za-z0-9]{2,9}$");

            if (myReg.IsMatch(message.ToString()))
            {
                Console.WriteLine("Your login is correct");
                return message;
            }
            else
            {
                Console.WriteLine("Your login is not correct, Please try again: ");
                message = new StringBuilder(Console.ReadLine());
                return CheckRegex(message);
            }
        }

        /// <summary>
        /// Print StringBuilder
        /// </summary>
        /// <param name="text"></param>
        static void Print(StringBuilder text)
        {
            Console.WriteLine("Your login is: {0}", text);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.GetEncoding(1251);
                Console.WriteLine("Please enter your login. Login length should be from 2 to 10 simbols long: ");

                StringBuilder a = new StringBuilder(Console.ReadLine());
                Print(Check(a));

                
                Console.WriteLine("Next method \"Regular Expression check\". Please enter your login: ");
                StringBuilder b = new StringBuilder(Console.ReadLine());
                Print(CheckRegex(b));

                Console.ReadKey();

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Sorry, you've entered the wrong value.", e);
            }
        }
    }
}