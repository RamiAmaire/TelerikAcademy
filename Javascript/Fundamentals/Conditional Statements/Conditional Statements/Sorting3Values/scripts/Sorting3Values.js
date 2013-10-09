var a = 9;
var b = 7;
var c = 20;

if (a > b && a > c)
{
    jsConsole.writeLine(a + " is biggest");
    if (b > c) 
    {
        jsConsole.writeLine(b + " is second");
    }
    else 
    {
        jsConsole.writeLine(c + " is second");
    }
}
if (b > a && b > c) 
{
    jsConsole.writeLine(b + " is biggest");
    if (a > c) 
    {
        jsConsole.writeLine(a + " is second");
    }
    else 
    {
        jsConsole.writeLine(c + " is second");
    }
}
if (c > a && c > b) 
{
    jsConsole.writeLine(c + " is biggest");
    if (a > b) 
    {
        jsConsole.writeLine(a + " is second");
    }
    else 
    {
        jsConsole.writeLine(b + " is second");
    }
}