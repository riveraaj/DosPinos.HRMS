//Edit employee filds
document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('form');

    forms.forEach(form => {
        form.addEventListener('change', function (e) {
            const url = form.getAttribute('data-url'),
                formData = new FormData(form);
            let emptyInputs = false;

            formData.forEach((value, key) => {
                if (value === "" || value === null) emptyInputs = true;
                if (key === "user.RolId") {
                    formData.append("UpdateUserObj.RoleId", value);
                    formData.delete(key);
                }
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
                    .catch(error => {
                        showToast("Error", "El campo no se ha podido actualizar.");
                    });
            } else {
                showToast("Warning", "No pueden dejarse campos vacíos.");
            }
        });
    });
});