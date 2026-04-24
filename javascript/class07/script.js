
let url =
  "https://raw.githubusercontent.com/sedc-codecademy/skwd9-04-ajs/main/Samples/students_v2.json";

// First approach

// function fetchData() {
//   fetch(url)
//     .then((response) => response.json())
//     return fetch(url)
//     .then((data) => {
//       console.log(data);
//       let aGrade = data.filter((st) => st.averageGrade > 3);
//       console.log("All students with an average grade higher than 3:", aGrade);
//       let fStudentsAverageGrade = data
//       .filter((st) => st.gender === "Female" && st.averageGrade === 5,)
//       .map(st => {
//         const {firstName, averageGrade} = st;
//         return {firstName, averageGrade}
//       })
//       console.log("Female students names with an average grade of 5:", fStudentsAverageGrade);
//       let mSkopje = data
//       .filter((st) => st.gender === "Male" && st.city === "Skopje" && st.age > 18)
//       .map(st => {
//         const {firstName, lastName, city, age} = st;
//         return {firstName, lastName, city, age}
//       })
//       console.log("Male students from Skopje over 18 years old:", mSkopje)
//     let mStudentsB = data
//     .filter((st) => st.gender === "Male" && st.averageGrade > 2 && st.firstName.startsWith('B'))
//     console.log
//     ("Male students with average grade above 2 and First Name starting on the letter B:", mStudentsB)
//     });
// }

    function fetchData(){
    return fetch(url)
        .then((response) => response.json())
    }


fetchData()
.then(allStGradesHigherThan3)
.then(fNamesGradesHigherThan3)
.then(mSCityOver18)
.then(mLetterB)
.then(fOver24)
.then(sOver30)
.then(sCityB)
.then(emails)
.then(sGradeEqual3)
.then(count)

// All students with an average grade higher than 3
    function allStGradesHigherThan3(data) {
        let result = data.filter((st) => st.averageGrade > 3);
        console.log("All students with an average grade higher than 3:", result);
        return data
    }

// All female student names with an average grade of 5    
    function fNamesGradesHigherThan3(data) {
        let fStudentsAverageGrade = data.filter((st) => st.gender === "Female" && st.averageGrade === 5)
      .map(st => {
        const {firstName, averageGrade} = st;
        return {firstName, averageGrade}
      })
      console.log("Female students names with an average grade of 5:", fStudentsAverageGrade);
      return data
    }

// All male student full names who live in Skopje and are over 18 years old
 
    function mSCityOver18(data) {
         let mSkopje = data
      .filter((st) => st.gender === "Male" && st.city === "Skopje" && st.age > 18)
      .map(st => {
        const {firstName, lastName, city, age} = st;
        return {firstName, lastName, city, age}
      })
      console.log("Male students from Skopje over 18 years old:", mSkopje)
      return data
    }

// All male students with a name starting with B and average grade over 2   
    function mLetterB(data){
    let mStudentsB = data
    .filter((st) => st.gender === "Male" && st.averageGrade > 2 && st.firstName.startsWith('B'))
    console.log
    ("Male students with average grade above 2 and First Name starting on the letter B:", mStudentsB)
    return data
    }

// The average grades of all female students over the age of 24
    function fOver24(data){
        let f = data
        .filter((st) => st.gender === "Female" && st.age > 24)
        .map(x => x.averageGrade)
        console.log("The average grades of all female students over 24:", f)
        return data
    }

// New requirements HOMEWORK

// All students who are older than 30 (return full name + age)
function sOver30(data){
    let s = data
    .filter((x) => x.age > 30)
    // .map(x => {
    //    const {firstName, lastName, age} = x
    //    return {firstName, lastName, age}   
    // })
    // cleaner approach
    .map(x => ({
        firstName: x.firstName,
        lastName: x.lastName,
        age: x.age
    }))
    console.log("All Stidents older than 30, fullname + age:", s)
    return data
}

// All students from a city that starts with B (return full name + city)
function sCityB(data){
    let s = data
    .filter((x) => x.city.startsWith("B"))
    .map(x => {
    return {firstName: x.firstName, lastName: x.lastName, city: x.city}
    })
    console.log("All students with a city that starts with B", s)
    return data
}

// All student emails (just an array of emails)
function emails(data){
    let s = data
    .map(x => x.email)
    console.log("All student emails:", s)
    return data
}
// All students with average grade exactly 3 (return full name)
function sGradeEqual3(data){
    let s = data
    .filter((x) => x.averageGrade === 3)
    .map(x => ({
        firstName: x.firstName,
        lastName: x.lastName,
    }))
    console.log("Students with average grade 3", s)
    return data
}
// Count how many students are Female and how many are Male
function count(data){
    let s = data
    .reduce((accumulator, student) => {
    if (student.gender === "Female") {
        accumulator.female = accumulator.female + 1
    }else{
    accumulator.male = accumulator.male + 1
    }  
    return accumulator  
    },
   {male: 0, female: 0} )
   console.log('There are:', s.male, "male students", "and", s.female, "female students") 
   return data
}

// adding event listeners to all of the tr-id's using object to link the functions

const rowFunctions = {
  'tr-1': allStGradesHigherThan3,
  'tr-2': fNamesGradesHigherThan3,
  'tr-3': mSCityOver18,
  'tr-4': mLetterB,
  'tr-5': fOver24,
  'tr-6': sOver30,
  'tr-7': sCityB,
  'tr-8': emails,
  'tr-9': sGradeEqual3,
  'tr-10': count
};

document.querySelectorAll('[id^="tr-"]').forEach(row => {
  row.addEventListener('click', () => {
    const func = rowFunctions[row.id];
    if (func) fetchData().then(func);
  });
});