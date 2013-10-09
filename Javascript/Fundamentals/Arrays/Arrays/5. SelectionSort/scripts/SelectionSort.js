
var arr = [3, 5, 8, 7, 2, 10, 1];
for (var i = 0; i < arr.length - 1; i++) 
{
    var min = arr[i];
    var pos = i;
    for (var j = i+1; j < arr.length; j++) 
    {
        if (min > arr[j]) 
        {
            min = arr[j];
            pos = j;
        }
    }
    var temp = arr[i];
    arr[i] = min;
    arr[pos] = temp;
}
for (var k = 0; k < arr.length; k++) 
{
    jsConsole.write(arr[k] + " ");
}



