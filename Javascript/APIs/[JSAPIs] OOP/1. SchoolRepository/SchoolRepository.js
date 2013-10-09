var schoolRepository = (function () {
    var School = Class.create({
        init: function (name, town, classes) {
            this.name = name;
            this.town = town;
            this.classes = classes;
        }
    });

    var SchoolClass = Class.create({
        init: function (name, capacity, students, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.students = students;
            this.formTeacher = formTeacher;
        }
    });

    var Person = Class.create({
        init: function (fName, lName, age) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        },

        introduce: function () {
            return "Hello! My name is " + this.fName + " " + this.lName + ", " + this.age + " years old, ";
        }
    });

    var Student = Class.create({
        init: function (fName, lName, age, grade) {
            this._super = new this._super(fName, lName, age);
            this._super.init(fName, lName, age);
            this.grade = grade;
        },

        introduce: function () {
            return this._super.introduce() + this.grade + " grade.";
        }
    });

    Student.inherit(Person);

    var Teacher = Class.create({
        init: function (fName, lName, age, specialty) {
            this._super = new this._super(fName, lName, age);
            this._super.init(fName, lName, age);
            this.specialty = specialty;
        },

        introduce: function () {
            return this._super.introduce() + "specialty - " + this.specialty + ".";
        }
    });

    Teacher.inherit(Person);

    return {
        School: School,
        SchoolClass: SchoolClass,
        Student: Student,
        Teacher: Teacher
    }
})();

// Demonstration
console.log("Classical implementation : ")
var students = [new schoolRepository.Student("Petar", "Petrov", 18, 12), new schoolRepository.Student("Georgi", "Dimitrov", 17, 11)];
var teacherIvanov = new schoolRepository.Teacher("Ivan", "Ivanov", 51, "gymnastics");
var classB = new schoolRepository.SchoolClass("B Class", 20, students, teacherIvanov);
var sportsSchoolClasses = [classB]
var sportsSchool = new schoolRepository.School("Men's health", "Detroit", sportsSchoolClasses);

console.log("School : " + sportsSchool.name)
console.log("Class : " + sportsSchool.classes[0].name)
console.log("Students : ")
for (var i = 0; i < sportsSchool.classes[0].students.length; i++) {
    console.log(sportsSchool.classes[0].students[i].introduce());
}

console.log("Form teacher : " + sportsSchool.classes[0].formTeacher.introduce());
console.log()
console.log()



