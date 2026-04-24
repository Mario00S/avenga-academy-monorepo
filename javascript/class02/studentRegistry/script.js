// Create a student registry page
// Create an HTML page with student registry form with
// First Name
// Last Name
// Age
// Email
// Create a student generator function
// When the form is submitted, the inputs should be compiled into a new object from the generator function Student
// This student should be added to a list called "database"
// After submit the database should be printed in the console
// The input fields should be cleared

const database = []
let firstName = document.getElementById('first-name')
let lastName = document.getElementById('last-name')
let age = document.getElementById('age')
let email = document.getElementById('email')
// let btn = document.getElementById('btn')
let form = document.getElementById('form')

function studentGenerator (firstName, lastName, age, email) {
    firstName = firstName.value 
    lastName = lastName.value
    age = Number(age.value)
    email = email.value

    return { firstName, lastName, age, email };
}

form.addEventListener('submit', function(e){
    e.preventDefault()
    let student = studentGenerator (firstName, lastName, age, email)
    database.push(student)
    console.log(database)
    form.reset()

})


// console.log(studentGenerator(firstName, lastName, age, email));