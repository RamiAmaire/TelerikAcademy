var SchoolRepository = (function () {
    var School = {
        init: function (name, city, classes) {
            this.name = name;
            this.city = city;
            this.classes = classes;
        }
    };

    var SchoolClass = {
        init: function (name, capacity, students, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.students = students;
            this.formTeacher = formTeacher;
        }
    };

    var Person = {
        init: function (fName, lName, age) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        },

        introduce: function () {
            var introduce = "Hello, I'am " + this.fName + " " + this.lName + ", " + this.age + " years old.";
            return introduce;
        }
    };

    var Student = Person.extend({
        init: function (fNname, lName, age, grade) {
            this._super.init.apply(this, arguments);
            this.grade = grade;
        },

        introduce: function () {
            var introduce = this._super.introduce.apply(this) + " " + this.grade + " grade.";
            return introduce;
        }
    });

    var Teacher = Person.extend({
        init: function (fName, lName, age, specialty) {
            this._super.init.apply(this, arguments);
            this.specialty = specialty;
        },

        introduce: function () {
            var introduce = this._super.introduce.apply(this) + " " + this.specialty + " specialty.";
            return introduce;
        }
    });

    return {
        School: School,
        SchoolClass: SchoolClass,
        Student: Student,
        Teacher: Teacher
    }
})();

var School = SchoolRepository.School;
var SchoolClass = SchoolRepository.SchoolClass;
var Student = SchoolRepository.Student;
var Teacher = SchoolRepository.Teacher;

var ivanov = Object.create(Teacher);
ivanov.init("Goergi", "Ivanov", 51, "Athletics");

var goshko = Object.create(Student);
goshko.init("Georgi", "Georgiev", 11, 6);

var petko = Object.create(Student);
petko.init("Petko", "Atanasov", 11, 6);

var students = [goshko, petko]

var classAthletics = Object.create(SchoolClass);
classAthletics.init("Athletics and muscle", 20, students, ivanov);

var classes = [classAthletics];

var detroitFirstSchool = Object.create(School);
detroitFirstSchool.init("First School of Detroit", "Detroit", classes);