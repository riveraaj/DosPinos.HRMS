﻿//Edit filds
document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('.update-form');

    forms.forEach(form => {
        form.addEventListener('change', function (e) {
            e.preventDefault(); 
            const url = form.getAttribute('data-url'),
                formData = new FormData(form);
            let emptyInputs = false;

            formData.forEach((value, key) => {
                if (value === "" || value === null || value == 0) emptyInputs = true;
            });

            const data = new URLSearchParams(formData);

            if (!emptyInputs) {
                fetch(url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                    },
                    body: data.toString()
                })
                    .then(response => {
                        if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);             
                        return response.json();
                    })
                    .then(data => showToast(data.status, data.message))
                    .catch(() =>  showToast("Error", "El campo no se ha podido actualizar."));
            }
            else showToast("Warning", "No pueden dejarse campos vacíos o en 0.");      
        });
    });
});