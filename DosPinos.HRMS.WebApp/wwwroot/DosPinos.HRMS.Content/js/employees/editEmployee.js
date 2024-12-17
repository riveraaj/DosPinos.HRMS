/*  Handler Address  */
const provinces = JSON.parse(document.getElementById('provinceList').getAttribute('data-content')),
    cantons = JSON.parse(document.getElementById('cantonList').getAttribute('data-content')),
    districts = JSON.parse(document.getElementById('districtList').getAttribute('data-content'));

const $provinceSelect = document.getElementById('provinceSelect'),
    $cantonSelect = document.getElementById('cantonSelect'),
    $districtSelect = document.getElementById('districtSelect');


document.addEventListener('DOMContentLoaded', () => {
    $provinceSelect.addEventListener('change', e => loadCantonData());
    $cantonSelect.addEventListener('change', e => loadDistrictData());
});

const loadCantonData = () => {
    $cantonSelect.parentElement.style.display = 'flex';
    $cantonSelect.innerHTML = '<option selected disabled value="">Seleccione una opción</option>';
    $districtSelect.innerHTML = '<option selected disabled value="">Seleccione una opción</option>';

    let newData = [];

    cantons.forEach(c => {
        if (c.ProvinceId == $provinceSelect.value) newData.push(c);
    });

    newData.forEach(c => {
        const option = document.createElement('option');
        option.value = c.CantonId;
        option.textContent = c.CantonDescription;
        $cantonSelect.appendChild(option);
    })
}

const loadDistrictData = () => {
    $districtSelect.parentElement.style.display = 'flex';
    $districtSelect.innerHTML = '<option selected disabled value="">Seleccione una opción</option>';

    let newData = [];

    districts.forEach(c => {
        if (c.CantonId == $cantonSelect.value) newData.push(c);
    });

    newData.forEach(d => {
        const option = document.createElement('option');
        option.value = d.DistrictId;
        option.textContent = d.DistrictDescription;
        $districtSelect.appendChild(option);
    })
}

/* Hanlder Forms */
const $formLiquidation = document.getElementById('formLiquidation'),
    $formIndividualPayroll = document.getElementById('formIndividualPayroll'),
    $formReward = document.getElementById('formReward');

$formLiquidation.addEventListener('submit', e => e.preventDefault());
$formIndividualPayroll.addEventListener('submit', e => e.preventDefault());
$formReward.addEventListener('submit', e => e.preventDefault());

const submitFormLiquidation = async () => {
    let employeeName = document.getElementById('alert-employee-name').value;
    let message = `¿Deseas continuar con la liquidación del empleado ${employeeName}?`,
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        $formLiquidation.submit();
    }
}

const submitFormIndividualPayroll = async () => {
    let employeeName = document.getElementById('alert-employee-name').value;
    let message = `¿Deseas continuar con el cálculo de nómina para el empleado ${employeeName}?`,
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        $formIndividualPayroll.submit();
    }
}

const submitFormReward = async () => {
    let employeeName = document.getElementById('alert-employee-name').value;
    let message = `¿Deseas continuar con la asignación del bono para el empleado ${employeeName}?`,
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        $formReward.submit();
    } 
}

/* Hanlder update fields */
document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('form');

    forms.forEach(form => {
        form.addEventListener('change', function (e) {
            const url = form.getAttribute('data-url'),
                formData = new FormData(form),
                data = new URLSearchParams(formData);
            let emptyInputs = false,
                nonDistrict = true;

            formData.forEach((value, key) => {
                if (value === "" || value === null) emptyInputs = true;
                if (key.endsWith("ProvinceId") || key.endsWith("CantonId")) nonDistrict = false;
                if (key.endsWith("DistrictId")) nonDistrict = true;
            });

            if (!emptyInputs && nonDistrict) {
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
            } else if (emptyInputs){
                showToast("Warning", "No pueden dejarse campos vacíos.");
            }
        });
    });
});