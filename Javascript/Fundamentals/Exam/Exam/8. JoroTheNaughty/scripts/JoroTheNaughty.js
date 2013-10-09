function Solve(params) 
{
    function GetJumpingCoords(params) 
    {
        var allCoords = [];
        var startIndex = 0;

        for (var i = 2; i < params.length; i++) 
        {
            allCoords[startIndex++] = params[i].split(" ");
        }
        return allCoords;
    }

    function SetField(rowLen, colLen) 
    {
        var field = new Array(rowLen);
        var number = 1;
        for (var i = 0; i < field.length; i++) 
        {
            field[i] = new Array(colLen);
            for (var j = 0; j < field[i].length; j++) 
            {
                field[i][j] = number++;
            }
        }
        return field;
    }

    function SetVisited(rowLen, colLen) 
    {
        var visited = new Array(rowLen);
        for (var i = 0; i < visited.length; i++) 
        {
            visited[i] = new Array(colLen);
            for (var j = 0; j < visited[i].length; j++) 
            {
                visited[i][j] = false;
            }
        }
        return visited;
    }

    function Validation(rowLen, colLen, currentPosition) 
    {
        if ((currentPosition.Row >= 0 && currentPosition.Row < rowLen) && (currentPosition.Col >= 0 && currentPosition.Col < colLen)) 
        {
            return true;
        }
        return false;
    }

    function GetNextRow(jumpingCoords, currentPatternIndex) 
    {
        var nextRow = parseInt(jumpingCoords[currentPatternIndex][0]);
        return nextRow;
    }

    function GetNextCol(jumpingCoords, currentPatternIndex) 
    {
        var nextCol = parseInt(jumpingCoords[currentPatternIndex][1]);
        return nextCol;
    }

    //var params = [];
    //params[0] = "6 7 3";
    //params[1] = "0 0";
    //params[2] = "2 2";
    //params[3] = "-2 2";
    //params[4] = "3 -1";

    // getting the horizontal and vertical length of the field
    var rowLenColLenNumberOfJumps = params[0].split(" ");
    var rowLen = parseInt(rowLenColLenNumberOfJumps[0]); // getting n
    var colLen = parseInt(rowLenColLenNumberOfJumps[1]); // getting m

    // getting the starting coords and putting in directly in current position
    var startingCoords = params[1].split(" ");
    var currentPosition = 
    {
        Row: parseInt(startingCoords[0]), // the row coord
        Col: parseInt(startingCoords[1]), // the col coord
    }

    // getting all jumping patterns in an array 
    var jumpingCoords = GetJumpingCoords(params); // here are my jumping patterns

    // settign the field - a matrix 
    var field = SetField(rowLen, colLen);

    // setting a visited array with default false
    var visited = SetVisited(rowLen, colLen);

    var currentPatternIndex = 0;
    var sumOfNumbers = 0;
    var numberOfJumps = 0;
    var visitedFlag = false;

    while (Validation(rowLen, colLen, currentPosition)) 
    {
        visited[currentPosition.Row][currentPosition.Col] = true; // if inside the field, setting the current position as visited

        sumOfNumbers += field[currentPosition.Row][currentPosition.Col]; // adding to the overall sum the value of the current cell
        numberOfJumps++; // updating the number of jumps

        // updating the current position with the current jump pattern
        currentPosition.Row += GetNextRow(jumpingCoords, currentPatternIndex);
        currentPosition.Col += GetNextCol(jumpingCoords, currentPatternIndex);
        currentPatternIndex++;
        if (currentPatternIndex == jumpingCoords.length)  // if the patterns have finished, we reset them
        {
            currentPatternIndex = 0;
        }

        // cheking if updated current position is still inside the field
        if (!Validation(rowLen, colLen, currentPosition)) 
        {
            break;
        }

        // checking if current position is already visited
        if ((visited[currentPosition.Row][currentPosition.Col] == true)) 
        {
            visitedFlag = true;
            break;
        }
    }

    if (visitedFlag) 
    {
        var caught = "caught " + numberOfJumps;
        //jsConsole.writeLine(caught);
        return caught;
    }

    var escaped = "escaped " + sumOfNumbers;
    //jsConsole.writeLine(escaped);
    return escaped;
}






