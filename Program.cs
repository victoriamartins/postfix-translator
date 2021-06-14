using System;

namespace postfix
{
    class Program
    {
        static int pos = -1;
        static Token next = new Token();
        static string input;
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
                Console.Write(" ");
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
            //Console.WriteLine("Type a simple arithmetic expression: ");
            input = "2 + 8";
            Lexer l = new Lexer(input);
            Token t = new Token();
            t = l.lexer();
            Console.WriteLine(t.getType() + " " + t.getValue());
        }
    }
}
