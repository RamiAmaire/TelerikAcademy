
// Functions
function MakePoint(x, y)
{
    var point = 
        {
            X: x,
            Y: y,
            toString: function toString()
            {
                return "Point(" + this.X + ":" + this.Y + ")";
            }
        }
    return point;
}

function MakeLine(point1, point2)
{
    var line = 
        {
            Point1: point1,
            Point2: point2,
            toString: function toString() {
                return "Line(" + this.Point1.toString() + ", " + this.Point2.toString() + ")";
            }
        }
    return line;
}

function CalcDistance(point1, point2)
{
    var distance = ((point2.X + point1.X) * (point2.X + point1.X)) + ((point2.Y + point1.Y) * (point2.Y + point1.Y))
    distance = Math.sqrt(distance);
    return distance;
}

function isTriangle(distance1, distance2, distance3)
{
    if (distance1 > distance2 + distance3)
    {
        return false;
    }

    if (distance2 > distance1 + distance3)
    {
        return false;
    }

    if (distance3 > distance1 + distance2)
    {
        return false;
    }
    return true;
}

// Samples
var a = MakePoint(15, 15);
var b = MakePoint(1, 2);
var c = MakePoint(3, 9);

var lineAB = MakeLine(a, b);
jsConsole.writeLine(lineAB.toString());

var distanceAB = CalcDistance(a, b);
var distanceAC = CalcDistance(a, c);
var distanceBC = CalcDistance(b, c);

jsConsole.writeLine(isTriangle(distanceAB, distanceAC, distanceBC));


