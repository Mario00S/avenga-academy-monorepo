// Student constructor function
// Create a constructor function for Student objects with:
// Properties:
// firstName
// lastName
// birthYear
// academy
// grades - array of numbers
// Methods:
// getAge() - returns age of student
// getInfo() - returns "This is student firstName* lastName* from the academy academy*!"
// getGradesAverage() - returns the average of the student grades
// Create an array with 3 students

// getAge() {
//     currentYear = new Date().getFullYear()
//     return currentYear - birthYear
// }

function student(firstName, lastName, birthYear, academy, grades) {
  this.firstName = firstName;
  this.lastName = lastName;
  this.birthYear = birthYear;
  this.academy = academy;
  this.grades = grades;

  this.getAge = function () {
    const currentYear = new Date().getFullYear();
    return currentYear - this.birthYear;
  };

  this.getInfo = function () {
    return `This is the student first name: ${this.firstName} and last name: ${this.lastName} from the academy: ${this.academy}`;
  };
  this.getGradesAverage = function () {
    if (this.grades.length === 0) {
      return null;
    }
    let sum = 0;
    for (const grade of this.grades) {
      sum += grade;
    }
    return sum / this.grades.length;
  };
}

let students = [
  new student("Mario", "Simonovski", 1991, "Avenga", [5, 4, 5, 3, 5, 3]),
  new student("Trajan", "Stevkovski", 1986, "Seavus", [5, 5, 5, 4, 4, 4]),
];

console.log(students[0].getInfo());
console.log(students[0].getAge());
console.log(students[0].getGradesAverage());
