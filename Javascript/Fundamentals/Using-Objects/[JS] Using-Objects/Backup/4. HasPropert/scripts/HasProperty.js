
function HasProperty(object, property)
{
    if (object.hasOwnProperty(property.toString()))
    {
        return true;
    }
    return false;
}
var person = 
{
    fName: "Gosho",
    lName: "Petkov",
    toString: function toString() 
    {
        return this.fName + " " + this.lName;
    }
}
jsConsole.writeLine(HasProperty(person,"toString"));

