const $formChristmasBonus = document.getElementById('formChristmasBonus');

$formChristmasBonus.addEventListener('submit', (e) => {
    e.preventDefault();
});

const submitFormChristmasBonus = async () => {
    let message = "¿Deseas continuar con el cálculo de aguinaldos?",
        icon = "question",
        isConfirmed = await showConfirmationAlert(message, icon);

    if (isConfirmed) {
        showLoader();
        $formChristmasBonus.submit();
    }
}