document.addEventListener('DOMContentLoaded', function () {
    forms.forEach(form => {
        form.addEventListener('submit', function (event) {
            event.preventDefault();  // Evita el envío inmediato del formulario

            const isCorrect = form.classList.contains('res_option_True');  

            if (isCorrect) {
                form.querySelector('input[type="submit"]').classList.add('correct-answer');  
            } else {
                form.querySelector('input[type="submit"]').classList.add('incorrect-answer');
            }

            setTimeout(() => {
                form.submit();  
            }, 1000);
        });
    });
});