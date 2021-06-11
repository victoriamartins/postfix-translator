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
                return t;
            }
            t.setTypeSymbol();
            valueT = String.Concat(valueT, currentChar);
            t.setValue(valueT);
            return t;
        }
        static char readChar() 
        {
            pos++;
            if(pos < input.Length) {
                return input[pos];
            }
            return '\t';
        }
        static void parser(Token t) 
        {
           if (t.getType().Equals(next.getType()) && t.getValue().Equals(next.getValue()))
                next = lexer();
            else
            {
                Console.WriteLine("*** Syntax Error! Values do not match. ***");
            }
        }
        static void numbers()
        {
            if (next.getType().Equals("number")) 
            {
                Console.Write(next.getValue() + " ");
                parser(next);
            }
            else
            {
                Console.WriteLine("*** Syntax Error! " + next.getValue() + " it's not a number. ***");
                Environment.Exit(1);
            }
        }
        static void postfix()
        {
            numbers();
            while(true)
            {
                if (next.getType().Equals("symbol"))
                {
                    if (next.getValue().Equals("+"))
                    {
                        parser(next);
                        numbers();
                        Console.Write("+ ");
                    } 
                    else if (next.getValue().Equals("-"))
                    {
                        parser(next);
                        numbers();
                        Console.Write("- ");
                    } else {
                        break;
                    }
                } 
                else {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Type your infixed expression: ");
            input = Console.ReadLine();
            next = lexer();
            postfix();
        }
    }
}
