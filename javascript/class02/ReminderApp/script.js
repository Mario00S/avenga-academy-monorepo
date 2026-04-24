// Reminder App
// Create a reminder app
// There should be:
// An input for entering the title
// An input for entering priority
// An input for color
// A textarea for adding a description
// A button for adding the reminder
// A button for showing all reminders
// When the button for adding is clicked an object needs to be created with the
// properties from the inputs ( title, priority, color, and description )
// The object should then be added to an array of reminders
// When the button for showing all reminders is clicked it should show a table with title, priority, and description columns
// The title should be the color of the "color" property

const remindersArr = [];

let titleInput = document.getElementById("title");
let priorityInput = document.getElementById("priority");
let colorInput = document.getElementById("color");
let descriptionInput = document.getElementById("description");
let addBtn = document.getElementById("add-reminder");
let showBtn = document.getElementById("show-reminders");
let printTable = document.getElementById("print-table");
let form = document.getElementById("form");

addBtn.addEventListener("click", function (e) {
  e.preventDefault();

  let obj = {
    title: titleInput.value.trim(),
    priority: priorityInput.value.trim(),
    color: colorInput.value.trim(),
    description: descriptionInput.value.trim(),
  };

  // empty fields validation
  if (!obj.title || !obj.priority || !obj.color || !obj.description) {
    alert("Please populate all of the fields before adding a reminder.");
    return;
  }

  // priority validation
  if (obj.priority <= 0 || obj.priority >= 10) {
    alert("the priority must be higher than 0 and less than 10");
    return;
  }
  // color validation, a function that validates all of the colors
  const isValidColor = (color) => {
    const element = new Option();
    element.style.color = color;
    return !!element.style.color;
  };
  // color validation statement, simplest soultion
  if (!isValidColor(obj.color)) {
    alert("Invalid Color");
    return;
  }

  remindersArr.push(obj);
  console.log("Just pushed:", obj);
  console.log("New array:", remindersArr);
  alert(`Reminder added: ${obj.title}`);
  form.reset();
});

showBtn.addEventListener("click", function () {
  let table = document.createElement("table");
  printTable.textContent = "";
  printTable.appendChild(table);
  table.style.border = "1px solid black";

  let headerRow = table.insertRow();
  let headerTitle = headerRow.insertCell();
  headerTitle.textContent = "Title";
  let headerPriority = headerRow.insertCell();
  headerPriority.textContent = "Priority";
  let headerDesc = headerRow.insertCell();
  headerDesc.textContent = "Description";

  if (remindersArr.length === 0) {
    alert("no reminders yet");
    return;
  }

  // let row = table.insertRow()
  // row.insertCell(obj.title,obj.priority,obj.description)

  for (let i = 0; i < remindersArr.length; i++) {
    let obj = remindersArr[i];
    let row = table.insertRow();

    // now the columns 1 Title
    let titleCell = row.insertCell();
    titleCell.style.border = "1px solid black";
    titleCell.textContent = obj.title;
    titleCell.style.color = obj.color;
    // column 2 priority
    let priorityCell = row.insertCell();
    priorityCell.textContent = obj.priority;
    priorityCell.style.border = "1px solid black";

    // column 3 description
    let descriptionCell = row.insertCell();
    descriptionCell.textContent = obj.description;
    descriptionCell.style.border = "1px solid black";
  }
  console.log("Created", table.rows.length, "rows");
  console.log("First row cells:", table.rows[0]?.cells.length);
});

// addBtn.addEventListener('click', function(){
//     let obj = {
//         title: titleInput.value,
//         priority: priorityInput.value,
//         color: colorInput.value,
//         description: descriptionInput.value
//     }
//     if (remindersArr.length === 0) {
//         alert("no reminders yet")
//     } else {
//  remindersArr.push(obj)
//   window.alert(`reminder added ${obj.title}`)
//     }

//  form.reset()
// })
