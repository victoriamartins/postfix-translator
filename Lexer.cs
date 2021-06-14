using System;

public class Lexer
{
    public string input;
    public int pos;

    public Lexer(string input)
    {
        this.input = input;
        this.pos = -1;
    }
    public char readChar()
    {
        this.pos++;
        if (this.pos < this.input.Length)
        {
            return this.input[this.pos];
        }
        return '\0';
    }
    public Token lexer()
    {
        Token t = new Token();
        string valueT = "";
        char currentChar;

        while (true)
        {
            currentChar = readChar();
            if (currentChar != ' ' && currentChar != '\n') break;
        }
        if (Char.IsNumber(currentChar))
        {
            valueT = String.Concat(valueT, currentChar);
            while (true)
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
}