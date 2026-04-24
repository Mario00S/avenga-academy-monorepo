// Title Generator
// Create 3 inputs:
// Color
// FontSize
// Text
// Create a button for generating titles
// When the button is clicked generate a new h1 element with the color, font size, and text from the inputs

let color = document.getElementById('color')
let fontSize = document.getElementById('font-size')
let text = document.getElementById('text')
let printedOutput = document.getElementById('print-text')

let btn = document.getElementById('btn')


btn.addEventListener('click', function() { 
let h1 = document.createElement('h1')
const c = color.value.trim().toLowerCase()
const allowedColors = ['red', 'blue', 'green', 'yellow']
let size = parseInt(fontSize.value)
if (size < 10 || size > 72 || Number.isNaN(size)) {
    alert("Please enter a number between 10 and 72")
    return   
}
if (c === "" || !allowedColors.includes(c)) {
    alert(`please enter a color from the allowed ones ${allowedColors}`)
    return
}
h1.style.color = c
h1.style.fontSize = size + "px"
h1.textContent = text.value
printedOutput.appendChild(h1)
})





// btn.addEventListener('click', function(e) { 
//     printedOutput.innerHTML = `
//     <h1
//     style='font-size:${fontSize.value}px;
//     color:${color.value}'>${text.value}
//     </h1> 
//     `
// })