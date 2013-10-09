function myfunction() 
{
    for (var i = 0; i < arguments.length; i++) 
    {
        if (typeof arguments[i] == "number") 
        {
            jsConsole.writeLine(arguments[i]);
        }
    }
}

myfunction("asd", 123, "abv");

