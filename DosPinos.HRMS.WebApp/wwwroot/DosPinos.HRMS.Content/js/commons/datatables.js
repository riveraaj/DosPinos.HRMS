﻿window.addEventListener('load', () => {
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