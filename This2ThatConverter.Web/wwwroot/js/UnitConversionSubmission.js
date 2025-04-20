/* UnitConversionSubmission.js
** This script handles the submissions to the controller for Conversion Actions
*/


function sendConversionRequest(fromUnit, toUnit, value, resultInputId) {
    if (!fromUnit || !toUnit || isNaN(value)) return;

    fetch('/Home/ConvertUnit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ fromUnit, toUnit, value })
    })
        .then(res => res.json())
        .then(data => {
            const resultInput = document.getElementById(resultInputId);
            if (data.success) {
                resultInput.value = data.result.toFixed(4); // optional rounding
            } else {
                resultInput.value = "N/A";
            }
        })
        .catch(() => {
            document.getElementById(resultInputId).value = "Error";
        });
}

function setupRealTimeConversion(inputId, fromSelectId, toSelectId, resultInputId) {
    const input = document.getElementById(inputId);
    const fromSelect = document.getElementById(fromSelectId);
    const toSelect = document.getElementById(toSelectId);

    const trigger = () => {
        const from = fromSelect.value;
        const to = toSelect.value;
        const val = parseFloat(input.value);
        sendConversionRequest(from, to, val, resultInputId);
    };

    input.addEventListener('input', trigger);
    fromSelect.addEventListener('change', trigger);
    toSelect.addEventListener('change', trigger);
}

document.addEventListener('DOMContentLoaded', () => {
    setupRealTimeConversion('imperialInput', 'imperialSelect', 'metricResultSelect', 'imperialResultInput'); // Imperial to Metric
    setupRealTimeConversion('metricInput', 'metricSelect', 'imperialResultSelect', 'metricResultInput'); // Metric to Imperial
});