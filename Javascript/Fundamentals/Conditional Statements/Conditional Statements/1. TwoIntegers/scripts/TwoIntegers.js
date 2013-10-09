var number1 = 9;
var number2 = 7;
jsConsole.writeLine("Before : ");
jsConsole.writeLine(number1);
jsConsole.writeLine(number2);
if (number1 > number2) 
{
    var temp = number1;
    number1 = number2;
    number2 = temp;
}
jsConsole.writeLine("After : ");
jsConsole.writeLine(number1);
jsConsole.writeLine(number2);