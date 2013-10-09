function Solve(args) 
{
    function GetSystem() 
    {
        var alphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
        var upperValues = [];
        upperValues = alphabet.split(" ");

        var lowerAlphabet = alphabet.toLowerCase();
        var lowerValues = [];
        lowerValues = lowerAlphabet.split(" ");

        var result = [];
        for (var i = 0; i < upperValues.length; i++) 
        {
            result[i] = upperValues[i];
        }
        var k = 26;

        for (var down = 0; down < lowerValues.length; down++) 
        {
            for (var up = 0; up < upperValues.length; up++) 
            {
                result[k++] = lowerValues[down] + upperValues[up];
                if (k == 168) 
                {
                    return result;
                }
            }
        }
    }

    var input = args[0];

    var durankulakSystem = [];
    durankulakSystem = GetSystem();

    var decimalNumber = 0;
    var powIndex=0;
    for (var i = input.length - 1; i >= 0 ; i--) 
    {
        var temp = input[i-1] + input[i];

        if (durankulakSystem.indexOf(temp) != -1) 
        {
            i--;
            decimalNumber += Math.floor(durankulakSystem.indexOf(temp) * Math.pow(168, powIndex));
        }

        else 
        {
            temp = input[i];
            decimalNumber += Math.floor(durankulakSystem.indexOf(temp) * Math.pow(168, powIndex));
        }
            
        powIndex++;
    }

    return decimalNumber;
}

