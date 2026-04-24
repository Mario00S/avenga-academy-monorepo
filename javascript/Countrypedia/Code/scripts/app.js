// 1. Select all the html elements needed for the implemntation
// 2. Implement function to fetch data from API (provide fields what kind of data do we need!)
// 3. Implement function that will display/hide spinner
// 4. Implement function that will display data in Cards
// 5. Implement function that will display data in Table
// 6. Implement 5 event listeners for the five buttons
// 6.1 Search, Reset, All from Europe, All neigbours MKD, MKD
// 7. Implement constructor function with props only needed for the data to be displayed

const url = "https://restcountries.com/v3.1/all?fields=name,capital,population,flags,region";

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

function toggleSpinner(showSpinner) {
    if (showSpinner) {
        html.spinner.classList.remove('d-none');
    }
    else {
        html.spinner.classList.add('d-none');
    }
    // Or we can simply use toggle();
    // html.spinner.classList.toggle("d-none");
}

// making this function with async in order to get localStorage
// the other approach required using Promise.resolve()
async function getData(url) {
    const storedData = localStorage.getItem("countries")

    if (storedData !== null) {
        console.log("Local storage - testing in console")
        return JSON.parse(storedData)
    }else{

    console.log("fetch from API - testing in console")  
    const response = await fetch(url);
    const data = await response.json();
    localStorage.setItem('countries', JSON.stringify(data));
    return data  
    }
}

// initial page load
getData(url)
    .then(countries => {
        console.log(countries);
        countries.forEach(country => {
            html.cardContainer.innerHTML += createCard(country);
        });
        toggleSpinner(false);
    }).catch(err => {
        toggleSpinner(false);
        html.cardContainer.innerHTML = "<div class='row'><h3 class='text-danger'>Ooops something went wrong! Please try again later!</h3>"
    })


function createCard(country) {
    return `
        <div class="col-4 mb-3">
            <div class="card" style="width: 25rem; height: 100%; display: flex; flex-direction: column;">
                <img src="${country.flags.png}" class="card-img-top" alt="${country.flags.alt}" style="height: 250px; object-fit: cover; object-position: center;">
                <div class="card-body" style="display: flex; flex-direction: column; flex-grow: 1;">
                    <h5 class="card-title">${country.name.common}</h5>
                    <p class="card-text" style="flex-grow: 1;">${country.name.common} is a country with a population of ${country.population} citizens and the capital city is ${country.capital[0]}</p>
                    <a href="https://en.wikipedia.org/wiki/${country.name.common}" class="btn btn-primary" target="_blank">Wikipedia</a>
                </div>
            </div>
        </div>
    `;
}


html.europeBtn.addEventListener("click", function () {
    html.cardContainer.innerHTML = "";
    toggleSpinner(true);

    getData(url)
        .then(countries => {
            toggleSpinner(false);
            let filteredCountries = countries
                .filter(c => c.region === "Europe");

            filteredCountries.forEach(country => {
                html.cardContainer.innerHTML += createCard(country);
            })
        })

})