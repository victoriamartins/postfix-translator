using System;

namespace postfix
{
    class Program
    {
        static int pos = -1;
        static char currentChar;
        static Token next = new Token();
        static string input;
        static Token lexer()
        {
            Token t = new Token();
            string valueT = "";
            while(true) 
            {
                currentChar = readChar();
                if (currentChar != ' ' && currentChar != '\n') break;
            }
            if (Char.IsNumber(currentChar)) 
            {
                valueT = String.Concat(valueT, currentChar);
                while(true)
                {
                    currentChar = readChar();
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
        static char readChar() 
        {
            pos++;
            if(pos < input.Length) {
                return input[pos];
            }
            return ' ';
        }
        static void parser(Token t) 
        {
            if (t.getType().Equals(next.getType()) && t.getValue().Equals(next.getType()))
                next = lexer();
            else
            {
                Console.WriteLine("*** Syntax Error! Values do not match. ***");
                Environment.Exit(1);
            }
        }
        static void numbers()
        {
            if (next.getType().Equals("number")) 
            {
                Console.Write(next.getValue());
                parser(next);
            }
            else
            {
                Console.WriteLine("*** Syntax Error! " + next.getValue() + " it's not a number. ***");
                Environment.Exit(1);
            }
        }
        
        static void Main(string[] args)
        {
            input = Console.ReadLine();
            Token next = new Token();
            next = lexer();
        }
    }
}
