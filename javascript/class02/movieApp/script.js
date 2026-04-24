// Movies renting App
// Create a movie renting app
// There should be an array of movie names
// There should be an input and a search button
// When the person enters a name of a movie it should search the array
// If the name exists it should show an H1 element that says: "The movie can be rented" in green text
// If the name does not exist it should show an H1 element that says: "The movie can't be rented" in red text
// The input should not be case sensitive ( it should find the movie regardless of capital or small letters )


const movies = [
    "Rambo",
    "Rocky",
    "Lord of the Rings",
    "The Matrix",
    "Rambo 2",
    "Rocky 2"
]

let inputMovie = document.getElementById('movie-input');
let searchBtn = document.getElementById('search-btn')
let printedOutput = document.getElementById('printed-output')

searchBtn.addEventListener('click', function(){
   let h1 = document.createElement('h1')
   let result = search(movies)
   h1.textContent = result
   
    if (result === "The movie can't be rented") {
        h1.style.color = 'red'
    } else{
        h1.style.color = 'green'
    } 

   printedOutput.textContent = ""
   printedOutput.appendChild(h1)
})


function search (input) {
    let searchMovie = inputMovie.value.trim().toLowerCase()
    for (let i = 0; i < input.length; i++) {
if (searchMovie === input[i].toLowerCase()) {
    return `The movie: ${input[i]} can be rented`
}  
     }return "The movie can't be rented"
}