const provinces = JSON.parse(document.getElementById('provinceList').getAttribute('data-content')),
    cantons = JSON.parse(document.getElementById('cantonList').getAttribute('data-content')),
    districts = JSON.parse(document.getElementById('districtList').getAttribute('data-content'));

const $provinceSelect = document.getElementById('provinceSelect'),
    $cantonSelect = document.getElementById('cantonSelect'),
    $districtSelect = document.getElementById('districtSelect');

document.addEventListener('DOMContentLoaded', () => {
    loadData();

    $cantonSelect.parentElement.style.display = 'none';
    $districtSelect.parentElement.style.display = 'none';

    $provinceSelect.addEventListener('change', e => loadCantonData());
    $cantonSelect.addEventListener('change', e => loadDistrictData());
});

const loadData = () => {
    provinces.forEach(p => {
        const option = document.createElement('option');
        option.value = p.ProvinceId;
        option.textContent = p.ProvinceDescription;
        $provinceSelect.appendChild(option);
    })
}

const loadCantonData = () => {
    $cantonSelect.parentElement.style.display = 'block';
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
    $districtSelect.parentElement.style.display = 'block';
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