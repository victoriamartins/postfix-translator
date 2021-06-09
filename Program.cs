using System;

namespace postfix
{
    class Program
    {
        static int pos = -1;
        static char currentChar;
        static Token lexer(string input)
        {
            Token t = new Token();
            while(true) 
            {
                currentChar = readChar(input);
                if (currentChar != ' ' && currentChar != '\n') break;
            }
            if (Char.IsNumber(currentChar)) 
            {
                // TODO: to check if the next char is also a number 
                // (if it is, concat them)
                t.setTypeNumber();
                t.setValue(currentChar);
                Console.WriteLine(currentChar + " é numero");
                return t;
            }
            t.setTypeSymbol();
            t.setValue(currentChar);
            Console.WriteLine(currentChar + " é simbolo");
            return t;
        }

        static char readChar(string input) 
        {
            pos++;
            if(pos < input.Length) {
                return input[pos];
            }
            return ' ';
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(input);
            Token next = new Token();
            next = lexer(input);
        }
    }
}
