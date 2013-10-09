
var text = new String();
text = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";

var isOpen = true;
var content = "";
for (var i = 0; i < text.length; i++) 
{
    if (text[i] == "<") 
    {
        isOpen = false;
    }
    if (isOpen) 
    {
        content += text[i];
    }
    if (text[i] == ">") 
    {
        isOpen = true;
    }
}
jsConsole.writeLine(content);
