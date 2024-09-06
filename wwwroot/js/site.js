const configButton = document.getElementById('configButton');
const configMenu = document.getElementById('configMenu');
const closeButton = document.getElementById('closeButton');

configButton.addEventListener('click', () => {
    configMenu.style.display = 'block';
});

closeButton.addEventListener('click', () => {
    configMenu.style.display = 'none';
});



// document.querySelector('.ruleta').addEventListener('click', function() {
//     const grados = Math.floor(Math.random() * 360);
//     this.style.transform = `rotate(${grados}deg)`;
// });

let container = document.querySelector(".container");
let btn = document.getElementById("spin");
let number = Math.ceil(Math.random() * 1000);

btn.onclick = function () {
	container.style.transform = "rotate(" + number + "deg)";
	number += Math.ceil(Math.random() * 1000);
}