
var arr = new Array(21);
for (var i = 1; i < arr.length; i++) 
{
    arr[i-1] = i + 5;
}
for (var i = 0; i < arr.length-1 ; i++) 
{
    jsConsole.writeLine(i+1 + ". " + arr[i]);
}