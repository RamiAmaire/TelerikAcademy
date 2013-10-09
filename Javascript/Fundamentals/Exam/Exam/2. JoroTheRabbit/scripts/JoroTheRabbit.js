function Solve(args) 
{
    function GetInput(args) 
    {
        var tempArr = args[0].split(", ");
        var positions = [];
        for (var i = 0; i < tempArr.length; i++) 
        {
            positions[i] = parseInt(tempArr[i]);
        }
        return positions;
    }

    var positions = [];
    positions = GetInput(args); // setting the positions in an array
    var positionsLength = positions.length;
    

    var maxJumps = 0; // the result

    for (var startPos = 0; startPos < positionsLength; startPos++) // looping through all the positions
    {
        for (var stepLength = 1; stepLength < positionsLength; stepLength++) // looping through all step length
        {
            var visited = []; // resetting every time
            visited[startPos] = true; // visited from start position is always true
            var jumpsCounter = 0; // making counter who is resetting every time

            var currentPos = startPos + stepLength; // setting current position
            if (currentPos >= positionsLength) // checking if it's outside of the array
            {
                currentPos -= positionsLength;
            }

            if (positions[currentPos] > positions[startPos]) // 
            {
                visited[currentPos] = true;
                jumpsCounter++;
                var nextPosition = currentPos + stepLength; // making new variable
                if (nextPosition >= positionsLength) // checking if it's outside of the array
                {
                    nextPosition -= positionsLength;
                }

                while ((positions[nextPosition] > positions[currentPos]) && !visited[nextPosition]) // checking if next position is bigger and also not visited
                {
                    currentPos = nextPosition; // current position is now next position
                    visited[currentPos] = true; // setting visited
                    nextPosition = currentPos + stepLength;
                    if (nextPosition >= positionsLength) // checking if it's outside of the array
                    {
                        nextPosition -= positionsLength;
                    }
                    jumpsCounter++;
                }
            }
            if (jumpsCounter > maxJumps) 
            {
                maxJumps = jumpsCounter;
            }
        }
    }
    return maxJumps+1;
}
