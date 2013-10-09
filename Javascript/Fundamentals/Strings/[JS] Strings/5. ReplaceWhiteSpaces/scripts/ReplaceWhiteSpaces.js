
var text = new String();
text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

for (var i = 0; i < text.length; i++) 
{
    text = text.replace(" ", "&nbsp");
}
jsConsole.writeLine(text);