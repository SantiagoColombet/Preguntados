document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('.respuestas');
    forms.forEach(form => {
        form.addEventListener('submit', function (event) {
            event.preventDefault();
            const isCorrect = form.classList.contains('res_option_True');
            const submitButton = form.querySelector('input[type="submit"]');

            if (isCorrect) {
                submitButton.classList.add('correct-answer');
            } else {
                submitButton.classList.add('incorrect-answer');
                
                setTimeout(() => {
                    const correctForm = document.querySelector('.res_option_True');
                    if (correctForm) {
                        correctForm.querySelector('input[type="submit"]').classList.add('correct-answer');
                    }
                }, 1000);
            }
            setTimeout(() => {
                form.submit();
            }, 2000);
        });
    });
});