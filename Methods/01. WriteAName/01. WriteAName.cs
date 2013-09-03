//Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”).
//Write a program to test this method

using System;

class PrintName
{
    static void NameAndPrint()
    {
        Console.WriteLine("What's your name ?");
        string name = Console.ReadLine();
        Console.WriteLine("Hi, {0}", name);
    }
    static void Main()
    {
        NameAndPrint();
    }
}
