var a = 5;
var b = 7;
var c = 2;
var d = b * b - (4 * a * c);
if (d < 0) 
{
    jsConsole.writeLine("The equation has no roots");
    return;
}
else if (d==0) 
{
    jsConsole.writeLine("The equation has one root : ");
    var x1 =  -b/(2*a);
    jsConsole.writeLine("x1= " + x1);
    return;
}
else if (d>0) 
{
    jsConsole.writeLine("The equation has two roots : ");
    d = Math.sqrt(d);
    var x1 = -b + Math.sqrt((b*b - (4*a*c)))
    var x2 = -b - Math.sqrt((b*b - (4*a*c)))
    jsConsole.writeLine("x1= " + x1);
    jsConsole.writeLine("x2= " + x2);
    return;
}

jsConsole.writeLine(d);
