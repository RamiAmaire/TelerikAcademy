function Solve(args) 
{
    function GetSystem() 
    {
        var result = [];
        result.push("-!")
        result.push("**");
        result.push("!!!");
        result.push("&&");
        result.push("&-");
        result.push("!-");
        result.push("*!!!");
        result.push("&*!");
        result.push("!!**!-");

        return result;
    }

    var input = args[0];
//    var input = "!!**!--!!-";

    var gagSystem = [];
    gagSystem = GetSystem();

    
    var temp = "";
    var temp1 = "";

    for (var i = 0; i < input.length ; i++) 
    {
        temp += input[i];

        if (gagSystem.indexOf(temp) != -1) 
        {
            temp1 += temp + " ";
            temp = "";
        }
    }
    temp1 = temp1.trim();

    var decimalNumber = 0;
    var powIndex = 0;
    var result = temp1.split(" ");

    for (var j = result.length - 1; j >= 0; j--) 
    {
        decimalNumber += Math.floor(gagSystem.indexOf(result[j]) * Math.pow(9, powIndex));
        powIndex++;
    }

//    jsConsole.writeLine(decimalNumber);

    return decimalNumber;
}

