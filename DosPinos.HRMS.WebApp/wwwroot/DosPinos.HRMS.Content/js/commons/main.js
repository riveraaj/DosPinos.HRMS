//Sidebar Menu
const $menu = document.querySelector(".toggle-btn");

window.addEventListener('click', e => {
    if ($menu.contains(e.target)) document.querySelector("#sidebar").classList.toggle("expand");
});

//Alerts
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

function showConfirmationAlertRaw(html, icon = 'info') {
    return Swal.fire({
        title: '¿Estás seguro?',
        html: html,
        icon: icon, // 'info' o 'question'
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
        buttonsStyling: true
    }).then((result) => {
        return result.isConfirmed; // Retorna true si se confirma, false si se cancela
    });
}

//Loader
const showLoader = () =>  {
    const $loader = document.getElementById('loader'); 
    $loader.style.display = "flex";
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