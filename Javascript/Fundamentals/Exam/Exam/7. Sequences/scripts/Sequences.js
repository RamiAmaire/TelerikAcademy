function Solve(params) 
{
    function GetNumbers(params) 
    {
        var arr = [];
        var index = 0;
        for (var i = 1; i < params.length; i++) 
        {
            arr[index++] = parseInt(params[i]);
        }

        return arr;
    }

    var arrLen = parseInt(params[0]);
    var arr = GetNumbers(params);

    var seqCounter = 0;

    for (var i = 0; i < arrLen; i++) 
    {
        var firstTime = true;

        while ((arr[i] <= arr[i + 1]) && (arr[i + 1] != undefined)) 
        {
            if (firstTime) 
            {
                seqCounter++;
            }
            firstTime = false;
            i++;
        }

        if (firstTime) 
        {
            seqCounter++;
        }
    }
    return seqCounter;
}
