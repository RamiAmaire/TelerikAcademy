function Solve(params) 
{
    function GetDirections(params) 
    {
        var directions = [];
        for (var i = 2; i < params.length; i++) 
        {
            directions.push(params[i]);
        }

        return directions;
    }

    function SetLabyrinth(rowLen, colLen) 
    {
        var labyrinth = new Array(rowLen);
        var number = 1;

        for (var i = 0; i < labyrinth.length; i++) 
        {
            labyrinth[i] = new Array(colLen);
            for (var j = 0; j < labyrinth[i].length; j++) 
            {
                labyrinth[i][j] = number++;
            }
        }

        return labyrinth;
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

    function GetNextDirection(directions, arrIndex, strIndex) 
    {
        var nextDirection = directions[arrIndex][strIndex];
        return nextDirection;
    }

    // getting the labyrinth row length and col length
    var rowLenAndColLen = params[0].split(" ");
    var rowLen = parseInt(rowLenAndColLen[0]);
    var colLen = parseInt(rowLenAndColLen[1]);

    // setting the starting coordinates
    var startingCoords = params[1].split(" ");
    var currentPosition =
    {
        Row: parseInt(startingCoords[0]),
        Col: parseInt(startingCoords[1])
    }

    // getting the directions
    var directions = GetDirections(params);

    // setting the labyrinth
    var lab = SetLabyrinth(rowLen, colLen);

    // setting visited bool matrix with default false
    var visited = SetVisited(rowLen, colLen);

    // indexes for getting next direction from directions array
    var arrIndex = currentPosition.Row;
    var strIndex = currentPosition.Col;

    var sumOfNumbers = 0;
    var visitedCells = 0;

    // flags
    var up = false;
    var right = false;
    var down = false;
    var left = false;
    var isLost = false;

    while (Validation(rowLen, colLen, currentPosition)) 
    {
        visited[currentPosition.Row][currentPosition.Col] = true; // setting visited to current position

        // updating
        sumOfNumbers += lab[currentPosition.Row][currentPosition.Col];
        visitedCells++;

        // updating current position
        if (GetNextDirection(directions, arrIndex, strIndex) == "u") // up row -1 
        {
            currentPosition.Row -= 1;
            up = true;
        }

        if (GetNextDirection(directions, arrIndex, strIndex) == "r") // right col + 1
        {
            currentPosition.Col += 1;
            right = true;
        }

        if (GetNextDirection(directions, arrIndex, strIndex) == "d") // down row + 1
        {
            currentPosition.Row += 1;
            down = true;
        }

        if (GetNextDirection(directions, arrIndex, strIndex) == "l") // left col - 1
        {
            currentPosition.Col -= 1;
            left = true;
        }

        // checking if the updated current position is still in the labyrinth
        if (!Validation(rowLen, colLen, currentPosition)) 
        {
            break;
        }

        // checking if the updated current position is already visited
        if (visited[currentPosition.Row][currentPosition.Col] == true) 
        {
            isLost = true;
            break;
        }

        // flags
        if (up) 
        {
            arrIndex--;
            up = false;
        }

        if (right) 
        {
            strIndex++;
            right = false;
        }

        if (down) 
        {
            arrIndex++;
            down = false;
        }

        if (left) 
        {
            strIndex--;
            left = false;
        }
    }

    if (isLost) 
    {
        var lost = "lost " + visitedCells;
        return lost;
    }
    else 
    {
        var out = "out " + sumOfNumbers;
        return out;
    }
}








   









