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