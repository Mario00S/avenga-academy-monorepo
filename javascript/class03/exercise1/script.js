// Exercise 1
// Create a button When the button is clicked, get the data from a given url with an AJAX call.
// Print the name of the academy in an h1 tag.
// Print all student names in an unordered list.
// URL: https://raw.githubusercontent.com/qa-codecademy/mkwd13-04-ajs/refs/heads/main/shared_data/students.json
// NOTE: You need to parse this data before using it.

let print = document.getElementById("printedOutput");
let btn = document.getElementById("btn");
let url =
  "https://raw.githubusercontent.com/qa-codecademy/mkwd13-04-ajs/refs/heads/main/shared_data/students.json";

btn.addEventListener("click", function () {
  print.innerHTML = "";
  fetch(url)
    .then(function (response) {
      console.log(response);
      return response.json();
    })
    .then(function (data) {
      let h1 = document.createElement("h1");
      let ul = document.createElement("ul");
      let h3Text = document.createElement("h3");
      h3Text.textContent = "The students are:";
      h1.textContent = `The name of the academy is: ${data.academy}`;
      print.appendChild(h1);
      print.appendChild(h3Text);
      print.appendChild(ul);

      for (let i = 0; i < data.students.length; i++) {
        let li = document.createElement("li");
        li.textContent = data.students[i];
        ul.appendChild(li);
      }
      console.log(data);
    })
    .catch(function (error) {
      console.log(error);
    });
});
