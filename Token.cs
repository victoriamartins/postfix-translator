using System;

public class Token 
{
    private string type;
    private char value;
    
    public void setTypeSymbol()
    {
        this.type = "symbol";
    }
    public void setTypeNumber()
    {
        this.type = "number";
    }
    public void setValue(char value)
    {
        this.value = value;
    }
    public string getType()
    {
        return this.type;
    }
    public char getValue()
    {
        return this.value;
    }
}