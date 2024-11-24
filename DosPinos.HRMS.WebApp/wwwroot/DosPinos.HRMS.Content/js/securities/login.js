const $passInput = document.getElementById('pass-input'),
    $passIcon = document.getElementById('eye-password');

document.addEventListener('click', e => {
    if (e.target === $passIcon) {
        const type = $passInput.type === "password" ? "text" : "password";
        $passInput.type = type;

        //change icon
        $passIcon.className = type === "password"
            ? 'bi bi-eye'
            : 'bi bi-eye-slash';
    }
});