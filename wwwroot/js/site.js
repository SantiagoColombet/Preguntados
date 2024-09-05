const configButton = document.getElementById('configButton');
const configMenu = document.getElementById('configMenu');
const closeButton = document.getElementById('closeButton');

configButton.addEventListener('click', () => {
    configMenu.style.display = 'block';
});

closeButton.addEventListener('click', () => {
    configMenu.style.display = 'none';
});