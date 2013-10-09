function GetPalindromes(text) 
{
    var words = text.split(/[\s\.,-?!)(]/);
    var palindromes = "";

    for (var i = 0; i < words.length; i++) 
    {
        if ((words[i] == Reverse(words[i])) && (words[i].length != 1) && (words[i] != "")) 
        {
            palindromes += words[i] + ", ";
        }
    }
    return palindromes;
}

function Reverse(word) 
{
    var result = "";
    for (var i = word.length-1 ; i >= 0; i--) 
    {
        result += word[i];
    }
    return result;
}

var text = new String();
text = "I love ABBA, because lamal is great, so eheeh exe";

jsConsole.writeLine(GetPalindromes(text));
