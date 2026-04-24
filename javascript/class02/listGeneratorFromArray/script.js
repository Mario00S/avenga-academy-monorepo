// List generator from an array
// Create an array of 5 names
// Create an HTML page with:
// A header
// An empty unordered list
// A button
// When the button is clicked it should fill in the empty unordered list with the names of the array

let namesArr = ["Mario", "George", "Ben", "Stacy", "Joana"]
let ul = document.getElementById('empty-list')
let btn = document.getElementById('btn')

btn.addEventListener('click', function(){
    ul.innerHTML = ""
    for (let i = 0; i < namesArr.length; i++) {
        let li = document.createElement('li')
        li.textContent = namesArr[i]
        ul.appendChild(li)  
    }
})

