
var arr = [3, 5, 8, 7, 9, 10, 13];
var br = 1;
var maxBr = 0;
var position = 0;
for (var i = 0; i < arr.length - 1; i++) 
{
    if (arr[i] < arr[i+1]) 
    {
        br++;
        if (br > maxBr) 
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
for (var j = position - maxBr+1; j <= position ; j++) 
{
    jsConsole.write(arr[j] + " ");
}
jsConsole.write("}");



