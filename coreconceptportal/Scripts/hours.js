toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-center",
    "preventDuplicates": true,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "2000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var selectindexEvents = 0;
    var calendar = new FullCalendar.Calendar(calendarEl, {
        header: {
            left: 'prev,next today addEventButton',
            center: 'title',
            right: 'timeGridWeek,dayGridMonth'
        },
        plugins: ['timeGrid', 'dayGrid', 'interaction', 'momentTimezone'],
        defaultView: 'timeGridWeek',
        locale: 'pt',
        height: 'parent',
        selectable: true,
        editable: true,
        allDaySlot: false,
        unselectAuto: false,
        events:
            [
                {
                    id: '1',
                    title: 'Horas extras no projeto X',
                    start: '2020-02-04T06:30:00Z',
                    end: '2020-02-04T13:30:00Z',
                    color: '#777777',
                    backgroundColor: '#eeeef0',
                    editable: true,
                },
                {
                    id: '2',
                    title: 'Hora extra no projeto X',
                    start: '2020-02-05T13:30:00Z',
                    end: '2020-01-05T14:30:00Z',
                    color: '#777777',
                    backgroundColor: '#eeeef0',
                    editable: true,
                },
            ],
        selectOverlap: function (event) {
            return event.rendering === 'background';
        },
        eventOverlap: false,
        dateClick: false,
        select: false,
        dateClick: function (info) {
            var selectedHours = parseInt($(".totalhours").val());
            if (!isNaN(selectedHours)) {
                var stringDate = info.dateStr;
                var datetime = new Date(stringDate);
                datetime.setHours(datetime.getHours() + selectedHours);
                var endString = datetime.toISOString();
                calendar.unselect();
                calendar.addEvent({
                    id: "tempevent" + selectindexEvents,
                    title: " ",
                    start: stringDate,
                    end: endString,
                    classNames: "customselect customselect" + selectindexEvents,
                });
                $('.customselect' + selectindexEvents).attr('data-startdate', info.startStr);
                $('.customselect' + selectindexEvents).attr('data-enddate', info.endStr);
            } else {
                toastr.error("Introduza a quantidade de horas que quer introduzir", "Alerta");
            }
        },
        select: function (info) {
            selectindexEvents++;
            var startDate = new Date(info.start);
            var endDate = new Date(info.end)
            startDate.setMinutes(startDate.getMinutes() + 30)
            if (startDate.getTime() != endDate.getTime()) {
                calendar.unselect();
                calendar.addEvent({
                    id: "tempevent" + selectindexEvents,
                    title: " ",
                    start: info.startStr,
                    end: info.endStr,
                    classNames: "customselect customselect" + selectindexEvents,
                });
            }
            $('.customselect' + selectindexEvents).attr('data-startdate', info.startStr);
            $('.customselect' + selectindexEvents).attr('data-enddate', info.endStr);
        },
        customButtons: {
            addEventButton: {
                text: 'Save',
                click: function () {
                    if ($(".fc-addEventButton-button").data("enddate") != undefined && $('.fc-addEventButton-button').data('startdate') != undefined) {
                        var startDate = $(".fc-addEventButton-button").data("startdate");
                        var endDate = $(".fc-addEventButton-button").data("enddate");
                        swal({
                            title: "Adicionar Horas",
                            text: "Pretende adicionar as horas selecionas ao seu calendário?",
                            type: "input",
                            inputPlaceholder: "Introduza um titulo",
                            showCancelButton: true,
                            confirmButtonClass: "btn-primary",
                            confirmButtonText: "Adicionar",
                            cancelButtonText: "Cancelar",
                            closeOnConfirm: false,
                        },
                            function (inputValue) {
                                if (inputValue === false) return false;
                                if (inputValue.trim() === "") {
                                    toastr.error('Por favor escreva algo!', 'Alerta');
                                    return false;
                                } else {
                                    swal.close();
                                    toastr.success('Horas adicionadas com sucesso!', 'Alerta');
                                    var eventsArray = calendar.getEvents();
                                    console.log(eventsArray.length + "-" + startDate + " | " + endDate);
                                    calendar.addEvent({
                                        id: eventsArray.length + 1,
                                        title: inputValue,
                                        start: startDate,
                                        end: endDate,
                                        color: '#777777',
                                        backgroundColor: '#eeeef0'
                                    });
                                    $('.fc-addEventButton-button').removeAttr('data-startdate');
                                    $('.fc-addEventButton-button').removeAttr('data-enddate');
                                }
                            });
                    } else {
                        toastr.error('Por favor selecione horas para adicionar!', 'Alerta');
                    }
                }
            }
        },
        eventRender: function (info) {
            var eventsArray = calendar.getEvents();
            if (eventsArray.length != 0) {
                $(info.el).children('.fc-content').append('<span data-eventid="' + info.event.id + '" class="closeon">X</span>');
                $(info.el).children('.fc-content').children('.closeon').click(function () {
                    var event = calendar.getEventById($(this).data("eventid"));
                    event.remove();
                });
            }
        }
    });

    calendar.render();
});