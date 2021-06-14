using System;

public class Parser
{
    Token next = new Token();
    Lexer l;
    public Parser(Lexer l)
    {
        this.l = l;
        this.next = this.l.lexer();
    }
    public void match(Token t)
    {
        if (t.getType().Equals(next.getType()) && t.getValue().Equals(next.getValue()))
            next = l.lexer();
        else
        {
            Console.WriteLine("\n*** Syntax Error! Values do not match. ***");
        }
    }

    public void term()
    {
        if (next.getType().Equals("number"))
        {
            Console.Write(next.getValue() + " ");
            match(next);
        }
        else
        {
            Console.WriteLine("\n*** Syntax Error! " + next.getValue() + " it's not a number. ***");
            Environment.Exit(1);
        }
    }
    public void rest()
    {
        while (true)
        {
            if (next.getType().Equals("symbol"))
            {
                if (next.getValue().Equals("+"))
                {
                    match(next);
                    term();
                    Console.Write("+ ");
                }
                else if (next.getValue().Equals("-"))
                {
                    match(next);
                    term();
                    Console.Write("- ");
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }

    public void expr()
    {
        term();
        rest();
    }

}