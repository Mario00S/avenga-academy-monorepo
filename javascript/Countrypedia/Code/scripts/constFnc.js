// 1. Select all the html elements needed for the implemntation
// 2. Implement function to fetch data from API (provide fields what kind of data do we need!)
// 3. Implement function that will display/hide spinner
// 4. Implement function that will display data in Cards
// 5. Implement function that will display data in Table
// 6. Implement 5 event listeners for the five buttons
// 6.1 Search, Reset, All from Europe, All neigbours MKD, MKD
// 7. Implement constructor function with props only needed for the data to be displayed

const url = "https://restcountries.com/v3.1/all?fields=name,capital,population,flags,region,borders,cca3";

let html = {
    searchInput: document.getElementById("inpSearch"),
    searchBtn: document.getElementById("btnSearch"),
    resetBtn: document.getElementById("btnReset"),
    europeBtn: document.getElementById("btnAllInEurope"),
    neighboursBtn: document.getElementById("btnNeighbours"),
    macedoniaBtn: document.getElementById("btnMacedonia"),
    spinner: document.getElementById("spinner"),
    cardContainer: document.getElementById("resultContainer").firstElementChild
}

class Country {
    constructor(name, capital, population, flag, region, borders, cca3) {
        this.name = name;
        this.capital = capital;
        this.population = population;
        this.flag = flag;
        this.region = region;
        this.borders = borders;
        this.cca3 = cca3
    }
}

class CountryController {
  constructor(html, url) {
    this.html = html;
    this.url = url;
  }

  init() {
    this.loadAllCountries()
    this.attachEventListeners()
  }

  displayCountries(countries) {
  this.html.cardContainer.innerHTML = "";
  countries.forEach(country => { 
    this.html.cardContainer.innerHTML += createCard(country);
  });
  toggleSpinner(false);
}

loadAllCountries() {
  toggleSpinner(true);
  getData(this.url)
    .then(countries => {
      this.displayCountries(countries);
    })
    .catch(err => {
      toggleSpinner(false);
      this.html.cardContainer.innerHTML = "<div class='row'><h3 class='text-danger'>Ooops something went wrong!</h3></div>";
    });
}

attachEventListeners() {
  this.html.resetBtn.addEventListener("click", () => this.reset());
  this.html.europeBtn.addEventListener("click", () => this.loadEuropeanCountries());
  this.html.searchBtn.addEventListener("click", () => this.search());
  this.html.macedoniaBtn.addEventListener("click", () => this.loadMkd());
  this.html.neighboursBtn.addEventListener("click", () => this.loadNeighbours());
}

loadEuropeanCountries() {
  toggleSpinner(true);
  getData(this.url)
    .then(countries => {
      const filteredCountries = countries.filter(c => c.region === "Europe");
      this.displayCountries(filteredCountries);
    });
}

reset(){
    this.html.searchInput.value = "";
    this.loadAllCountries()
}

search() {
  const term = this.html.searchInput.value.toLowerCase().trim();
  
  if (term === "") {
    alert("Please enter any character to search!");
    return;
  }
  
  toggleSpinner(true);
  getData(this.url)
    .then(countries => {
      const filtered = countries.filter(c =>
        c.name.toLowerCase().includes(term)
      );
      this.displayCountries(filtered);
    });
}

loadMkd() {
  toggleSpinner(true);
  getData(this.url)
    .then(countries => {
      const mkd = countries.find(c => c.name === "North Macedonia");
      if (mkd) {
        this.displayCountries([mkd]);
      } else {
        this.html.cardContainer.innerHTML = "<div class='row'><h3 class='text-danger'>North Macedonia not found!</h3></div>";
        toggleSpinner(false);
      }
    });
}

loadNeighbours() {
  toggleSpinner(true);
  getData(this.url)
    .then(countries => {
      const mkd = countries.find(c => c.name === "North Macedonia");
      console.log("MKD borders:", mkd.borders);  // Should show ["ALB", "BGR", ...]
      
      // TRY cca3 FIRST
      let neighbours = countries.filter(c => mkd.borders.includes(c.cca3));
      
      // If empty, try cioc
      if (neighbours.length === 0) {
        neighbours = countries.filter(c => mkd.borders.includes(c.cioc));
      }
      
      console.log("Found", neighbours.length, "neighbours");
      this.displayCountries(neighbours);
      toggleSpinner(false);
    });
}
}

const controller = new CountryController(html, url);
controller.init();



function toggleSpinner(showSpinner) {
    if (showSpinner) {
        html.spinner.classList.remove('d-none');
    }
    else {
        html.spinner.classList.add('d-none');
    }
}

// making this function with async in order to get localStorage
// the other approach required using Promise.resolve()
// adding clean data for the classes
async function getData(url) {
    const storedData = localStorage.getItem("countries")

    if (storedData !== null) {
        console.log("Local storage - testing in console")
        return JSON.parse(storedData)
    }else{

    console.log("fetch from API - testing in console")  
    const response = await fetch(url);
    const data = await response.json();
    const cleanData = data.map(c => new Country(c.name.common, c.capital[0], c.population, c.flags.png, c.region, c.borders, c.cca3))
    localStorage.setItem('countries', JSON.stringify(cleanData));
    console.log(cleanData)
    return cleanData;  
    }
}




function createCard(country) {
    return `
        <div class="col-4 mb-3">
            <div class="card" style="width: 25rem; height: 100%; display: flex; flex-direction: column;">
                <img src="${country.flag}" class="card-img-top" alt="${country.flag}" style="height: 250px; object-fit: cover; object-position: center;">
                <div class="card-body" style="display: flex; flex-direction: column; flex-grow: 1;">
                    <h5 class="card-title">${country.name}</h5>
                    <p class="card-text" style="flex-grow: 1;">${country.name} is a country with a population of ${country.population} citizens and the capital city is ${country.capital}</p>
                    <a href="https://en.wikipedia.org/wiki/${country.name}" class="btn btn-primary" target="_blank">Wikipedia</a>
                </div>
            </div>
        </div>
    `;
}

// initial page load

// getData(url)
//     .then(countries => {
//         console.log(countries);
//         countries.forEach(country => {
//             html.cardContainer.innerHTML += createCard(country);
//         });
//         toggleSpinner(false);
//     }).catch(err => {
//         toggleSpinner(false);
//         html.cardContainer.innerHTML = "<div class='row'><h3 class='text-danger'>Ooops something went wrong! Please try again later!</h3>"
//     })


// html.europeBtn.addEventListener("click", function () {
//     html.cardContainer.innerHTML = "";
//     toggleSpinner(true);

//     getData(url)
//         .then(countries => {
//             toggleSpinner(false);
//             let filteredCountries = countries
//                 .filter(c => c.region === "Europe");

//             filteredCountries.forEach(country => {
//                 html.cardContainer.innerHTML += createCard(country);
//             })
//         })

// })