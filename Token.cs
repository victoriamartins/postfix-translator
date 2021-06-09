using System;

public class Token 
{
    private string type;
    private string value;
    
    public void setTypeSymbol()
    {
        this.type = "symbol";
    }
    public void setTypeNumber()
    {
        this.type = "number";
    }
    public void setValue(string value)
    {
        this.value = value;
    }
    public string getType()
    {
        return this.type;
    }
    public string getValue()
    {
        return this.value;
    }
}