/*
    **theme-toggle.js**
    * Controls Light/Dark Theme toggle on Body
    * Does not modify the Navbar and its contents
*/

document.addEventListener('DOMContentLoaded', (event) => {
    const toggle = document.getElementById('lightSwitch');

    // Light mode by default
    toggle.checked = false;

    toggle.addEventListener('change', () => {
        const newTheme = toggle.checked ? 'dark' : 'light';
        document.body.setAttribute('data-bs-theme', newTheme);
    });
});