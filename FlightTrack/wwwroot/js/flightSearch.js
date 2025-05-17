let currentPage = 1;
let pageSize = 10;
let currentResults = [];

document.addEventListener('DOMContentLoaded', function() {

    document.getElementById('citySearchForm').addEventListener('submit', function(e) {
        e.preventDefault();
        searchByCities();
    });

    document.getElementById('countrySearchForm').addEventListener('submit', function(e) {
        e.preventDefault();
        searchByCountries();
    });

    setupCityAutocomplete('departureCity', 'departureCitySuggestions');
    setupCityAutocomplete('arrivalCity', 'arrivalCitySuggestions');

    document.getElementById('prevPage').addEventListener('click', () => changePage(-1));
    document.getElementById('nextPage').addEventListener('click', () => changePage(1));
});

function setupCityAutocomplete(inputId, suggestionsId) {
    const input = document.getElementById(inputId);
    const suggestions = document.getElementById(suggestionsId);
    let debounceTimer;

    input.addEventListener('input', function() {
        clearTimeout(debounceTimer);
        debounceTimer = setTimeout(() => fetchCitySuggestions(input, suggestions), 300);
    });

    input.addEventListener('blur', function() {
        setTimeout(() => suggestions.style.display = 'none', 200);
    });

    input.addEventListener('focus', function() {
        if (input.value) {
            fetchCitySuggestions(input, suggestions);
        }
    });
}

async function fetchCitySuggestions(input, suggestionsDiv) {
    if (!input.value.trim()) {
        suggestionsDiv.style.display = 'none';
        return;
    }

    try {
        const response = await fetch(`/api/flightsearch/cities/suggest?query=${encodeURIComponent(input.value)}`);
        const suggestions = await response.json();

        suggestionsDiv.innerHTML = '';
        
        suggestions.forEach(suggestion => {
            const div = document.createElement('div');
            div.className = 'suggestion-item';
            div.textContent = `${suggestion.city} - ${suggestion.airport} (${suggestion.iata}), ${suggestion.country}`;
            div.addEventListener('click', () => {
                input.value = suggestion.city;
                suggestionsDiv.style.display = 'none';
            });
            suggestionsDiv.appendChild(div);
        });

        suggestionsDiv.style.display = suggestions.length ? 'block' : 'none';
    } catch (error) {
        console.error('Error fetching city suggestions:', error);
    }
}

function showLoading() {
    document.getElementById('loadingSpinner').classList.remove('d-none');
    document.getElementById('searchResults').classList.add('d-none');
    document.getElementById('errorAlert').classList.add('d-none');
}

function hideLoading() {
    document.getElementById('loadingSpinner').classList.add('d-none');
}

function showError(message) {
    const errorAlert = document.getElementById('errorAlert');
    errorAlert.textContent = message;
    errorAlert.classList.remove('d-none');
}

function updatePaginationInfo() {
    const startRecord = (currentPage - 1) * pageSize + 1;
    const endRecord = Math.min(currentPage * pageSize, currentResults.length);
    const totalRecords = currentResults.length;

    document.getElementById('startRecord').textContent = startRecord;
    document.getElementById('endRecord').textContent = endRecord;
    document.getElementById('totalRecords').textContent = totalRecords;

    document.getElementById('prevPage').disabled = currentPage === 1;
    document.getElementById('nextPage').disabled = endRecord >= totalRecords;
}

function changePage(delta) {
    currentPage += delta;
    displayResults(currentResults, false);
}

function displayResults(flights, resetPagination = true) {
    const resultsBody = document.getElementById('resultsBody');
    resultsBody.innerHTML = '';
    
    if (!flights || flights.length === 0) {
        showError('No flights found for the specified criteria.');
        return;
    }

    if (resetPagination) {
        currentPage = 1;
        currentResults = flights;
    }

    const startIdx = (currentPage - 1) * pageSize;
    const endIdx = Math.min(startIdx + pageSize, flights.length);
    const displayedFlights = flights.slice(startIdx, endIdx);

    displayedFlights.forEach(flight => {
        const row = document.createElement('tr');

        const depTime = new Date(flight.departure.scheduled);
        const formattedDepTime = `${flight.departure.airport} (${flight.departure.iata})<br>${depTime.toLocaleString()}`;
        
        const arrTime = new Date(flight.arrival.scheduled);
        const formattedArrTime = `${flight.arrival.airport} (${flight.arrival.iata})<br>${arrTime.toLocaleString()}`;

        row.innerHTML = `
            <td>${flight.flight.iata || flight.flight.icao}</td>
            <td>${flight.airline.name} (${flight.airline.iata})</td>
            <td>${formattedDepTime}</td>
            <td>${formattedArrTime}</td>
            <td>${flight.flight_status}</td>
            <td>
                <button class="btn btn-sm btn-primary" onclick="trackFlight('${flight.flight.iata}')">Track</button>
            </td>
        `;
        
        resultsBody.appendChild(row);
    });

    document.getElementById('searchResults').classList.remove('d-none');
    updatePaginationInfo();
}

async function searchByCities() {
    showLoading();
    
    const depCity = document.getElementById('departureCity').value;
    const arrCity = document.getElementById('arrivalCity').value;
    const date = document.getElementById('cityDate').value;
    
    try {
        const response = await fetch(`/api/flightsearch/cities?departureCity=${encodeURIComponent(depCity)}&arrivalCity=${encodeURIComponent(arrCity)}${date ? `&date=${date}` : ''}`);
        const data = await response.json();
        
        if (!response.ok) {
            throw new Error(data.error || 'Failed to fetch flight data');
        }
        
        displayResults(data.data);
    } catch (error) {
        showError(error.message);
    } finally {
        hideLoading();
    }
}

async function searchByCountries() {
    showLoading();
    
    const depCountry = document.getElementById('departureCountry').value;
    const arrCountry = document.getElementById('arrivalCountry').value;
    const date = document.getElementById('countryDate').value;
    
    try {
        const response = await fetch(`/api/flightsearch/countries?departureCountry=${encodeURIComponent(depCountry)}&arrivalCountry=${encodeURIComponent(arrCountry)}${date ? `&date=${date}` : ''}`);
        const data = await response.json();
        
        if (!response.ok) {
            throw new Error(data.error || 'Failed to fetch flight data');
        }
        
        displayResults(data.data);
    } catch (error) {
        showError(error.message);
    } finally {
        hideLoading();
    }
}

async function trackFlight(flightNumber) {
    try {
        const response = await fetch('/api/userflights/track', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ flightNumber })
        });

        if (!response.ok) {
            const data = await response.json();
            throw new Error(data.error || 'Failed to track flight');
        }

        alert('Flight added to tracking list!');
    } catch (error) {
        showError(error.message);
    }
} 