

function myfunction(arr, index) 
{
    if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
        jsConsole.writeLine("Number " + arr[index] + " at position " + index + " is bigger than his neighbours.");
    }
    else {
        jsConsole.writeLine("Number " + arr[index] + " at position " + index + " is not bigger than his neighbours.");
    }
}

var myArray = [1, 2, 3, 4, 7, 3, 9, 5];

myfunction(myArray, 1);
