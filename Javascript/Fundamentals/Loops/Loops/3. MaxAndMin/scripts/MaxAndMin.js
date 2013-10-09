var max = 0;
var min = 232084629462946;
for (var i = 0; i < 10; i++) 
{
    var number = Math.floor((Math.random() * 100) + 1);
    if (number > max) 
    {
        max = number;
    }
    if (number < min) 
    {
        min = number;
    }
}
jsConsole.writeLine("Max : " + max);
jsConsole.writeLine("Min : " + min);