//Liquidation
const $formLiquidation = document.getElementById('formLiquidation'),
    $formIndividualPayroll = document.getElementById('formIndividualPayroll');

//Address
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

$formLiquidation.addEventListener('submit', (e) => {
    e.preventDefault();
});

$formIndividualPayroll.addEventListener('submit', (e) => {
    e.preventDefault();
});

const submitFormLiquidation = async () => {
    let employeeName = document.getElementById('liquidation-employee-name').value;
    let message = `¿Deseas continuar con la liquidación del empleado ${employeeName}?`,
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        $formLiquidation.submit();
    }
}

const submitFormIndividualPayroll = async () => {
    let message = `¿Deseas continuar con el cálculo de nómina?`,
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        $formIndividualPayroll.submit();
    }
}