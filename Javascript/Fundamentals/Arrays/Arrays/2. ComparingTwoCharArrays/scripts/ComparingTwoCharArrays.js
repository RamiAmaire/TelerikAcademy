
var str1 = "cbvsd";
var str2 = "bsvdv";
if (str1.length != str2.length) 
{
    if (str1.length > str2.length) 
    {
        jsConsole.writeLine("Array tow is lexicographically smaller");
    }
    else 
    {
        jsConsole.writeLine("Array one is lexicographically smaller");
    }
}
else 
{
    for (var i = 0; i < str1.length; i++) 
    {
        if (str1[i] != str2[i]) 
        {
            if (str1[i] > str2[i]) 
            {
                jsConsole.writeLine("Array tow is lexicographically smaller");
                return;
            }
            else 
            {
                jsConsole.writeLine("Array one is lexicographically smaller");
                return;
            }
        }
    }
}
