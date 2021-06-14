using System;

namespace postfix
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Type a simple arithmetic expression: ");
            string input = Console.ReadLine();
            Lexer l = new Lexer(input);
            Parser p  = new Parser(l);
            p.expr();
        }
    }
}
