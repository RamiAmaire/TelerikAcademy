
var HTMLText = new String();
HTMLText = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

var isAnchor = false;
for (var i = 0; i < HTMLText.length; i++) 
{
    if (HTMLText[i] == "<" && HTMLText[i + 1] == "a") 
    {
        HTMLText = HTMLText.replace("<a href", "[URL");
        isAnchor = true;
    }

    if (HTMLText[i] == "<" && HTMLText[i + 1] == "/" && HTMLText[i + 2] == "a") 
    {
        HTMLText = HTMLText.replace("</a>", "[/URL] ");
        isAnchor = false;
    }

    if (isAnchor && HTMLText[i] == ">") 
    {
        HTMLText = HTMLText.replace(">our", "]our");
    }
}

jsConsole.writeLine(HTMLText);