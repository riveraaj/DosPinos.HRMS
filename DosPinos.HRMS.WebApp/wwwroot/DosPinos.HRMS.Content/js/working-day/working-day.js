const $formWorkinDay = document.querySelector('.form-working-day');

$formWorkinDay.addEventListener('submit', async (e) => {
    e.preventDefault();
    await submitFormWorkingDay(e.target);
});


flatpickr(".time-picker", {
    enableTime: true,
    noCalendar: true,
    dateFormat: "H:i", 
});

const submitFormWorkingDay = async (form) => {
    const startTime = form.querySelector('#WorkingDayObj_StartTime').value;
    const endTime = form.querySelector('#WorkingDayObj_EndTime').value;
    const freeDay = form.querySelector('#WorkingDayObj_IsFreeDay').checked;

    const timeToMinutes = (time) => {
        const [hours, minutes] = time.split(':').map(Number);
        return hours * 60 + minutes;
    };

    let hoursWorked = 0;
    let extraHours = 0;

    if (startTime && endTime) {
        const startMinutes = timeToMinutes(startTime);
        const endMinutes = timeToMinutes(endTime);

        const totalMinutesWorked = endMinutes - startMinutes;

        if (totalMinutesWorked > 0) {
            hoursWorked = totalMinutesWorked / 60;
            extraHours = (hoursWorked > 8) ? (hoursWorked - 8) : 0;
        }
    }

    const body = `<div>
                    <p>Desea confirmar su jornada laboral con los siguientes datos: </p>
                    <ul class="mt-4 ps-4 text-start">
                        <li class="mb-2"><i class="bi bi-dot"></i><span class="fw-semibold"> Hora de entrada:</span> ${startTime || 'No definido'}</li>
                        <li class="mb-2"><i class="bi bi-dot"></i><span class="fw-semibold"> Hora de salida:</span> ${endTime || 'No definido'}</li>
                        <li class="mb-2"><i class="bi bi-dot"></i><span class="fw-semibold"> Horas trabajadas:</span> ${hoursWorked.toFixed(2) || '0'} h</li>
                        <li class="mb-2"><i class="bi bi-dot"></i><span class="fw-semibold"> Horas extras:</span> ${extraHours.toFixed(2) || '0'} h</li>
                        <li class="mb-2"><i class="bi bi-dot"></i><span class="fw-semibold"> Día libre:</span> ${freeDay ? 'Sí' : 'No'}</li>
                    </ul>
                 </div>`;

    let html = body,
        icon = "question",
        isConfirmed = await showConfirmationAlertRaw(html, icon);

    if (isConfirmed) {
        form.submit();
    }
};
