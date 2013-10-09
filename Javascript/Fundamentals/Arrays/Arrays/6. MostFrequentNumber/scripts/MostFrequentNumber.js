
var arr = [4, 1, 1, 2, 2, 3, 4, 2, 1, 2, 4, 9, 3];
arr = arr.sort();
var br = 1;
var maxBr = 0;
var positon = 0;
for (var i = 0; i < arr.length - 1; i++) 
{
    if (arr[i] == arr[i+1]) 
    {
        br++;
        if (br>maxBr) 
        {
            maxBr = br;
            positon = i + 1;
        }
    }
    else 
    {
        br = 1;
    }
}
jsConsole.writeLine("The most frequent number is : " + arr[positon] + " -> " + maxBr + " times");



