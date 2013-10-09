function ReverseDigits(number) 
{
    if (typeof number == "number") 
    {
        var numberToString = number.toString();
        var resultString = "";
        for (var i = numberToString.length-1; i >=0 ; i--) 
        {
            resultString += numberToString[i];
            var resultInt = parseInt(resultString[resultString.length - 1]);
            ReturnValue(resultInt);
        }
    }
    else 
    {
        jsConsole.writeLine("Invalid input. Not a number.");
    }
}

function ReturnValue(number) 
{
    var resultInt = number;
    switch (resultInt) 
    {
        case 1: jsConsole.writeLine("One");
            break;
        case 2: jsConsole.writeLine("Two");
            break;
        case 3: jsConsole.writeLine("Three");
            break;
        case 4: jsConsole.writeLine("Four");
            break;
        case 5: jsConsole.writeLine("Five");
            break;
        case 6: jsConsole.writeLine("Six");
            break;
        case 7: jsConsole.writeLine("Seven");
            break;
        case 8: jsConsole.writeLine("Eight");
            break;
        case 9: jsConsole.writeLine("Nine");
            break;
        default: jsConsole.writeLine("Undefined");
            break;
    }
}

ReverseDigits(358);




