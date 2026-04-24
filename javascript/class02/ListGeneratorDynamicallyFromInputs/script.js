// List Generator dynamically from inputs
// Create 3 inputs:
// Color
// FontSize
// Items
// Create a button for generating unordered lists
// When the button is clicked generate a new ul element with the color, font size, and items from the inputs
// Items should be added separated by "," in the input
// optional add validation





let colorInput = document.getElementById('color')
let fontSizeInput = document.getElementById('font-size')
let items = document.getElementById('items')
let btn = document.getElementById('btn')
let printedOutput = document.getElementById('print-text')

btn.addEventListener('click', function(){
    printedOutput.innerHTML = ""
    // turn input string into an array
    let itemsArray = items.value.split(',')
    let ul = document.createElement('ul')
    
    for (let i = 0; i < itemsArray.length; i++) {
        let li = document.createElement('li')
        li.textContent = itemsArray[i].trim()
        ul.appendChild(li)       
    }

    ul.style.color = colorInput.value
    ul.style.fontSize = fontSizeInput.value + "px"

    printedOutput.appendChild(ul)
})




