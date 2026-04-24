let today = getTodaysDate();
let btn = document.getElementById("btn");
let cors = "https://corsproxy.io/?";
let url = `${cors}https://www.nbrm.mk/KLServiceNOV/GetExchangeRate?StartDate=${today}&EndDate=${today}&format=json`;
let print = document.getElementById("print-content");

function getTodaysDate() {
  let date = new Date();
  let day = date.getDate();
  if (day < 10) {
    day = "0" + day;
  }

  let month = date.getMonth() + 1;
  if (month < 10) {
    month = "0" + month;
  }

  let year = date.getFullYear();

  return `${day}.${month}.${year}`;
}

function fetchData() {
  fetch(url)
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      createTable(data);
    })
    .catch((error) => console.log(error));
}

btn.addEventListener("click", fetchData);
console.log(today);

console.log(url);

function createTable(data) {
  let htmlString = `<table class="table table-bordered table-striped">
  <thead>
  <tr>
  <th>Currency</th>
  <th>Rate</th>
  <th>Country</th>
  </tr>
  </thead>
  <tbody>`;

  for (let i = 0; i < data.length; i++) {
    let currentObj = data[i];
    let currency = currentObj.oznaka;
    let rate = currentObj.sreden;
    let country = currentObj.drzava;

    htmlString += `
    <tr>
      <td>${currency}</td>
      <td>${rate}</td>
      <td>${country}</td>
    </tr>
  `;
  }
  htmlString += `</tbody></table>`;
  console.log("Html String:", htmlString);
  print.innerHTML = htmlString;
  console.log("print element", print);
}
