function Solve(args) {
    function SetInput(args) {
        var tempArr = new Array();
        for (var i = 0; i < args.length; i++) {
            tempArr[i] = args[i];
        }

        var input = new Array();
        for (var i = 0; i < tempArr.length; i++) {
            input[i] = tempArr[i].toString().split(", ");
        }

        // now we parse to int
        for (var i = 0; i < input.length; i++) {
            for (var j = 0; j < input[i].length; j++) {
                input[i][j] = parseInt(input[i][j]);
            }
        }

        return input;
    }

    function SetValley(valley, input) {
        for (var i = 0; i < input[0].length; i++) {
            valley[i] = input[0][i];
        }
        return valley;
    }

    function SetPatterns(input) {
        var allPatterns = new Array();
        for (var i = 2; i < input.length; i++) {
            allPatterns.push(input[i]);
        }
        return allPatterns;
    }

    function SetFalse(visited, length) {
        visited[0] = true; // first index is visited by default
        for (var j = 1; j < length; j++) {
            visited[j] = false; // setting the array values to false at the beginning
        }
        return visited;
    }

    function Validation(currentPosition, valley, visited) {
        if (currentPosition < 0 || currentPosition > valley.length || visited[currentPosition] == true) {
            return false;
        }
        else {
            return true;
        }
    }

    // Setting our most important things
    var input = [];
    //    var args = [];
    //    args[0] = "1, 3, -6, 7, 4, 1, 12";
    //    args[1] = "3";
    //    args[2] = "1, 2, -3";
    //    args[3] = "1, 3, -2";
    //    args[4] = "1, -1";
    input = SetInput(args); // setting input

    var valley = new Array();
    valley = SetValley(valley, input); // setting the valley in array


    var allPatterns = new Array();
    allPatterns = SetPatterns(input); // setting the patterns in an array of arrays


    var visited = new Array(); // making bool array for visited
    var maximalSum = -9007199254740992; // this is the final sum

    // now the main part
    for (var i = 0; i < allPatterns.length; i++) 
    {
        var currentSum = valley[0]; // reseting current sum
        visited = SetFalse(visited, valley.length); // reseting visited array
        var currentPosition = 0; // reseting current position

        for (var j = 0; j < allPatterns[i].length; j++) 
        {
            var nextStep = allPatterns[i][j];
            currentPosition += nextStep;

            if (Validation(currentPosition, valley, visited)) // checking if we are in the valley and not visited
            {
                currentSum += valley[currentPosition];
                visited[currentPosition] = true; // setting visited

                if (j == allPatterns[i].length - 1) // checking if pattern is finished and has to be reseted
                {
                    j = -1;
                }
            }
            else 
            {
                if (currentSum > maximalSum) 
                {
                    maximalSum = currentSum;
                }
                break;
            }
        }
    }
    return maximalSum;
}