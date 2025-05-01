/*SpeechCommandHandler.js
** This script handles the speech functionality
*/

let isListening = false;
async function toggleSpeech(tabType) {
    const button = tabType === 'imperial' ? document.getElementById("speechButtonImperial") : document.getElementById("speechButtonMetric");
    button.innerText = isListening ? "🎙️" : "🛑";
    isListening = !isListening;

    try {
        const res = await fetch('/Home/ToggleSpeechToText', { method: 'POST' });
        const data = await res.json();
        console.log("Speech API response:", data);

        if (data.success && data.text) {
            // Process the sentence
            processSpeechCommand(data.text.trim(), tabType);
        } else {
            console.warn("Speech recognition returned no usable result.");
            showErrorAlert("We couldn't understand your voice command. Please try again.");
            
        }
    } catch (err) {
        console.error("Fetch error:", err);
        showErrorAlert("An error occurred while contacting the speech API.");
    }

    button.innerText = "🎙️";
    isListening = false;
}

// New function to process the text
function processSpeechCommand(text, tabType) {
    const lowerText = text
        .toLowerCase()
        .replace(/£(\d+(?:\.\d+)?)/g, '$1 pounds')  // Converts £10 to 10 pounds
        .replace(/,/g, ''); // Strip commas from the whole string

    const regex = /convert\s+(-?\d{1,3}(?:,\d{3})*|\d+)(?:\.\d+)?\s+(\w+)\s+to\s+(\w+)/i;
    const match = lowerText.match(regex);
    // ERROR: Never reaches inside this if block -- FIXED
    if (match) {

        const cleanValue = match[1].replace(/,/g, '');
        const value = parseFloat(cleanValue);

        const fromUnit = match[2];
        const toUnit = match[3];

        if (tabType === 'imperial') {
            document.getElementById("imperialInput").value = value;
            selectDropdownOption('imperialSelect', fromUnit);
            selectDropdownOption('metricResultSelect', toUnit);
            // First trigger change events for dropdowns
            dispatchChangeEvent('imperialSelect');
            dispatchChangeEvent('metricResultSelect');

            // Then small timeout to trigger input event for the value
            setTimeout(() => {
                dispatchInputEvent('imperialInput');
            }, 100); // 100ms delay

        } else if (tabType === 'metric') {
            document.getElementById("metricInput").value = value;

            selectDropdownOption('metricSelect', fromUnit);
            selectDropdownOption('imperialResultSelect', toUnit);

            dispatchChangeEvent('metricSelect');
            dispatchChangeEvent('imperialResultSelect');

            setTimeout(() => {
                dispatchInputEvent('metricInput');
            }, 100); // 100ms delay
        }
        closeErrorAlert();
    } else {
        console.warn("Could not understand the speech command format.");
        showErrorAlert("We couldn't understand your voice command. Please try again with format 'Convert [Value] [FromUnit] to [ToUnit]'");
    }
}

// Helper to manually trigger input event
function dispatchInputEvent(elementId) {
    const event = new Event('input', { bubbles: true });
    document.getElementById(elementId).dispatchEvent(event);
}

// Helper to manually trigger change event
function dispatchChangeEvent(elementId) {
    const event = new Event('change', { bubbles: true });
    document.getElementById(elementId).dispatchEvent(event);
}

// Helper to select the correct option from a dropdown
function selectDropdownOption(selectId, unitName) {
    const select = document.getElementById(selectId);
    const options = Array.from(select.options);

    // Normalize the unit name the user said
    const normalizedUnit = unitName.trim().toLowerCase();

    // 1. Try exact text match (case-insensitive)
    let match = options.find(option => option.textContent.trim().toLowerCase() === normalizedUnit);

    // 2. If no exact match, fallback to contains (for more forgiving matching)
    if (!match) {
        match = options.find(option => option.textContent.trim().toLowerCase().includes(normalizedUnit));
    }

    if (match) {
        select.value = match.value;
    } else {
        console.warn(`Could not find a match for unit '${unitName}' in select '${selectId}'`);
    }
}

function showErrorAlert(message) {
    const errorDiv = document.getElementById("errorAlert");
    errorDiv.classList.remove("d-none");
    errorDiv.querySelector("strong").nextSibling.textContent = ` ${message || "There was an issue processing speech to text."}`;
}

function closeErrorAlert() {
    const errorDiv = document.getElementById("errorAlert");
    errorDiv.classList.add("d-none");
}