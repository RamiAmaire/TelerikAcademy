
var text = new String();
text = 'Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.';

var result = new Array()
result = text.match("([a-z0-9_\.-]{2,50})@([\da-z\.-]+)\.([a-z\.]{2,6})");

var finalResult = new Array();
for (var i = 0; i < result.length; i++) 
{
    if (result[i].indexOf("@") != -1) 
    {
        var tempArr = result[i].split(" ");
        finalResult.push(tempArr[0]); 
    }
}

for (var i = 0; i < finalResult.length; i++) 
{
    jsConsole.writeLine(finalResult[i]);
}
