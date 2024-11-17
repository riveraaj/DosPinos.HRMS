const $menu = document.querySelector(".toggle-btn");

window.addEventListener('load', () => {
    new DataTable('.data-table', {
        language: {
            url: "https://cdn.datatables.net/plug-ins/2.1.8/i18n/es-MX.json"
        },

        buttons: [
            'pdf',
        ],
    });
}); 

window.addEventListener('click', e => {
    if ($menu.contains(e.target)) document.querySelector("#sidebar").classList.toggle("expand");
});

function showConfirmationAlert(message, icon = 'info') {
    return Swal.fire({
        title: '¿Estás seguro?',
        text: message,
        icon: icon, // 'info' o 'question'
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
        buttonsStyling: true
    }).then((result) => {
        return result.isConfirmed; // Retorna true si se confirma, false si se cancela
    });
}

//Disabling form submissions if there are invalid fields
(() => {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
    })
})()