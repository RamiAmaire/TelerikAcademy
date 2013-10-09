
var sum = 0;
var n = 24;
for (var divisor = 1; divisor <= 100; divisor++) 
{
    if (n % divisor === 0) 
    {
        sum += divisor;
    }
}
if (sum === n + 1) 
{
    jsConsole.writeLine(n + " " + "is prime !");
}
else 
{
    jsConsole.writeLine(n + " " + "is not prime !");
}

