function Solve(args) 
{
    function GetSystem() {
        var alphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
        var upperValues = [];
        upperValues = alphabet.split(" ");

        var lowerAlphabet = alphabet.toLowerCase();
        var lowerValues = [];
        lowerValues = lowerAlphabet.split(" ");

        var result = [];
        for (var i = 0; i < upperValues.length; i++) {
            result[i] = upperValues[i];
        }
        var k = 26;

        for (var down = 0; down < lowerValues.length; down++) {
            for (var up = 0; up < upperValues.length; up++) {
                result[k++] = lowerValues[down] + upperValues[up];
                if (k == 256) {
                    return result;
                }
            }
        }
    }

    var input = args[0];

    var kaspichanSystem = [];
    kaspichanSystem = GetSystem();

    var result = []
    if (input == "0") 
    {
        return "A";
    }
    else 
    {
        while (input >= 1) 
        {
            var temp = input % 256;
            temp = parseInt(temp);
            result.push(kaspichanSystem[parseInt(temp)]);

            input /= 256;
            input = parseInt(input);
        }

        var output = "";
        for (var i = result.length - 1; i >= 0; i--) 
        {
            output += result[i];
        }

        return output;
    }
    
}

