
var circle = new Object();
circle.width = 0;
circle.height = 5;
var point = new Object();
point.width = 1;
point.height = 5;
var inRange = true;
if ((point.width > circle.width) || (point.height > circle.height)) 
{
    inRange = false;
}
jsConsole.writeLine(inRange);

