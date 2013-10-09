
function Counter(arr, number) 
{
    var counter = 0;
    for (var i = 0; i < arr.length; i++) 
    {
        if (arr[i] == number) 
        {
            counter++;
        }
    }
    return counter;
}

var myArray = [1, 2, 3, 4, 5, 6, 5, 7, 8, 9];
var number = 5;
jsConsole.writeLine(Counter(myArray, number));