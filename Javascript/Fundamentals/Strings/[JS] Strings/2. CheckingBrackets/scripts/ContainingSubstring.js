﻿
function ContainsSubstr(text, substr) 
{
    var index = text.indexOf(substr);
    var counter = 0;
    while (index != -1) 
    {
        counter++;
        index = text.indexOf(substr, index + 1);
    }
    return counter;
}

var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."

jsConsole.writeLine(ContainsSubstr(text, "in");