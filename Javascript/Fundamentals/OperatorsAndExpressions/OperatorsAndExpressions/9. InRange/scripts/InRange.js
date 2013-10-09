
var point = new Object();
point.width = 3;
point.height = 3;

if (point.width > 3 || point.height > 3) 
{
    jsConsole.writeLine("Point(" + point.width + "," + point.height + ")" + " is not in the circle")
}
else 
{
    jsConsole.writeLine("Point(" + point.width + "," + point.height + ")" + " is in the circle")
}

if (point.width > 5 || point.width < -1 || point.height > 1 || point.height < -1) 
{
    jsConsole.writeLine("Point(" + point.width + "," + point.height + ")" + " is not in the rectangle")
}
else 
{
    jsConsole.writeLine("Point(" + point.width + "," + point.height + ")" + " is in the rectangle")
}

 



