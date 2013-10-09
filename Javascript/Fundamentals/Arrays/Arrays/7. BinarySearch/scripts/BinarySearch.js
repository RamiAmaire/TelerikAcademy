
var arr = [4, 1, 1, 2, 2, 3, 4, 2, 1, 2, 4, 9, 3];
arr = arr.sort();
var left = 0;
var right = arr.length;
var mid = Math.floor((left + right) / 2);
var searchedNumber = 9;
var counter = 0;
while (left < right) 
{
    counter++;
    if (searchedNumber == arr[mid]) 
    {
        jsConsole.writeLine("Number " + searchedNumber + " was found at position : " + mid + " for " + counter + " rounds");
        break;
    }
    else 
    {
        if (searchedNumber > arr[mid]) 
        {
            left = mid + 1;
        }
        else 
        {
            right = mid - 1;
        }
    }
    mid = Math.floor((left + right) / 2);
}



