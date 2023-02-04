﻿using System;
using App.StudentManagement.Helpers;
using Library.StudentManagement.Models;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var printMenu = new PrintHelper();
            var studentHelper = new StudentHelper();
            printMenu.ConsolePrint();
            var input = Console.ReadLine();
            if(int.TryParse(input, out int result) ) 
            {
                while (result != 0)
                {
                    if (result == 1)
                    {
                        studentHelper.CreateStudent();
                    }
                    printMenu.ConsolePrint();
                    input = Console.ReadLine();
                    int.TryParse(input, out result );
                }
            }   
        }
    }
}