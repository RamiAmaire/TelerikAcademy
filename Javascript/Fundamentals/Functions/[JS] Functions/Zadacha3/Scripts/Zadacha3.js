
function Occurences(text, word) 
{
    if (!((arguments.length == 2) || (arguments.length == 3))) 
    {
        jsConsole.writeLine("Invalid input.");
    }
    else 
    {
        if (arguments.length == 2) 
        {
            // Case Insensitive
            return Insensitive(text, word);
        }
        else 
        {
            if (arguments[2] == false) 
            {
                // Case Insensitive
                return Insensitive(text, word);
            }
            else 
            {
                // Case Sensitive
                return Sensitive(text, word);
            }
        }
    }
    
}

function Sensitive(text, word) 
{
    var tempWord = word.toString();
    tempWord = tempWord.toLowerCase();

    var tempText = text.toString();
    tempText = tempText.toLowerCase();

    result = tempText.split(' ');
    var occurences = 0;
    for (var i = 0; i < result.length; i++) 
    {
        if (result[i] == word || result[i] == word + "." || result[i] == word + "," || result[i] == word + "?" || result[i] == word + "!") 
        {
            occurences++;
        }
    }
    return occurences;
}

function Insensitive(text, word) 
{
    var tempText = text.toString();
    var result = new Array();
    result = tempText.split(' ');

    var occurences = 0;
    for (var i = 0; i < result.length; i++) 
    {
        if (result[i] == word || result[i] == word + "." || result[i] == word + "," || result[i] == word + "?" || result[i] == word + "!") 
        {
            occurences++;
        }
    }
    return occurences;
}

var text = "Lorem ipsum dolor sit amet, LOREM adipiscing lorem. lorem! dictum sagittis leo, at eleifend orci interdum non.";
var word = "lorem";
jsConsole.writeLine(Occurences(text, word, false));