window.onload = function () 
{
    document.getElementById("enter").onclick = function () 
    {
        var arr1 = [window, navigator, document];
        for (var i = 0; i < 3; i++) 
        {
            var outTxt = "";
            var arr;
            for (var property in arr1[i]) 
            {
                outTxt += property + " ";
            }
            arr = outTxt.split(" ");
            arr.sort();
            outTxt = "Min:" + arr[1] + "; Max:" + arr[arr.length - 1] + ";";
            var id = "output" + (i + 1);
            document.getElementById(id).innerHTML = outTxt;
        }
    }
}