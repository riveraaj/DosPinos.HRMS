const $menu = document.querySelector(".toggle-btn");

window.addEventListener('load', () => {
    new DataTable('.data-table', {
        language: {
            url: "https://cdn.datatables.net/plug-ins/2.1.8/i18n/es-MX.json",

            paginate: {
                previous: '<i class="bi bi-caret-left text-white"></i>',
                next: '<i class="bi bi-caret-right text-white"></i>',
            },

            aria: {
                paginate: {
                    previous: 'Previous',
                    next: 'Next',
                }
            }
        },
        pagingType: 'simple_numbers',
        responsive: true,

        initComplete: function () {
            const $searchLabel = document.querySelector('.dt-search label'),
                $searchInput = document.getElementById('dt-search-0'),
                $searchIcon = document.createElement('i'),
                $parentNode = $searchInput.parentNode;

            $searchIcon.className = 'bi bi-search position-absolute end-0 top-0 z-3 me-2 mt-2';
            $searchInput.className += ' py-2 border-black ms-0'
            $parentNode.className += ' position-relative'

            $searchLabel.remove();
            $searchInput.setAttribute('placeholder', 'Búsqueda');
            $parentNode.appendChild($searchIcon);
        }
    });

    new DataTable('.report-table', {
        language: {
            url: "https://cdn.datatables.net/plug-ins/2.1.8/i18n/es-MX.json",

            paginate: {
                previous: '<i class="bi bi-caret-left"></i>',
                next: '<i class="bi bi-caret-right"></i>',
            },

            aria: {
                paginate: {
                    previous: 'Previous',
                    next: 'Next',
                }
            }
        },
        layout: {
            topStart: 'search',
            topEnd: 'buttons'
        },
        buttons: {
            buttons: [
                {
                    extend: 'pdf',
                    text: ' <i class="bi bi-download pe-1"></i> Descargar exportación',
                    className: 'bg-transparent text-black',
                }
            ]
        },
        pagingType: 'simple_numbers',
        responsive: true,

        initComplete: function () {
            const $searchLabel = document.querySelector('.dt-search label'),
                $searchInput = document.getElementById('dt-search-0'),
                $searchIcon = document.createElement('i'),
                $parentNode = $searchInput.parentNode;

            $searchIcon.className = 'bi bi-search position-absolute end-0 top-0 z-3 me-2 mt-2';
            $searchInput.className += ' py-2 border-black ms-0'
            $parentNode.className += ' position-relative'

            $searchLabel.remove(); 
            $searchInput.setAttribute('placeholder', 'Búsqueda');
            $parentNode.appendChild($searchIcon);
        }
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