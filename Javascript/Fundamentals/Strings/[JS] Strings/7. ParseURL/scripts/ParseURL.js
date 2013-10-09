
function BuildJSONObject(protocol, server, resource) 
{
    var newObject =
    {
        Protocol: protocol,
        Server: server,
        Resource: resource,
        toString: function toString() 
        {
            return this.Protocol + '\n' + this.Server + ' \n' + this.Resource; // Kak e new line v JS ???
        }
    }
    return newObject;
}

var url = new String();
url = "http://www.devbg.org/forum/index.php ";

var result = new Array();
result = url.split("//");

var protocol = new String();
protocol = result[0];
protocol = protocol.replace(":", "");

var serverAndResource = result[1];
var server = new String();
var resource = new String();
var isServer = true;
for (var i = 0; i < serverAndResource.length; i++) 
{
    if (serverAndResource[i] == "/") 
    {
        isServer = false;
    }

    if (isServer) 
    {
        server += serverAndResource[i];
    }
    else 
    {
        resource += serverAndResource[i];
    }
}

var newObject = BuildJSONObject(protocol, server, resource);
jsConsole.writeLine(newObject.toString());

