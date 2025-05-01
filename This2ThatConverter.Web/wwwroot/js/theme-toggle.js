/*
    **theme-toggle.js**
    * Controls Light/Dark Theme toggle on Body
    * Does not modify the Navbar and its contents
*/

document.addEventListener('DOMContentLoaded', () => {
    const toggle = document.getElementById('lightSwitch');

    // Get the saved theme from localStorage
    const savedTheme = localStorage.getItem('theme') || 'light';

    // Apply saved theme
    document.body.setAttribute('data-bs-theme', savedTheme);
    toggle.checked = (savedTheme === 'dark');

    // Listen for toggle changes
    toggle.addEventListener('change', () => {
        const newTheme = toggle.checked ? 'dark' : 'light';
        document.body.setAttribute('data-bs-theme', newTheme);
        localStorage.setItem('theme', newTheme);
    });
});