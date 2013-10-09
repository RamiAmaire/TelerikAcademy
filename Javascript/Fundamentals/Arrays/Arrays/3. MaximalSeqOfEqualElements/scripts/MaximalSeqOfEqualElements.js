
var arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 2];
var br = 1;
var maxBr = 0;
var position = 0;
for (var i = 0; i < arr.length - 1; i++) 
{
    if (arr[i] == arr[i+1]) 
    {
        br++;
        if (br>maxBr) 
        {
            maxBr = br;
            position = i + 1;
        }
    }
    else 
    {
        br = 1;
    }
}
jsConsole.write("{");
for (var i = position; i > position - maxBr; i--) 
{
    jsConsole.write(arr[i] + " ");
}
jsConsole.writeLine("}");



