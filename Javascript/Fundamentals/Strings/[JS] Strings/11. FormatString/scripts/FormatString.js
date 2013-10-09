
function stringFormat(text) 
{
    for (var i = 0; i < arguments.length; i++) 
    {
        var temp = "{" + i + "}";
        text = text.replace(temp, arguments[i + 1]);

    }
    return text;
}
var str = stringFormat("Hello {0} {1}", "Peter", "Goshov");
jsConsole.writeLine(str);
