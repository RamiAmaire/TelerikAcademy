
function MakePerson(lname, fname, age)
{
    var person = 
        {
            firstname: lname,
            lastname: fname,
            age: age,
            toString: function toString() 
            {
                return this.firstname + " " + this.lastname + " " + this.age;
            }
        }
    return person;
}

function FindYoungest(arr)
{
    var index = 0;
    var minAge = arr[0].age;
    for (var i = 1; i < arr.length; i++)
    {
        if (minAge > arr[i].age)
        {
            minAge = arr[i].age;
            index = i;
        }
    }
    return arr[index];
}
var ceco = MakePerson("Ceco", "Cvetanov", 43);
var bambi = MakePerson("bambi", "Cvetanov", 17);
var bobi = MakePerson("Bobi", "Cvetanov", 56);
var gospodin = MakePerson("gospodinov", "Cvetanov", 18);
var valyo = MakePerson("Valyo", "Cvetanov", 33);
var tedi = MakePerson("Tedi", "Cvetanov", 23);

var arr = new Array(ceco, bambi, gospodin, bobi, valyo, tedi);

jsConsole.writeLine(FindYoungest(arr).toString());






