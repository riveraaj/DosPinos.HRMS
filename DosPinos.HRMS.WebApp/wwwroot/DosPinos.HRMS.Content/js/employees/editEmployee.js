const $formLiquidation = document.getElementById('formLiquidation'),
    $formIndividualPayroll = document.getElementById('formIndividualPayroll');

$formLiquidation.addEventListener('submit', (e) => {
    e.preventDefault();
});

$formIndividualPayroll.addEventListener('submit', (e) => {
    e.preventDefault();
});

const submitFormLiquidation = async () => {
    let message = `¿Deseas continuar con la liquidación del empleado @Model.Employee.EmployeeName?`,
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