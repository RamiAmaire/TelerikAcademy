
function ChangeText(text) 
{
    var oldStr = "";
    // mixCase
    
    var mixCaseStartIndex = text.indexOf("<mixcase>");
    var mixCaseEndIndex = text.indexOf("</mixcase>");

    var mixSubstr = "";
    mixSubstr = MixCase(text, mixCaseStartIndex + 9, mixCaseEndIndex);
    oldStr = GetoldStr(text, mixCaseStartIndex, mixCaseEndIndex + 10);
    text = text.replace(oldStr, mixSubstr);

    while (mixCaseStartIndex != -1) 
    {
        mixCaseStartIndex = text.indexOf("<mixcase>", mixCaseStartIndex + 1)
        mixCaseEndIndex = text.indexOf("</mixcase>", mixCaseEndIndex + 1);

        if (mixCaseStartIndex != -1) 
        {
            mixSubstr = MixCase(text, mixCaseStartIndex + 9, mixCaseEndIndex);
            oldStr = GetoldStr(text, mixCaseStartIndex, mixCaseEndIndex + 10);
            text = text.replace(oldStr, mixSubstr);
        }
    }

    // uppercase
    var upperCaseStartIndex = text.indexOf("<upcase>");
    var upperCaseEndIndex = text.indexOf("</upcase>");

    var UpSubstr = "";
    UpSubstr = UpCase(text, upperCaseStartIndex + 8, upperCaseEndIndex);
    oldStr = GetoldStr(text, upperCaseStartIndex, upperCaseEndIndex + 9);
    text = text.replace(oldStr, UpSubstr);

    while (mixCaseStartIndex != -1) 
    {
        upperCaseStartIndex = text.indexOf("<upcase>", upperCaseStartIndex + 1);
        upperCaseEndIndex = text.indexOf("</upcase>", upperCaseEndIndex + 1);

        if (upperCaseStartIndex != -1) 
        {
            UpSubstr = UpCase(text, upperCaseStartIndex + 8, upperCaseEndIndex);
            oldStr = GetoldStr(text, upperCaseStartIndex, upperCaseEndIndex + 9);
            text = text.replace(oldStr, UpSubstr);
        }
    }

    // lowercase
    var lowerCaseStartIndex = text.indexOf("<lowcase>");
    var lowerCaseEndIndex = text.indexOf("</lowcase>");

    var lowSubstr = "";
    lowSubstr = LowCase(text, lowerCaseStartIndex + 9, lowerCaseEndIndex);
    oldStr = GetoldStr(text, lowerCaseStartIndex, lowerCaseEndIndex + 10);
    text = text.replace(oldStr, lowSubstr);

    while (lowerCaseStartIndex != -1) 
    {
        lowerCaseStartIndex = text.indexOf("<upcase>", lowerCaseStartIndex + 1);
        lowerCaseEndIndex = text.indexOf("</upcase>", lowerCaseEndIndex + 1);

        if (lowerCaseStartIndex != -1) 
        {
            lowSubstr = LowCase(text, lowerCaseStartIndex + 9, lowerCaseEndIndex);
            oldStr = GetoldStr(text, lowerCaseStartIndex, lowerCaseEndIndex + 10);
            text = text.replace(oldStr, lowSubstr);
        }
    }
    return text;
}

function GetoldStr(text, start, end) 
{
    var oldStr = "";
    for (var i = start; i < end; i++) 
    {
        oldStr += text[i];
    }
    return oldStr;
}

function MixCase(text, start, end) 
{
    var mixString = "";
    for (var i = start; i < end; i++) 
    {
        var random = Math.floor((Math.random() * 10) + 1);
        if (random % 2 == 0) 
        {
            mixString += text[i].toLowerCase();
        }
        else 
        {
            mixString += text[i].toUpperCase();
        }
    }
    return mixString;
}

function LowCase(text, start, end) 
{
    var lowString = "";
    for (var i = start; i < end; i++) 
    {
        lowString += text[i].toLowerCase();
    }
    return lowString;
}

function UpCase(text, start, end) 
{
    var upString = "";
    for (var i = start; i < end; i++) 
    {
        upString += text[i].toUpperCase();
    }
    return upString;
}

var text = new String();
text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else."
jsConsole.writeLine(ChangeText(text));