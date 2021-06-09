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
            string valueT = "";
            while(true) 
            {
                currentChar = readChar(input);
                if (currentChar != ' ' && currentChar != '\n') break;
            }
            if (Char.IsNumber(currentChar)) 
            {
                valueT = String.Concat(valueT, currentChar);
                while(true)
                {
                    currentChar = readChar(input);
                    if (Char.IsNumber(currentChar)) valueT = String.Concat(valueT, currentChar);
                    else 
                    {
                        pos--;
                        break;
                    }
                }
                t.setTypeNumber();
                t.setValue(valueT);
                Console.WriteLine(valueT + " é numero");
                return t;
            }
            t.setTypeSymbol();
            valueT = String.Concat(valueT, currentChar);
            t.setValue(valueT);
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
