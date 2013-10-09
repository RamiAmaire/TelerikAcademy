var number1 = 9;
var number2 = 7;
var number3 = -20;

jsConsole.write("The products sign is : ");
if (number1 < 0 && number2 > 0 && number3 > 0) 
{
    jsConsole.writeLine("-");
}
if (number1 > 0 && number2 < 0 && number3 > 0) {
    jsConsole.writeLine("-");
}
if (number1 > 0 && number2 > 0 && number3 < 0) {
    jsConsole.writeLine("-");
}

if (number1 < 0 && number2 < 0 && number3 > 0) {
    jsConsole.writeLine("+");
}
if (number1 < 0 && number2 > 0 && number3 < 0) {
    jsConsole.writeLine("+");
}
if (number1 > 0 && number2 < 0 && number3 < 0) {
    jsConsole.writeLine("+");
}
if (number1 < 0 && number2 < 0 && number3 < 0) {
    jsConsole.writeLine("-");
}
if (number1 > 0 && number2 > 0 && number3 > 0) {
    jsConsole.writeLine("+");
}