/*
    **UnitConversionDropdown.js**
*This script manages the dynamic dropdown functionality
*/


// Dynamic Unit Dropdown
const units = {
    weight: {
        imperial: ["Ounces", "Pounds", "Stones", "Imperial Ton"],
        metric: ["Milligrams", "Grams", "Kilograms", "Metric Ton"]
    },
    length: {
        imperial: ["Inches", "Feet", "Yards", "Miles"],
        metric: ["Millimeters", "Centimeters", "Meters", "Kilometers"]
    },
    temperature: {
        imperial: ["Fahrenheit"],
        metric: ["Celsius"]
    }
};

// Category
const categorySelect = document.getElementById('categorySelect');

// Tab 1: Imperial to Metric
const imperialSelect = document.getElementById('imperialSelect');
const metricResultSelect = document.getElementById('metricResultSelect');

// Tab 2: Metric to Imperial
const metricSelect = document.getElementById('metricSelect');
const imperialResultSelect = document.getElementById('imperialResultSelect');

function populateSelects(category) {
    const imperialUnits = units[category].imperial;
    const metricUnits = units[category].metric;

    // Imperial to Metric
    if (imperialSelect && metricResultSelect) {
        imperialSelect.innerHTML = '<option selected disabled>-- Select Unit --</option>';
        metricResultSelect.innerHTML = '<option selected disabled>-- Select Unit --</option>';

        imperialUnits.forEach(unit => {
            const option = document.createElement('option');
            option.value = unit.toLowerCase().replace(/\s/g, '');
            option.textContent = unit;
            imperialSelect.appendChild(option);
        });

        metricUnits.forEach(unit => {
            const option = document.createElement('option');
            option.value = unit.toLowerCase().replace(/\s/g, '');
            option.textContent = unit;
            metricResultSelect.appendChild(option);
        });
    }

    // Metric to Imperial
    if (metricSelect && imperialResultSelect) {
        metricSelect.innerHTML = '<option selected disabled>-- Select Unit --</option>';
        imperialResultSelect.innerHTML = '<option selected disabled>-- Select Unit --</option>';

        metricUnits.forEach(unit => {
            const option = document.createElement('option');
            option.value = unit.toLowerCase().replace(/\s/g, '');
            option.textContent = unit;
            metricSelect.appendChild(option);
        });

        imperialUnits.forEach(unit => {
            const option = document.createElement('option');
            option.value = unit.toLowerCase().replace(/\s/g, '');
            option.textContent = unit;
            imperialResultSelect.appendChild(option);
        });
    }
}

categorySelect.addEventListener('change', (e) => {
    const selectedCategory = e.target.value;
    populateSelects(selectedCategory);
});

document.addEventListener('DOMContentLoaded', () => {
    populateSelects(categorySelect.value);
});