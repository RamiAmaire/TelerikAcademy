

function myfunction(arr) 
{
    var start = arguments[1] || 0;
    var end = arguments[2] || arr.length - 1;
    for (var i = start; i < end; i++) 
    {
        if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) 
        {
            return arr[i];
        }
    }
    return -1;
}

var myArray = [1, 2, 3, 4, 7, 3, 9, 5];

jsConsole.writeLine(myfunction(myArray, 1, 3));
