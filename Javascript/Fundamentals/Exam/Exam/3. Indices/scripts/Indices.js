//function Solve(args) {
    function GetInput(args) {
        var tempArr = [];
        tempArr = args[1].split(" ");
        var arr = []
        for (var i = 0; i < tempArr.length; i++) {
            arr[i] = parseInt(tempArr[i]);
        }
        return arr;
    }

    function GetResult(result, index) {
        var output = "";

        if (arguments.length == 2) {
            for (var i = 0; i < result.length; i++) {
                if (i == index) {
                    output += "(" + result[i];
                }

                else {
                    output += " " + result[i];
                }

            }
            output += ")";
        }

        else {
            for (var j = 0; j < result.length; j++) {
                output += " " + result[j];
            }
        }

        output = output.trim();
        return output;
    }

        var args = [];
        args[0] = "11";
        args[1] = "2 10 1 3 9 8 7 2 4 6 1";

    var numbersLength = parseInt(args[0]);
    var numbers = [];
    numbers = GetInput(args);

    var currentPosition = 0;

    var visited = [];
    visited[currentPosition] = true;

    var result = [];
    result.push(currentPosition);

    var output = "";

    while (true) {
        currentPosition = numbers[currentPosition];

        if (currentPosition < 0 || currentPosition >= numbersLength) {
            output = GetResult(result);
            break;
        }

        if (visited[currentPosition]) {
            var index = result.indexOf(currentPosition);
            output = GetResult(result, index);
            break;
        }
        visited[currentPosition] = true;
        result.push(currentPosition);
    }
        jsConsole.writeLine(output);
//    return output;
//}