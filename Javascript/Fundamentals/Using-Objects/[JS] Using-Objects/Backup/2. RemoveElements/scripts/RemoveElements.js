
function RemovingAlgorithm(arr, index)
{
    for (var i = index; i < arr.length; i++)
    {
        arr[i] = arr[i + 1];
    }
    return arr;
}

function RemoveAll(value)
{
    for (var i = 0; i < this.length; i++)
    {
        if (arr[i] == value)
        {
            RemovingAlgorithm(arr, i);
            i--;
        }
    }
    return arr;
}

Array.prototype.RemoveAll = RemoveAll;

var arr = new Array();
arr = [1, 2, 3, 4, 5, 6, 6, 7, 8, 6];

var newArr = arr.RemoveAll(6);

for (var i = 0; i < newArr.length; i++) 
{
    if (newArr[i] != undefined) 
    {
        jsConsole.write(newArr[i] + " ");
    }
}



