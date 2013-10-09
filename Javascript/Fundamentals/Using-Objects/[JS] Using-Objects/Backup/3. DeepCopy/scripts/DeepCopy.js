function deepCopy(obj) 
{
    if (Object.prototype.toString.call(obj) === '[object Array]') 
    {
        var out = [];
        
        for (i = 0; i < obj.length; i++) 
        {
            out[i] = arguments.callee(obj[i]);
        }
        return out;
    }
    if (typeof obj === 'object') 
    {
        var out = {}; ;
        for (var i in obj) 
        {
            out[i] = arguments.callee(obj[i]);
        }
        return out;
    }
    return obj;
}

var arr = [1, 2, 3, 4, 5, 6];
var result = deepCopy(arr);
result[2] = 27; //changing random element

jsConsole.writeLine("Initial array: ");
for (var i = 0; i < arr.length; i++) 
{
    jsConsole.write(arr[i] + " ");
}
jsConsole.writeLine();

jsConsole.writeLine("Deep copy: ");
for (var j = 0; j < result.length; j++) 
{
    jsConsole.write(result[j] + " ");
}