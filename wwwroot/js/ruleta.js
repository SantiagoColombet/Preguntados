let categorias = ["Cultura general", "Ciencia", "Deportes", "Argentina", "Tecnologia", "Geografia"];

document.addEventListener('DOMContentLoaded', () => {
  const wheel = document.querySelector('.ruleta');
  const spinBtn = document.querySelector('#spin');
  let deg = 0;

  spinBtn.addEventListener('click', () => {
    spinBtn.style.pointerEvents = 'none';
    
    deg = Math.floor(5000 + Math.random() * 360);
    
    wheel.style.transition = 'all 5s ease-out';
    wheel.style.transform = `rotate(${deg}deg)`;
  });

  wheel.addEventListener('transitionend', () => {
    spinBtn.style.pointerEvents = 'auto';

    wheel.style.transition = 'none';
    const actualDeg = deg % 360;
    wheel.style.transform = `rotate(${actualDeg}deg)`;
    const selectedCategory = getSelectedCategory(actualDeg);
    console.log(selectedCategory);
  });
  function getSelectedCategory(angle) {
    if (angle >= 0 && angle < 60) {
      return categorias[0];  
    } else if (angle >= 60 && angle < 120) {
      return categorias[1]; 
    } else if (angle >= 120 && angle < 180) {
      return categorias[2];
    } else if (angle >= 180 && angle < 240) {
      return categorias[3];
    } else if (angle >= 240 && angle < 300) {
      return categorias[4];
    } else if (angle >= 300 && angle <= 360) {
      return categorias[5]; 
    }
  }
});