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
    });
  });