// Exercise 2
// Create a button When the button is clicked, call the StarWars api for the first person.
// Print the person name in an h1 tag.
// Print the person stats in a table:

// Height
// Weight
// Eye color
// Hair color
// URL: https://swapi.py4e.com/api/people/1 \

let url = "https://swapi.py4e.com/api/people/1"
let btn = document.getElementById('btn')
let printedOutput = document.getElementById('print')

btn.addEventListener('click', function(){
    fetch(url)

    .then(function(response){
        console.log(response)
        return response.json()
    })
    .then(function(data){
        printedOutput.innerHTML = ''
        let h1 = document.createElement('h1')
        h1.textContent = data.name
        let table = document.createElement('table')

        const personData = {
    height: data.height,
    mass: data.mass,
    hair_color: data.hair_color,
    skin_color: data.skin_color,
    eye_color: data.eye_color,
    birth_year: data.birth_year,
    gender: data.gender
}

function styleCell(cell) {
    cell.style.border = '1px solid black';
    cell.style.padding = '8px';
}

            for(let statName in personData) {
        let row = table.insertRow();
        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        cell1.textContent = statName.replace('_', ' ')  
        cell2.textContent = personData[statName]
styleCell(cell1)
styleCell(cell2)
    }
        printedOutput.appendChild(h1)
        printedOutput.appendChild(table)

        console.log(data)
    })

    .catch(function(error){
        console.log(error)
    })
})
