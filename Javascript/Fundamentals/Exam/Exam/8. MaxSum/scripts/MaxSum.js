function Solve(params) 
{
    function FillArray(params) 
    {
        var arr = [];
        var startIndex = 0;
        for (var i = 1; i < params.length; i++) 
        {
            arr[startIndex++] = parseInt(params[i]);
        }
        return arr;
    }

    function FindMaxNumber(arr) 
    {
        var max = -9007199254740992;
        for (var i = 0; i < arr.length; i++) 
        {
            if (arr[i] > max) 
            {
                max = arr[i];
            }
        }
        return max;
    }

    var arr = FillArray(params);
    var maxSum = FindMaxNumber(arr);
    
    for (var i = 0; i < arr.length; i++) 
    {
        var currentSum = arr[i];
        for (var j = i + 1; j < arr.length; j++) 
        {
            if (arr[j] != undefined) 
            {
                currentSum += arr[j];
                if (currentSum > maxSum) 
                {
                    maxSum = currentSum;
                }
            }
        }
    }

    return maxSum;
}









