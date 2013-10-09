
function IsCorrectBrackets(expression) 
{
    var indexOfStartingBracket = expression.indexOf("(");
    var indexOfEndingBracket = expression.indexOf(")");
    
    if ((indexOfEndingBracket < indexOfStartingBracket) && (indexOfStartingBracket != -1)) 
    {
        return false;
    }

    else 
    {
        var isCorrect = 0;
        for (var i = 0; i < expression.length; i++) 
        {
            if (expression[i] == "(") 
            {
                isCorrect += 1;
            }
            if (expression[i] == ")") 
            {
                isCorrect -= 1;
            }
        }

        if (isCorrect == 0) 
        {
            return true;
        }
        else 
        {
            return false;
        }
        
    }
}

var asd = 0;
jsConsole.writeLine(IsCorrectBrackets("((a+b)((/5-d)))"));
