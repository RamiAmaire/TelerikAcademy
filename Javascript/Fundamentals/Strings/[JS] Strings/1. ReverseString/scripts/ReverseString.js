
function ReverseString(str) 
{
    var resultStr = new String();
    for (var i = str.length-1; i >= 0; i--) 
    {
        resultStr += str[i];
    }
    return resultStr;
}


jsConsole.writeLine(ReverseString("Pesho"));