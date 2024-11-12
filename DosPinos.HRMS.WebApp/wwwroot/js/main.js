const $menu = document.querySelector(".toggle-btn");

window.addEventListener('click', e => {
    if ($menu.contains(e.target)) document.querySelector("#sidebar").classList.toggle("expand");

});

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