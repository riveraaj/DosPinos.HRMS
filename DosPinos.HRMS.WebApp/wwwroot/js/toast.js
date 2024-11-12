window.addEventListener('load', () => {
    // Verificar si existen valores para mostrar la alerta
    if (operationStatus && operationMessage) {
        showToast(operationStatus, operationMessage);
    }
});

function showToast(status, message) {
    let iconType = '';
    let backgroundColor = '';

    // Determinar el tipo de alerta
    switch (status) {
        case 'Success':
            iconType = 'success';
            backgroundColor = '#28a745'; // verde para éxito
            break;
        case 'Warning':
            iconType = 'warning';
            backgroundColor = '#FFD146'; // amarillo para advertencia
            break;
        case 'Error':
            iconType = 'error';
            backgroundColor = '#dc3545'; // rojo para error
            break;
        default:
            iconType = 'info';
            backgroundColor = '#17a2b8'; // azul para información
            break;
    }

    // Mostrar el toast con el botón de cierre
    Swal.fire({
        toast: true, // Activar el modo toast
        position: 'top-end', // Posición en la parte superior derecha
        icon: iconType, // Tipo de ícono (success, error, warning, etc.)
        title: message, // El mensaje a mostrar
        showConfirmButton: false, // No mostrar el botón de confirmación
        timer: 7000, // Duración en milisegundos (7 segundos)
        background: backgroundColor, // Fondo personalizado
        timerProgressBar: true, // Mostrar la barra de progreso mientras el toast está activo
        showCloseButton: true, // Mostrar el botón de cierre
        closeButtonAriaLabel: 'Cerrar', // Texto alternativo para accesibilidad
    });
}