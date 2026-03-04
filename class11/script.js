// #Exercises

// Exercise 1
// Create a Person constructor function that has:

// firstName
// lastName
// age
// getFullName - method



// Create a Student constructor function that inherits from Person and has:
// academyName
// studentId
// study - method that writes in the console: The student firstName is studying in the academyName
// Create two Student objects

// Exercise 2
// Create a method on the Person prototype that accepts a Student of any academy and returns the academy that that student is in.

// Create DesignStudent, CodeStudent and NetworkStudent constructor functions that inherit from Student.

// DesignStudent
// isStudentOfTheMonth - boolean
// attendAdobeExam - method that writes in console: The student firstName is doing an adobe exam!
// CodeStudent
// hasIndividualProject - boolean
// hasGroupProject - boolean
// doProject(type) - method that accepts string. If the string is individual or group it should write that the person is working on the project of that type and set the value to true on the property of the project
// NetworkStudent
// academyPart - number
// attendCiscoExam - method that writes in console: the student firstNAme is doing a cisco exam!
// Note: For all students, the academyName property should be auto generated based on which Student we are creating ( design, code or network )

// Create one of each students Check all students with the Student method for checking students academy

function Person(firstName,lastName,age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;

    this.getFullName = function(){
        return `${this.firstName} ${this.lastName}`
    }
}


Person.prototype.academyMethod = function(){
    console.log(`${this.firstName} is studying at ${this.academyName}`)
}

function Student(firstName, lastName, age, academyName, studentId){
    Object.setPrototypeOf(this, new Person(firstName, lastName, age));
    this.academyName = academyName;
    this.studentId = studentId;

    this.study = function() {
        console.log(`The student ${firstName} is studying in ${academyName}`)
    }
}


function DesignStudent(firstName, lastName, age, academyName, studentId, isStudentOfTheMonth){
    Object.setPrototypeOf(this, new Student(firstName, lastName, age, academyName, studentId));
    this.isStudentOfTheMonth = isStudentOfTheMonth;

    this.attendAdobeExam = function(){
        console.log(`The student ${firstName} is doing an adobe exam!`)
    }
}


function CodeStudent(firstName, lastName, age, academyName, studentId, hasIndividualProject, hasGroupProject){
    Object.setPrototypeOf(this, new Student(firstName, lastName, age, academyName, studentId));
    this.hasIndividualProject = hasIndividualProject;
    this.hasGroupProject = hasGroupProject;

    this.doProject = function(type){
    console.log(`The project that ${this.firstName} is working on is ${type}`)
        if (type === "individual") {
            this.hasIndividualProject = true
        } else if(type === "group") {
             this.hasGroupProject = true    
             }
    }
}

function NetworkStudent(firstName, lastName, age, academyName, studentId, academyPart){
    Object.setPrototypeOf(this, new Student(firstName,lastName,age,academyName,studentId));
    this.academyPart = academyPart;

    this.attendCiscoExam = function(){
        console.log(`The student ${this.firstName} is doing a cisco exam`)
    }
}




let devOps = new NetworkStudent('Brian', "Bell", 28, "Cisco Academy", 15, 3)
let student2 = new Student('John', 'Johnson', 29, 'Quinshift academy', 2)
let designer = new DesignStudent("Dominque", "DeCoCo", 27, "Design Academy", 3, false)
let coder = new CodeStudent("Mario", "Simonovski", 34, "Avenga Academy", 1, false, false)


