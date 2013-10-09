
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

function Group(arr, prpt) {

    var groupedArr = [];

    var finalArray = [];

    if (prpt == "age") {

        var reppeatlessElements = []; //array with reppeatless elements

        for (var i = 0; i < arr.length; i++) {

            var reppeat = false; //checks if the element reppeats

            for (var j = 0; j < i; j++) {
                if (arr[i].age == arr[j].age) {
                    reppeat = true;
                    break; //if element reppeats break the iteration
                }
            }

            if (reppeat == false) { //if element does not reppeat push it to the reppeatless array
                reppeatlessElements.push(arr[i]);
            }
        }

        for (var i = 0; i < reppeatlessElements.length; i++) {
            var tempArr = [];

            for (var j = 0; j < arr.length; j++) {
                if (reppeatlessElements[i].age == arr[j].age) {
                    tempArr.push(arr[j]);
                    //console.log(reppeatlessElements[i]);
                    //console.log(arr[i]);
                }
            }
            groupedArr.push(tempArr);
        }

        for (var i = 0; i < groupedArr.length; i++) {
            finalArray.push({ Key: groupedArr[i][0].age, Value: groupedArr[i] });
        }

    }
    else // if prpt is "firstname"
    {
        var reppeatlessElements = []; //array with reppeatless elements

        for (var i = 0; i < arr.length; i++) {

            var reppeat = false; //checks if the element reppeats

            for (var j = 0; j < i; j++) {
                if (arr[i].firstname == arr[j].firstname) {
                    reppeat = true;
                    break; //if element reppeats break the iteration
                }
            }

            if (reppeat == false) { //if element does not reppeat push it to the reppeatless array
                reppeatlessElements.push(arr[i]);
            }
        }

        for (var i = 0; i < reppeatlessElements.length; i++) {
            var tempArr = [];

            for (var j = 0; j < arr.length; j++) {
                if (reppeatlessElements[i].firstname == arr[j].firstname) {
                    tempArr.push(arr[j]);
                }
            }
            groupedArr.push(tempArr);
        }

        for (var i = 0; i < groupedArr.length; i++) {
            finalArray.push({ Key: groupedArr[i][0].firstname, Value: groupedArr[i] });
        }
    }

    return finalArray;
}

var ceco = MakePerson("Ceco", "Cvetanov", 43);
var bambi = MakePerson("bambi", "Cvetanov", 17);
var bobi = MakePerson("Bobi", "Cvetanov", 56);
var gospodin = MakePerson("gospodinov", "Cvetanov", 18);
var valyo = MakePerson("bambi", "Cvetanov", 33);
var tedi = MakePerson("Tedi", "Cvetanov", 23);

var arr = new Array(ceco, bambi, gospodin, bobi, valyo, tedi);


var groupedByAge = Group(arr, "age");
jsConsole.WriteLine(groupedByAge);








