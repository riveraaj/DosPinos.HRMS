const $formPayroll = document.getElementById('formPayroll');

$formPayroll.addEventListener('submit', (e) => {
    e.preventDefault();
});

const submitFormPayroll = async () => {
    let message = "¿Deseas continuar con el cálculo de nómina?",
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        showLoader();
        $formPayroll.submit();
    }
}